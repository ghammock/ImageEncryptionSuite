#region filename
/// FluidDynamicsEncryptor.cs
#endregion

/// <summary>
/// This file contains the implementation of the fluid-dynamic-inspired
/// image encryption key class.
/// </summary>

#region copyright
/// Copyright (c) Gary Hammock, 2016

/// Permission is hereby granted, free of charge, to any person obtaining a
/// copy of this software and associated documentation files (the "Software"),
/// to deal in the Software without restriction, including without limitation
/// the rights to use, copy, modify, merge, publish, distribute, sublicense,
/// and/or sell copies of the Software, and to permit persons to whom the
/// Software is furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included
/// in all copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
/// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
/// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
/// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
/// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
/// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
/// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
#endregion

using System;
using System.Drawing;

namespace ImageEncryption.FluidDynamicsInspired
{
    public class FluidDynamicsEncryptor : ImageEncryption
    {
        /**************************************************
        *                  Public Fields                  *
        **************************************************/

        /// <summary>
        /// The key that is used for the encryption/decryption process.
        /// </summary>
        public FluidDynamicsKey Key;

        /**************************************************
        *                  Constructors                   *
        **************************************************/

        /// <summary>
        /// Empty default constructor.
        /// </summary>
        public FluidDynamicsEncryptor()
        { }

         /// <summary>
        /// Basic constructor with a predefined key.
        /// </summary>
        /// <param name="key">
        /// The FluidDynamicsKey object that will be used by the cryptosystem.
        /// </param>
        public FluidDynamicsEncryptor (FluidDynamicsKey key)
            : this(null, key)
        { }

        /// <summary>
        /// Basic initialization constructor with a predefined plaintext image.
        /// </summary>
        /// <param name="plaintextImage">
        /// The image that will be encrypted once a key is defined.
        /// </param>
        public FluidDynamicsEncryptor (Bitmap plaintextImage)
            : this(plaintextImage, FluidDynamicsKey.Generate())
        { }

        /// <summary>
        /// Full initialization constructor.
        /// </summary>
        /// <param name="plaintextImage">
        /// The image that is to be encrypted.
        /// </param>
        /// <param name="key">
        /// The FluidDynamicsKey object that is used to encrypt the image.
        /// </param>
        public FluidDynamicsEncryptor (Bitmap plaintextImage, FluidDynamicsKey key)
        {
            this.PlaintextImage = (Bitmap)plaintextImage.Clone();
            Key = key.Clone();
        }

        /**************************************************
        *                 Public Methods                  *
        **************************************************/

