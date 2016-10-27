//-----------------------------------------------------------------------------
// <author>Gary Hammock, PE</author>
// <date>2016-03-14</date>
//-----------------------------------------------------------------------------
// <summary>
// This file contains the implementation details of the inheritable
// ImageEncryption class.
// </summary>
//
//-----------------------------------------------------------------------------
// REQUIRES
//-----------------------------------------------------------------------------
// The MIT licensed Machine Learning libraries from AForge need to be included.
// At minimum, AForge.dll, AForge.Imaging.dll, and AForge.Math.dll need to
// be linked to the references!
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

using AForge.Imaging.Filters;  // For Grayscale.

namespace ImageEncryption
{
    public class ImageEncryption
    {
        /**************************************************
        *                  Public Fields                  *
        **************************************************/

        /// <summary>
        /// A (n x n) image storing the plaintext as a padded image.
        /// </summary>
        public Bitmap PlaintextImage;

        /// <summary>
        /// A (n x n) image storing the ciphertext as a padded image.
        /// </summary>
        public Bitmap CiphertextImage;

        /// <summary>
        /// Stores the name of the image if it is useful.
        /// </summary>
        public String Filename;

        /**************************************************
        *                  Constructors                   *
        **************************************************/

        /// <summary>
        /// Default (empty) constructor.
        /// </summary>
        public ImageEncryption () { }

        /// <summary>
        /// Initialization constructor with a plaintext image.
        /// </summary>
        /// <param name="plaintextImage">
        /// The image to use as the plaintext message for encryption.
        /// </param>
        public ImageEncryption (Bitmap plaintextImage)
        {
            PlaintextImage = new Bitmap(plaintextImage);
        }

        /// <summary>
        /// Full cryptosystem constructor.
        /// </summary>
        /// <param name="plaintextImage">
        /// The image to use as the plaintext message for encryption.
        /// </param>
        /// <param name="ciphertextImage">
        /// The encrypted ciphertext image for decryption.
        /// </param>
        public ImageEncryption (Bitmap plaintextImage, Bitmap ciphertextImage)
        {
            PlaintextImage = new Bitmap(plaintextImage);
            CiphertextImage = new Bitmap(ciphertextImage);
        }

        /**************************************************
        *                 Public Methods                  *
        **************************************************/

        /// <summary>
        /// Generates a pseudorandom whitenoise image for use with many
        /// image encryption schemes.
        /// </summary>
        /// <param name="size">
        /// A <see cref="System.Drawing.Size" /> struct of the size of
        /// the image to generate.
        /// </param>
        /// <returns>
        /// A <see cref="System.Drawing.Bitmap" /> of a whitenoise image.
        /// </returns>
        public static Bitmap GenerateSecretImage (Size size)
        {
            return GenerateSecretImage(size.Width, size.Height);
        }

        /// <summary>
        /// Generates a pseudorandom whitenoise image for use with many
        /// image encryption schemes.
        /// </summary>
        /// <param name="width">
        /// The width (in pixels) of the image to generate.
        /// </param>
        /// <param name="height">
        /// The height (in pixels of the image to generate.
        /// </param>
        /// <returns>
        /// A <see cref="System.Drawing.Bitmap" /> of a whitenoise image.
        /// </returns>
        public static Bitmap GenerateSecretImage(int width, int height)
        {
            Bitmap secret = new Bitmap(width, height);
            Random rand = new Random();
            int lum;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    // 0 (inclusive), 256 (exclusive).
                    lum = rand.Next(0, 256);
                    secret.SetPixel(x, y, Color.FromArgb(255, lum, lum, lum));
                }
            }

            return secret;
        }

        /**************************************************
        *                 Private Methods                 *
        **************************************************/

        /// <summary>
        /// Converts an input <see cref="System.Drawing.Bitmap" /> to a
        /// grayscale value that is based on the perceived luminance of
        /// the pixels.  Requires <see cref="AForge.Imaging.dll" />.
        /// </summary>
        /// <param name="input">
        /// A <see cref="System.Drawing.Bitmap" /> of any colorspace
        /// that is to be converted to grayscale.
        /// </param>
        /// <returns>
        /// A <see cref="System.Drawing.Bitmap" /> of the grayscale image.
        /// </returns>
        protected Bitmap GrayScale (Bitmap input)
        {
            // Requires AForge.Imaging.dll
            return Grayscale.CommonAlgorithms.Y.Apply(input);
        }

    }  // End class ImageEncryption.
}
