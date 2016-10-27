//-----------------------------------------------------------------------------
// <author>Gary Hammock, PE</author>
// <date>2016-03-14</date>
//-----------------------------------------------------------------------------
// <summary>
// This file contains the implementation details of the Bio-Inspired
// image encryption scheme as laid out by Al-Utaibi and El-Alfy.  It
// uses a discrete logistic map to generate deterministic chaos maps
// that form the key streams used for both crossover and mutation of
// an input image.
// </summary>
//
// <reference>
// @inproceedings{Al-Utaibi2010,
//   author = {Al-Utaibi, Khaled A. and El-Alfy, El-Sayed M.},
//   booktitle = {IEEE Congress on Evolutionary Computation},
//   doi = {10.1109/CEC.2010.5586463},
//   isbn = {978-1-4244-6909-3},
//   month = {jul},
//   pages = {1--6},
//   publisher = {IEEE},
//   title = {{A bio-inspired image encryption algorithm based on chaotic maps}},
//   url = {http://ieeexplore.ieee.org/lpdocs/epic03/wrapper.htm?arnumber=5586463},
//   year = {2010}
// }
// </reference>
//
//-----------------------------------------------------------------------------
// LICENSE  (MIT/X11 License)
//-----------------------------------------------------------------------------
// Copyright (c) Gary Hammock, 2016
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY  CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

using System;
using System.Drawing;

namespace ImageEncryption.BioInspired
{
    /// <summary>
    /// This class implements image encryption using the biologically
    /// inspired method proposed by Al-Utaibi and El-Alfy in:
    /// 
    /// @inproceedings{Al-Utaibi2010,
    ///   author = {Al-Utaibi, Khaled A. and El-Alfy, El-Sayed M.},
    ///   booktitle = {IEEE Congress on Evolutionary Computation},
    ///   doi = {10.1109/CEC.2010.5586463},
    ///   isbn = {978-1-4244-6909-3},
    ///   month = {jul},
    ///   pages = {1--6},
    ///   publisher = {IEEE},
    ///   title = {{A bio-inspired image encryption algorithm based on chaotic maps}},
    ///   url = {http://ieeexplore.ieee.org/lpdocs/epic03/wrapper.htm?arnumber=5586463},
    ///   year = {2010}
    /// }
    /// </summary>
    public class BioInspiredEncryptor : ImageEncryption
    {
        /**************************************************
        *                  Public Fields                  *
        **************************************************/

        /// <summary>
        /// The key that is used for the encryption/decryption process.
        /// </summary>
        public BioInspiredKey Key;

        /**************************************************
        *                  Constructors                   *
        **************************************************/

        /// <summary>
        /// Empty default constructor.
        /// </summary>
        public BioInspiredEncryptor()
        { }

        /// <summary>
        /// Basic constructor with a predefined key.
        /// </summary>
        /// <param name="key">
        /// The BioInspiredKey object that will be used by the cryptosystem.
        /// </param>
        public BioInspiredEncryptor(BioInspiredKey key)
            : this(null, key)
        { }

        /// <summary>
        /// Basic initialization constructor with a predefined plaintext image.
        /// </summary>
        /// <param name="plaintextImage">
        /// The image that will be encrypted once a key is defined.
        /// </param>
        public BioInspiredEncryptor(Bitmap plaintextImage)
            : this(plaintextImage, BioInspiredKey.Generate())
        { }

        /// <summary>
        /// Full initialization constructor.
        /// </summary>
        /// <param name="plaintextImage">
        /// The image that is to be encrypted.
        /// </param>
        /// <param name="key">
        /// The BioInspiredKey object that is used to encrypt the image.
        /// </param>
        public BioInspiredEncryptor(Bitmap plaintextImage, BioInspiredKey key)
        {
            PlaintextImage = (Bitmap)plaintextImage.Clone();
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

            double [] x1;  // Chaos map for row crossovers.
            double [] x2;  // Chaos map for col. crossovers.
            double [] x3;  // Chaos map for row mutation.
            double [] x4;  // Chaos map for col. mutation.

            GenerateLogisticMaps(out x1, out x2, out x3, out x4);

            // Quantification Unit -- Generates four key streams.
            //
            // s1 is used to perform row-wise crossover
            // s2 is used to perform columnn-wise crossover
            // s3 is used to select a pseudo-random row index
            //    in a secret image for XOR-ing.
            // s4 is used to select a pseudo-random column index
            //    in a secret image for XOR-ing.
            //
            int [] s1;  // The indices of the sorted x1 array.
            int [] s2;  // The indices of the sorted x2 array.
            int [] s3;  // The indices of the sorted x3 array.
            int [] s4;  // The indices of the sorted x4 array.

            GenerateQuantificationUnits(
                x1, x2, x3, x4,
                out s1, out s2, out s3, out s4);

            // Perform the row and column crossover steps.
            CrossOver(s1, s2);

            // Mutate (XOR) the intermediate image with the
            // secret image from the key.
            Mutate(s3, s4);

            CiphertextImage = GrayScale(CiphertextImage);
        }  // End method Encrypt.