        /// <summary>
        /// Encrypt the plaintext image with the given key.
        /// </summary>
        public void Encrypt()
        {
            // Check the input for the correct domain of values.
            if (Key == null || !Key.IsValidKey())
                throw new System.ArgumentException("The key is not valid.");

            // Ensure that a plaintext image is available for encryption.
            if (PlaintextImage == null)
            {
                throw new System.NullReferenceException(
                    "The plaintext image is not defined.");
            }

            // Ensure that we have a 24bpp image to work with since SetPixel()
            // won't work with an indexed image.
            CiphertextImage = PlaintextImage.Clone(
                new Rectangle(0, 0, PlaintextImage.Width, PlaintextImage.Height),
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            
            ApplyMomentumFlux();
            ApplyHeatFlux();
            ApplyDissipativeTurbulence();
        }  // End method Encrypt().

        /// <summary>
        /// This method applies the row-wise (scanline) momentum (mass) fluxes.
        /// </summary>
        private void ApplyMomentumFlux()
        {
            // Retrieve the size of the image in pixels.
            int n = PlaintextImage.Height;
            int m = PlaintextImage.Width;

            // Generate a logistic map to seed the mass flow rate vector.
            double[] logisticMap = GenerateLogisticMap(Key.R_mdot,
                Key.MassFlowRateInitializer, n);

            // The row-wise mass flow rates are a true set of integers [0, n].
            int[] rowMassFlowRate = new int[n];
            for (int i = 0; i < n; ++i)
                rowMassFlowRate[i] = i;

            // Randomize the mass flow rates by the sort order
            // of the logistic map vector.
            Array.Sort(logisticMap, rowMassFlowRate);

            // Right circular rotate each scanline in the image.
            int row = 0;
            for (int y = 0; y < n; ++y)
            {
                for (int x = 0; x < m; ++x)
                {
                    int replacementIndex = (x + rowMassFlowRate[row]) % m;

                    Color replaceWith
                        = PlaintextImage.GetPixel(replacementIndex, y);

                    CiphertextImage.SetPixel(x, y, replaceWith);
                }

                row++;
            }
        }  // End method ApplyMomentumFlux().

        /// <summary>
        /// This method applies the column-wise heat fluxes.
        /// </summary>
        private void ApplyHeatFlux()
        {
            // Retrieve the size of the image in pixels.
            int n = PlaintextImage.Height;
            int m = PlaintextImage.Width;

            // Generate a logistic map to seed the mass flow rate vector.
            double[] logisticMap = GenerateLogisticMap(Key.R_qdot,
                Key.HeatTransferInitializer, m);

            // The elements of the heat flux vector are in
            // the integer set [0, 255].  This is effectively an
            // initialization vector for the bottom scanline.
            int[] columnHeatFlux = new int[m];
            for (int i = 0; i < m; ++i)
                columnHeatFlux[i] = (int)(255 * logisticMap[i]);

            // For every pixel in the image, XOR its value with the
            // value of the pixel beneath it.
            for (int x = 0; x < m; ++x)
            {
                for (int y = 0; y < n; ++y)
                {
                    Color source = CiphertextImage.GetPixel(x, y);

                    int Tj = (source.ToArgb() & 0x000000ff);
                    int Tj1 = Tj ^ columnHeatFlux[x];

                    Color replaceWith = Color.FromArgb(0xff, Tj1, Tj1, Tj1);

                    CiphertextImage.SetPixel(x, y, replaceWith);
                }
            }
        }  // End method ApplyHeatFlux().

        /// <summary>
        /// Retrieve the turbulent kinetic energy value using the
        /// Reynolds k-epsilon equation.  This value is applied to
        /// the <c>GetDissipativeTurbulence()</c> method.
        /// </summary>
        /// <returns>
        /// A kinetic turbulence energy value in the domain [0, 255].
        /// </returns>
        private byte GetTurbulenceMultiplier()
        {
            // 0.92 is the turbulence destructive term.  See Reynolds, 1987.
            double arg = 0.92 * (double)Key.Epsilon
                * (double)Key.TFrame / (double)Key.K0;

            double exponent = -1.0 / 0.92;

            double Kt = (double)Key.K0 * Math.Pow(1.0 + arg, exponent);

            return (byte)Kt;
        }

        /// <summary>
        /// Applies the k-epsilon dissipative turbulence
        /// value to the secret image.
        /// </summary>
        private void ApplyDissipativeTurbulence ()
        {
            // Retrieve the size of the image in pixels.
            int m = PlaintextImage.Width;
            int n = PlaintextImage.Height;

            // This is the scalar value to apply to the XOR operation.
            byte scalar = GetTurbulenceMultiplier();

            // For every pixel in the image, XOR its value with the
            // value of the secret image and the turbulence scalar value.
            for (int y = 0; y < n; ++y)
            {
                for (int x = 0; x < m; ++x)
                {
                    int pixel = CiphertextImage.GetPixel(x, y).ToArgb();
                    int secPixel = Key.SecretImage.GetPixel(x, y).ToArgb();
                    
                    // The luminance value of the XOR of the
                    // input image and the secret image.
                    byte Y = (byte)((pixel    & 0x000000ff)
                                  ^ (secPixel & 0x000000ff));

                    // Apply the scalar value.
                    int xor = Y ^ scalar;

                    Color newPix = Color.FromArgb(0xff, xor, xor, xor);

                    CiphertextImage.SetPixel(x, y, newPix);
                }
            }
        }  // End method ApplyDissipativeTurbulence().

        /// <summary>
        /// Generate a vector of deterministic chaos values
        /// using the logistic function.
        /// </summary>
        /// <param name="r">
        /// The population growth coefficient, <c>r</c> in (3.569955672, 4].
        /// </param>
        /// <param name="x0">
        /// The population initializer, <c>x0</c> in [0, 1].
        /// </param>
        /// <param name="iterations">
        /// The number of iterations to perform which is in this case,
        /// the size of the vector.
        /// </param>
        /// <returns>
        /// An array of double precision values of length <c>iterations</c>.
        /// </returns>
        private double[] GenerateLogisticMap
            (double r, double x0, int iterations)
        {
            // Ensure that the values are in the correct domains.
            if (r <= 3.569955672 || r > 4.0)
                throw new ArgumentOutOfRangeException();
            if (x0 < 0.0 || x0 > 1.0)
                throw new ArgumentOutOfRangeException();

            // This is the vector of chaotic logistic map values.
            double[] logisticMap = new double[iterations];

            // The logistic map is defined as:
            //    x_n = r * x_(n-1) * (1 - x_(n-1))
            logisticMap[0] = x0;
            for (int x = 1; x < iterations; ++x)
            {
                logisticMap[x] = r * logisticMap[x - 1]
                    * (1.0 - logisticMap[x - 1]);
            }

            return logisticMap;
        }
    }  // End class FluidDynamicsEncryptor.
}
