//-----------------------------------------------------------------------------
// <author>Gary Hammock, PE</author>
// <date>2016-03-15</date>
//-----------------------------------------------------------------------------
// <summary>
// This file contains the implementation details of the Elementary Cellular
// Automata image encryption technique as proposed by Jin in 2012.  This
// technique uses the attractor ring property of cellular automata to provide
// encryption and decryption and uses the in-built pseudo-random number
// generator to provide the avalanche effect.
// </summary>
//
// <reference>
// @article{Jin2012,
//   author = {Jin, Jun},
//   doi = {10.1016/j.optlaseng.2012.06.002},
//   issn = {01438166},
//   journal = {Optics and Lasers in Engineering},
//   month = {dec},
//   number = {12},
//   pages = {1836--1843},
//   publisher = {Elsevier},
//   title = {{An image encryption based on elementary cellular automata}},
//   url = {http://dx.doi.org/10.1016/j.optlaseng.2012.06.002},
//   volume = {50},
//   year = {2012}
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

namespace ImageEncryption.CellularAutomata
{
    /// <summary>
    /// This class implements ann Elementary Cellular Automata (ECA)
    /// image encryption technique as proposed by Jin in the article:
    /// 
    /// @article{Jin2012,
    ///   author = {Jin, Jun},
    ///   doi = {10.1016/j.optlaseng.2012.06.002},
    ///   issn = {01438166},
    ///   journal = {Optics and Lasers in Engineering},
    ///   month = {dec},
    ///   number = {12},
    ///   pages = {1836--1843},
    ///   publisher = {Elsevier},
    ///   title = {{An image encryption based on elementary cellular automata}},
    ///   url = {http://dx.doi.org/10.1016/j.optlaseng.2012.06.002},
    ///   volume = {50},
    ///   year = {2012}
    /// }
    /// </summary>
    public class CellularAutomataEncryptor : ImageEncryption
    {
        /**************************************************
        *                  Public Fields                  *
        **************************************************/

        /// <summary>
        /// The key that is used for the encryption/decryption process.
        /// </summary>
        public CellularAutomataKey Key;

        /**************************************************
        *                  Constructors                   *
        **************************************************/

        /// <summary>
        /// Empty default constructor.
        /// </summary>
        public CellularAutomataEncryptor()
        { }

        /// <summary>
        /// Basic constructor with a predefined key.
        /// </summary>
        /// <param name="key">
        /// The BioInspiredKey object that will be used by the cryptosystem.
        /// </param>
        public CellularAutomataEncryptor(CellularAutomataKey key)
            : this(null, key)
        { }

        /// <summary>
        /// Basic initialization constructor with a predefined plaintext image.
        /// </summary>
        /// <param name="plaintextImage">
        /// The image that will be encrypted once a key is defined.
        /// </param>
        public CellularAutomataEncryptor(Bitmap plaintextImage)
            : this(plaintextImage, CellularAutomataKey.Generate())
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
        public CellularAutomataEncryptor(
            Bitmap plaintextImage,CellularAutomataKey key)
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
            // Make sure we have a key!
            if (Key == null)
            {
                throw new System.ArgumentException(
                    "The key has not been instantiated.");
            }

            // Ensure that a plaintext image is available for encryption.
            if (PlaintextImage == null)
            {
                throw new System.NullReferenceException(
                    "The plaintext image is not defined.");
            }

            // We need to ensure that the plaintext image is grayscale.
            PlaintextImage = GrayScale(
                PlaintextImage.Clone(new Rectangle(0, 0,
                    PlaintextImage.Width, PlaintextImage.Height),
                System.Drawing.Imaging.PixelFormat.Format24bppRgb));

            // Ensure that we have a 24bpp image to work with since SetPixel()
            // won't work with an indexed image.
            CiphertextImage = PlaintextImage.Clone(
                new Rectangle(0, 0,
                    PlaintextImage.Width, PlaintextImage.Height),
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int [,] schedule = GenerateStateSchedule(Key.Seed);

            int [] attractorRing = MakeAttractorRing(Key.StateOne, Key.Rule);

            int lum = 0;  // The luminance value of a given pixel.
            int stateIndex = 0;

            for (int y = 0; y < PlaintextImage.Height; ++y)
            {
                for (int x = 0; x < PlaintextImage.Width; ++x)
                {
                    // Since the image is grayscale we only need
                    // one channel's data.
                    lum = PlaintextImage.GetPixel(x, y).ToArgb() & 0x000000ff;

                    // Jin recommends each pixel's starting state use the
                    // attractor ring index (x + y) mod 8.
                    stateIndex = (x + y) % 8;
                    lum ^= attractorRing[stateIndex];

                    // This provides the avalanche effect.
                    for (int i = 0; i < schedule[x, y]; ++i)
                    {
                        stateIndex = (++stateIndex) % 8;
                        lum ^= attractorRing[stateIndex];
                    }

                    // Write the pixel data to the ciphertext image.
                    CiphertextImage.SetPixel(
                        x, y, Color.FromArgb(0xff, lum, lum, lum));
                }
            }
        }  // End method Encrypt().

