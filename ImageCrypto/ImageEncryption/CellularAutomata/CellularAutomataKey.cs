//-----------------------------------------------------------------------------
// <author>Gary Hammock, PE</author>
// <date>2016-03-14</date>
//-----------------------------------------------------------------------------
// <summary>
// This file contains the implementation details of the Cellular Automata
// image encryption keys for use with the
// <see cref="CellularAutomataEncryptor" />.
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

namespace ImageEncryption.CellularAutomata
{
    public class CellularAutomataKey
    {
        /**************************************************
        *                 Private Fields                  *
        **************************************************/

        private int rule;
        private int seed;
        private int state1;

        /**************************************************
        *                  Constructors                   *
        **************************************************/

        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public CellularAutomataKey()
            : this(0, 0, (int)System.DateTime.Now.Ticks)
        { }

        /// <summary>
        /// Partial initialization constructor.  When the seed value is not
        /// specified, the seed is set as the current
        /// <see cref="System.DateTime.Now.Ticks" /> value.
        /// </summary>
        /// <param name="rule">
        /// A non-negative integer in [0, 255] specifying the Wolfram rule
        /// number for the cellular automata set.
        /// </param>
        /// <param name="initialState">
        /// A non-negative integer in [0, 255] specifying the initial state
        /// value to use.  Cellular automata encryption exploits the attractors
        /// in the rulesets to provide symmetric encryption and decryption.
        /// The initial state sets which attractor "ring" the system uses.
        /// </param>
        public CellularAutomataKey(int rule, int initialState)
            : this(rule, initialState, (int)System.DateTime.Now.Ticks)
        { }

        /// <summary>
        /// Partial initialization constructor.  When the seed value is not
        /// specified, the seed is set as the current
        /// <see cref="System.DateTime.Now.Ticks" /> value.
        /// </summary>
        /// <param name="rule">
        /// A non-negative integer in [0, 255] specifying the Wolfram rule
        /// number for the cellular automata set.
        /// </param>
        /// <param name="initialState">
        /// A non-negative integer in [0, 255] specifying the initial state
        /// value to use.  Cellular automata encryption exploits the attractors
        /// in the rulesets to provide symmetric encryption and decryption.
        /// The initial state sets which attractor "ring" the system uses.
        /// </param>
        /// <param name="seed">
        /// A desired seed value passed to <see cref="System.Random" /> to
        /// use for generating key schedules .
        /// </param>
        public CellularAutomataKey(int rule, int initialState, int seed)
        {
            Rule = rule;
            StateOne = initialState;
            Seed = seed;
        }

        /**************************************************
        *                   Properties                    *
        **************************************************/

        /// <summary>
        /// A non-negative integer in [0, 255] specifying the Wolfram rule
        /// number for the cellular automata set.
        /// </summary>
        public int Rule
        {
            get { return rule; }
            set
            {
                if (value >= 0 && value < 256)
                    rule = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// A desired seed value passed to <see cref="System.Random" /> to
        /// use for generating key schedules .
        /// </summary>
        public int Seed
        {
            get { return seed; }
            set { seed = value; }
        }

        /// <summary>
        /// A non-negative integer in [0, 255] specifying the initial state
        /// value to use.  Cellular automata encryption exploits the attractors
        /// in the rulesets to provide symmetric encryption and decryption.
        /// The initial state sets which attractor "ring" the system uses.
        /// </summary>
        public int StateOne
        {
            get { return state1; }
            set
            {
                if (value < 0 || value > 255)
                    throw new System.ArgumentOutOfRangeException();
                else
                    state1 = value;
            }
        }

        /**************************************************
        *                 Public Methods                  *
        **************************************************/

        /// <summary>
        /// Generates a new CellularAutomataKey object.
        /// </summary>
        /// <returns>
        /// A new CellularAutomataKey object with random values.
        /// </returns>
        public static CellularAutomataKey Generate()
        {
            return Generate((int)System.DateTime.Now.Ticks);
        }

        /// <summary>
        /// Generates a new CellularAutomataKey object.
        /// </summary>
        /// <param name="seed">
        /// A desired seed value passed to <see cref="System.Random" /> to
        /// use for generating key schedules .
        /// </param>
        /// <returns>
        /// A new CellularAutomataKey object with random values
        /// determined from the specified seed.
        /// </returns>
        public static CellularAutomataKey Generate(int seed)
        {
            Random rand = new Random(seed);

            CellularAutomataKey newKey = 
                new CellularAutomataKey(rand.Next(0, 255),  // rule
                                        rand.Next(0, 255),  // initialState
                                        seed);              // seed

            return newKey;
        }

        /// <summary>
        /// Creates a new CellularAutomataKey with the same
        /// values as the calling object.
        /// </summary>
        /// <returns>
        /// A new CellularAutomataKey object cloned from the caller.
        /// </returns>
        public CellularAutomataKey Clone()
        {
            return new CellularAutomataKey(rule, state1, seed);
        }

    }  // End class CellularAutomataKey.
}