        /**************************************************
        *                 Private Methods                 *
        **************************************************/

        /// <summary>
        /// Uses the values from the <see cref="BioInspiredKey" /> to
        /// build four arrays of deterministic chaos values based
        /// on the logistic map.
        /// </summary>
        /// <param name="x1">
        /// The chaos map for row crossovers.
        /// </param>
        /// <param name="x2">
        /// The chaos map for column crossovers.
        /// </param>
        /// <param name="x3">
        /// The chaos map that controls row mutation.
        /// </param>
        /// <param name="x4">
        /// The chaos map that controls column mutation.
        /// </param>
        private void GenerateLogisticMaps(
            out double[] x1, out double[] x2,
            out double[] x3, out double[] x4)
        {
            int m = PlaintextImage.Height;  // Number of rows.
            int n = PlaintextImage.Width;   // Number of columns.

            x1 = new double [m];  // Chaos map for row crossovers.
            x2 = new double [n];  // Chaos map for col. crossovers.
            x3 = new double [m];  // Chaos map for row mutation.
            x4 = new double [n];  // Chaos map for col. mutation.

            // The first elements of the logistic (chaos)
            // map is the input key values.
            x1[0] = Key.X01;
            x2[0] = Key.X02;
            x3[0] = Key.X03;
            x4[0] = Key.X04;

            // Discrete logistic maps given by:
            //    x[n + 1] = mu * x[n] * (1 - x[n])
            //
            // Note that for 3.569955672 < mu <= 4.0
            // x[n] is a chaotic value.
            for (int i = 1; i < m; ++i)
            {
                // Row streams.
                x1[i] = Key.Mu1 * x1[i - 1] * (1.0 - x1[i - 1]);
                x3[i] = Key.Mu3 * x3[i - 1] * (1.0 - x3[i - 1]);
            }
            for (int i = 1; i < n; ++i)
            {
                // Column streams.
                x2[i] = Key.Mu2 * x2[i - 1] * (1.0 - x2[i - 1]);
                x4[i] = Key.Mu4 * x4[i - 1] * (1.0 - x4[i - 1]);
            }
        }

        /// <summary>
        /// Generate four key streams from the indices of the
        /// sorted chaos arrays.
        /// </summary>
        /// <param name="x1">
        /// The chaos map for row crossovers.
        /// </param>
        /// <param name="x2">
        /// The chaos map for column crossovers.
        /// </param>
        /// <param name="x3">
        /// The chaos map that controls row mutation.
        /// </param>
        /// <param name="x4">
        /// The chaos map that controls column mutation.
        /// </param>
        /// <param name="s1">
        /// The stream array that is used to perform row-wise crossover.
        /// </param>
        /// <param name="s2">
        /// The stream array that is used to perform columnn-wise crossover.
        /// </param>
        /// <param name="s3">
        /// The stream array that is used to select a pseudo-random row index
        /// for XOR-ing with a secret image.
        /// </param>
        /// <param name="s4">
        /// The stream array that is used to select a pseudo-random column
        /// index for XOR-ing with a secret image.
        /// </param>
        private void GenerateQuantificationUnits(
            double[] x1, double[] x2, double [] x3, double [] x4,
            out int[] s1, out int[] s2, out int[] s3, out int[] s4)
        {
            if (x1 == null || x2 == null || x3 == null || x4 == null)
                throw new System.NullReferenceException();

            if (x1.Length != x3.Length || x2.Length != x4.Length)
                throw new System.FormatException();

            int m = PlaintextImage.Height;  // Number of rows.
            int n = PlaintextImage.Width;   // Number of columns.

            // Quantification Unit -- Generates four key streams.
            //
            // s1 is used to perform row-wise crossover
            // s2 is used to perform columnn-wise crossover
            // s3 is used to select a pseudo-random row index
            //    in a secret image for XOR-ing.
            // s4 is used to select a pseudo-random column index
            //    in a secret image for XOR-ing.
            s1 = new int [m];  // The indices of the sorted x1 array.
            s2 = new int [n];  // The indices of the sorted x2 array.
            s3 = new int [m];  // The indices of the sorted x3 array.
            s4 = new int [n];  // The indices of the sorted x4 array.

            // Initialize the streams with the index values.
            int end = Math.Max(n, m);
            for (int i = 0; i < end; ++i)
            {
                if (i < m)
                {
                    // Row key streams.
                    s1[i] = i;
                    s3[i] = i;
                }
                if (i < n)
                {
                    // Column key streams.
                    s2[i] = i;
                    s4[i] = i;
                }
            }

            // Sort the "chaotic" key streams, x[k], and maintain the
            // index values, s[k]. These are used to control the
            // crossover and mutation units.
            Array.Sort(x1, s1);
            Array.Sort(x2, s2);
            Array.Sort(x3, s3);
            Array.Sort(x4, s4);
        }