        /**************************************************
        *                 Private Methods                 *
        **************************************************/

        /// <summary>
        /// Generate an M x N (same as plaintext image dimensions) matrix for
        /// the state schedule (i.e. the number of times the cellular automaton
        /// is applied to the pixel at each (x, y)).
        /// </summary>
        /// <returns>
        /// An M x N matrix where each (x, y) corresponds to the number of
        /// times the cellular automaton is applied to each pixel and each
        /// element is in the set [1, 8].
        /// </returns>
        private int[,] GenerateStateSchedule(int seed)
        {
            int m = PlaintextImage.Width;
            int n = PlaintextImage.Height;

            int [,] schedule = new int [m, n];
            Random rand = new Random(seed);

            for (int y = 0; y < n; ++y)
            {
                for (int x = 0; x < m; ++x)
                    schedule[x, y] = rand.Next(1, 8);
            }

            return schedule;
        }

        /// <summary>
        /// Build the attractor ring based on the given state and rule.
        /// </summary>
        /// <param name="initialState">
        /// The initial state to use for generating the attractor ring.
        /// </param>
        /// <param name="rule">
        /// The Wolfram rule number [0, 255] of the cellular automaton.
        /// </param>
        /// <returns>
        /// An 8 element array that contains the states that
        /// comprise the attractor ring.
        /// </returns>
        private int [] MakeAttractorRing (int initialState, int rule)
        {
            int [] stateRing = new int [8];

            stateRing[0] = initialState;
            for (int i = 1; i < 8; ++i)
                stateRing[i] = NextState(stateRing[i - 1], rule);

            return stateRing;
        }

        /// <summary>
        /// Determine the next state of a "cell" using the current
        /// state value and the Wolfram rule number [0, 255].
        /// </summary>
        /// <param name="state">
        /// </param>
        /// <param name="rule">
        /// </param>
        /// <returns>
        /// A non-negative value of the next state [0, 255] given the
        /// current state and the cellular automata rule.
        /// </returns>
        private int NextState (int state, int rule)
        {
            if (state < 0 || state > 255 || rule < 0 || rule > 255)
                throw new System.ArgumentOutOfRangeException();

            // A state at i at time t+1, S_i^(t+1), is a function
            // of f(S_(i-1)^t, S_i^t, S_(i+1)^t).  i.e. we look
            // at the current "bit" and it's two neighbors at the
            // current time to derive the bit's value at the next iteration.

            // The finite cellular automata assumes a toroidal boundary
            // condition.  i.e. The state's left boundary is preceeded by
            // rightmost bit and the state's right boundary is followed by
            // the leftmost bit.  For example, using rule 42 with the
            // following table:
            //
            //     Neighborhood:  111 110 101 100 011 010 001 000
            //     Next State:     0   0   1   0   1   0   1   0    (42)
            //
            // For state = 166 (10100110, 0xa6), augment the 8-bit
            // representation with "wraparound" bits (for the torodial boundary
            // conditions) to the 10-bit value 0-10100110-1 where the leading 0
            // and trailing 1 are from the rightmost and leftmost bits,
            // respectively.  The rule 42 state transition shows that this
            // value becomes:
            //
            //    State: 010 101 010 100 001 011 110 101
            //    Next:   0   1   0   0   1   1   0   1    (0x4d, 77)
            //
            // Which has the decimal value of 77.

            int augmented_10_bit = (state << 1);
            augmented_10_bit |= ((state & 0x01) << 9) | ((state & 0x80) >> 7);

            // Convert the rule to an array where the index corresponds to
            // the 3-bit "neighborhood".  For example, for rule 42
            // ruleState[5] (101b) = 1b.
            int [] ruleState = new int[8];
            for (int i = 0; i < 8; ++i)
                ruleState[i] = ((rule & (1 << i)) >> i);

            int mask = 0x380;  // Corresponds to the binary: 11 1000 0000.
            int next = 0;

            for (int i = 0; i < 8; ++i)
            {
                // The index into the ruleState array representing
                // the 3-bit pattern.
                int patternIndex = (augmented_10_bit & mask) >> (7 - i);

                next |= (ruleState[patternIndex] << (7 - i));

                // Shift the mask to the 3-bit window of bits.
                mask >>= 1;
            }

            return next;
        }  // End method NextState().

    }  // End class CellularAutomataEncryptor.
}
