//-----------------------------------------------------------------------------
// <author>Gary Hammock, PE</author>
// <date>2016-03-14</date>
//-----------------------------------------------------------------------------
// <summary>
// This file contains the implementation details of the Bio-Inspired
// image encryption keys for use with the <see cref="BioInspiredEncryptor" />
// which uses coefficients and arguments of the discrete logistic map to
// form key streams of deterministic chaos.
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
    public class BioInspiredKey
    {     
        /**************************************************
        *                  Public Fields                  *
        **************************************************/

        /// <summary>
        /// A image to use for the XOR step.
        /// </summary>
        public Bitmap SecretImage;

        /**************************************************
        *                 Private Fields                  *
        **************************************************/

        private double mu1;  // Growth rate coefficient for the row function.
        private double mu2;  // Growth rate coefficient for the col. function.
        private double mu3;  // Growth rate coefficient for row mutations.
        private double mu4;  // Growth rate coefficient for column mutations.
        private double x01;  // Initializer for the chaos map rows.
        private double x02;  // Initializer for the chaos map columns.
        private double x03;  // Initializer for the mutation rows.
        private double x04;  // Initializer for the mutation columns.

        /**************************************************
        *                  Constructors                   *
        **************************************************/

        /// <summary>
        /// Basic initializer constructor.
        /// </summary>
        /// <param name="mu1">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the row logistic map.
        /// </param>
        /// <param name="x01">
        /// The ratio parameter [0, 1] of the row logistic map.
        /// </param>
        /// <param name="mu2">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the column logistic map.
        /// </param>
        /// <param name="x02">
        /// The ratio parameter [0, 1] of the column logistic map.
        /// </param>
        /// <param name="mu3">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the row mutation logistic map.
        /// </param>
        /// <param name="x03">
        /// The ratio parameter [0, 1] of the row mutation logistic map.
        /// </param>
        /// <param name="mu4">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the column mutation logistic map.
        /// </param>
        /// <param name="x04">
        /// The ratio parameter [0, 1] of the column mutation logistic map.
        /// </param>
        public BioInspiredKey (
            double mu1, double x01, double mu2, double x02,
            double mu3, double x03, double mu4, double x04)
            : this(mu1, x01, mu2, x02, mu3, x03, mu4, x04, null)
        { }

        /// <summary>
        /// Full initializer constructor.
        /// </summary>
        /// <param name="mu1">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the row logistic map.
        /// </param>
        /// <param name="x01">
        /// The ratio parameter [0, 1] of the row logistic map.
        /// </param>
        /// <param name="mu2">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the column logistic map.
        /// </param>
        /// <param name="x02">
        /// The ratio parameter [0, 1] of the column logistic map.
        /// </param>
        /// <param name="mu3">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the row mutation logistic map.
        /// </param>
        /// <param name="x03">
        /// The ratio parameter [0, 1] of the row mutation logistic map.
        /// </param>
        /// <param name="mu4">
        /// The growth rate coefficient (3.569955672, 4]
        /// of the column mutation logistic map.
        /// </param>
        /// <param name="x04">
        /// The ratio parameter [0, 1] of the column mutation logistic map.
        /// </param>
        /// <param name="secretImage">
        /// The secret image to use for the XOR/mutation step.
        /// </param>
        public BioInspiredKey (
            double mu1, double x01, double mu2, double x02,
            double mu3, double x03, double mu4, double x04,
            Bitmap secretImage)
        {
            Mu1 = mu1;
            X01 = x01;

            Mu2 = mu2;
            X02 = x02;

            Mu3 = mu3;
            X03 = x03;

            Mu4 = mu4;
            X04 = x04;

            SecretImage = secretImage;
        }
        
        /**************************************************
        *                   Properties                    *
        **************************************************/

        /// <summary>
        /// The growth rate coefficient (3.569955672, 4]
        /// of the row logistic map.
        /// </summary>
        public Double Mu1
        {
            get { return mu1; }
            set
            {
                if (ValidDomain(value))
                    mu1 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The growth rate coefficient (3.569955672, 4]
        /// of the column logistic map.
        /// </summary>
        public Double Mu2
        {
            get { return mu2; }
            set
            {
                if (ValidDomain(value))
                    mu2 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The growth rate coefficient (3.569955672, 4]
        /// of the row mutation logistic map.
        /// </summary>
        public Double Mu3
        {
            get { return mu3; }
            set
            {
                if (ValidDomain(value))
                    mu3 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The growth rate coefficient (3.569955672, 4]
        /// of the column mutation logistic map.
        /// </summary>
        public Double Mu4
        {
            get { return mu4; }
            set
            {
                if (ValidDomain(value))
                    mu4 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The ratio parameter [0, 1] of the row logistic map.
        /// </summary>
        public Double X01
        {
            get { return x01; }
            set
            {
                if (ValidArgument(value))
                    x01 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The ratio parameter [0, 1] of the column logistic map.
        /// </summary>
        public Double X02
        {
            get { return x02; }
            set
            {
                if (ValidArgument(value))
                    x02 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The ratio parameter [0, 1] of the row mutation logistic map.
        /// </summary>
        public Double X03
        {
            get { return x03; }
            set
            {
                if (ValidArgument(value))
                    x03 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The ratio parameter [0, 1] of the column mutation logistic map.
        /// </summary>
        public Double X04
        {
            get { return x04; }
            set
            {
                if (ValidArgument(value))
                    x04 = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }
        
        /**************************************************
        *                 Public Methods                  *
        **************************************************/

        /// <summary>
        /// Checks that all of the stored values indicate a
        /// valid BioInspiredKey object.
        /// </summary>
        /// <returns>
        /// True if the values represent a valid key; false otherwise.
        /// </returns>
        public bool IsValidKey ()
        {
            if (   ValidArgument(x01) && ValidArgument(x02)
                && ValidArgument(x03) && ValidArgument(x04)
                && ValidDomain(mu1) && ValidDomain(mu2)
                && ValidDomain(mu3) && ValidDomain(mu4)
                && SecretImage != null)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Creates a clone of this BioInspiredKey object.
        /// </summary>
        /// <returns>
        /// A new BioInspiredKey object whose values are
        /// copied from the calling object.
        /// </returns>
        public BioInspiredKey Clone()
        {
            BioInspiredKey clone = new BioInspiredKey(
                mu1, x01, mu2, x02, mu3, x03, mu4, x04, SecretImage);

            return clone;
        }

        /// <summary>
        /// Generates a new random key that is within the valid keyspace.
        /// </summary>
        /// <returns>
        /// A new BioInspiredKey object whose values are within the
        /// correct logistic map keyspace.
        /// </returns>
        public static BioInspiredKey Generate()
        {
            Random rand = new Random();

            double scalar = (4.0 - 3.569955672);

            BioInspiredKey newKey = new BioInspiredKey(
                (scalar * rand.NextDouble()) + 3.569955672,  // mu1
                rand.NextDouble(),                           // x01
                (scalar * rand.NextDouble()) + 3.569955672,  // mu2
                rand.NextDouble(),                           // x02
                (scalar * rand.NextDouble()) + 3.569955672,  // mu3
                rand.NextDouble(),                           // x03
                (scalar * rand.NextDouble()) + 3.569955672,  // mu4
                rand.NextDouble());                          // x04

            return newKey;
        }

        /// <summary>
        /// Generates a new random key that is within the valid keyspace
        /// with a randomly generated secret image.
        /// </summary>
        /// <param name="secretImageSize">
        /// A <see cref="System.Drawing.Size" /> struct that contains the
        /// size in pixels of the secret image object to generate.
        /// </param>
        /// <returns>
        /// A new BioInspiredKey object whose values are within the
        /// correct logistic map keyspace for chaos and a randomly
        /// generated secret image.
        /// </returns>
        public static BioInspiredKey Generate(Size secretImageSize)
        {
            return Generate(secretImageSize.Width, secretImageSize.Height);
        }

        /// <summary>
        /// Generates a new random key that is within the valid keyspace
        /// with a randomly generated secret image.
        /// </summary>
        /// <param name="secretImageWidth">
        /// The width in pixels for the generated secret image.
        /// </param>
        /// <param name="secretImageHeight">
        /// The height in pixels for the generated secret image.
        /// </param>
        /// <returns>
        /// A new BioInspiredKey object whose values are within the
        /// correct logistic map keyspace for chaos and a randomly
        /// generated secret image.
        /// </returns>
        public static BioInspiredKey Generate(
            int secretImageWidth, int secretImageHeight)
        {
            BioInspiredKey newKey = Generate();
            newKey.SecretImage = ImageEncryption.GenerateSecretImage(
                secretImageWidth, secretImageHeight);
            
            return newKey;
        }

        /**************************************************
        *                 Private Methods                 *
        **************************************************/

        /// <summary>
        /// Determines if a given growth rate coefficient is in the proper
        /// domain for deterministic chaos to occur.
        /// </summary>
        /// <param name="mu">
        /// The growth rate coefficient to check.
        /// </param>
        /// <returns>
        /// True if mu is in (3.569955672, 4]; false otherwise.
        /// </returns>
        private bool ValidDomain (double mu)
        {
            if (mu > 3.569955672 && mu <= 4.0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determines if a given parameter is within the
        /// acceptable domain of X [0, 1].
        /// </summary>
        /// <param name="x">
        /// The parameter to the logistic function.
        /// </param>
        /// <returns>
        /// True if x is in [0, 1]; false otherwise.
        /// </returns>
        private bool ValidArgument (double x)
        {
            if (x >= 0.0 && x <= 1.0)
                return true;
            else
                return false;
        }

    }  // End class BioInspiredKey.
}