        /// <summary>
        /// Perform row and column crossover operations to permute the
        /// image data into an intermediate image.
        /// </summary>
        /// <param name="s1">
        /// The stream array that is used to perform row-wise crossover.
        /// </param>
        /// <param name="s2">
        /// The stream array that is used to perform columnn-wise crossover.
        /// </param>
        private void CrossOver (int[] s1, int[] s2)
        {
            int m = PlaintextImage.Height;  // Number of rows.
            int n = PlaintextImage.Width;   // Number of columns.

            // Ensure that the number of cut points is even!
            int numRowCutPoints = (int)Math.Floor((double)n / 2.0);
            int numColCutPoints = (int)Math.Floor((double)m / 2.0);
            
            int[] rowCutPoints = new int[numRowCutPoints];
            int[] colCutPoints = new int[numColCutPoints];

            // Perform row-wise crossovers
            for (int y = 1; y < m; ++y)
            {
                rowCutPoints[0] = Math.Abs(s1[y - 1] - s1[y]) % m;

                for (int k = 1; k < numRowCutPoints; ++k)
                {
                    rowCutPoints[k] = (rowCutPoints[k - 1]
                        + Math.Abs(s1[y - 1] - s1[y])) % m;
                }

                Array.Sort(rowCutPoints);

                for (int k = 1; k < numRowCutPoints; ++k)
                {
                    for (int x = rowCutPoints[k - 1]; x < rowCutPoints[k]; ++x)
                    {
                        // Swap the pixels.
                        Color pix1 = CiphertextImage.GetPixel(x, s1[y]);
                        Color pix2 = CiphertextImage.GetPixel(x, s1[y - 1]);
                        CiphertextImage.SetPixel(x, s1[y], pix2);
                        CiphertextImage.SetPixel(x, s1[y - 1], pix1);
                    }
                }
            }  // End row-wise crossovers.

            // Perform column-wise crossovers
            for (int x = 1; x < n; ++x)
            {
                colCutPoints[0] = Math.Abs(s2[x - 1] - s2[x]) % n;

                for (int k = 1; k < numColCutPoints; ++k)
                {
                    colCutPoints[k] = (colCutPoints[k - 1]
                        + Math.Abs(s2[x - 1] - s2[x])) % n;
                }

                Array.Sort(colCutPoints);

                for (int k = 1; k < numColCutPoints; ++k)
                {
                    for (int y = colCutPoints[k - 1]; y < colCutPoints[k]; ++y)
                    {
                        // Swap the pixels.
                        Color pix1 = CiphertextImage.GetPixel(s2[x], y);
                        Color pix2 = CiphertextImage.GetPixel(s2[x - 1], y);
                        CiphertextImage.SetPixel(s2[x], y, pix2);
                        CiphertextImage.SetPixel(s2[x - 1], y, pix1);
                    }
                }
            }  // End column-wise crossovers.
        }  // End method Crossover().

        /// <summary>
        /// Mutate (XOR) the intermediate image with a secret
        /// image stored in the key.
        /// </summary>
        /// <param name="s3">
        /// The stream array that is used to select a pseudo-random row index
        /// for XOR-ing with a secret image.
        /// </param>
        /// <param name="s4">
        /// The stream array that is used to select a pseudo-random column
        /// index for XOR-ing with a secret image.
        /// </param>
        private void Mutate(int[] s3, int[] s4)
        {
            int m = PlaintextImage.Height;  // Number of rows.
            int n = PlaintextImage.Width;   // Number of columns.

            // The (x, y) pixel value from the intermediate image.
            uint intermediate = 0;

            // The (s3[x], s4[y]) pixel value from the secret image.
            uint secret = 0;

            // The "mutated" pixel is the exclusive-or (XOR) of the
            // intermediate pixel and the secret key pixel.
            uint xor = 0;

            for (int y = 0; y < m; ++y)
            {
                for (int x = 0; x < n; ++x)
                {
                    intermediate = (uint)CiphertextImage.
                        GetPixel(x, y).ToArgb();

                    secret = (uint)Key.SecretImage.
                        GetPixel(s3[x], s4[y]).ToArgb();

                    xor = ((uint)(intermediate ^ secret) | 0xff000000);

                    CiphertextImage.SetPixel(x, y, Color.FromArgb((int)xor));
                }
            }
        }  // End method Mutate().

    }  // End class BioInspiredEncryptor.
}
