#region filename
/// FluidDynamicsKey.cs
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
    /// <summary>
    /// This class stores and provides accessors/mutators for the
    /// fluid-dynamics inspired image encryption technique.
    /// </summary>
    public class FluidDynamicsKey
    {
        /// <summary>
        /// This is the secret image that will be XOR-ed
        /// with the intermediate image.
        /// </summary>
        public Bitmap SecretImage;

        /**************************************************
        *                 Private Fields                  *
        **************************************************/

        // Growth rate coefficient for the mass flow rate logistic map.
        private double r_mdot;

        // Growth rate coefficient for the heat transfer logistic map.
        private double r_qdot;

        private byte k0;      // The initial "turbulence energy".
        private byte epsilon; // The "dissipation rate" for the decay function.
        private byte tFrame;  // The "time snapshot" to read K.

        private double mDotKey;  // Feeds the "mass flow rate" key expansion.
        private double qDotKey;  // Feeds the "heat flux" key expansion.

        /**************************************************
        *                  Constructors                   *
        **************************************************/

        /// <summary>
        /// Empty constructor for manual setup.
        /// </summary>
        public FluidDynamicsKey()
        { }

        /// <summary>
        /// Initializer constructor.
        /// </summary>
        /// <param name="r_mdot">
        /// The growth rate parameter for the mass flow rate logistic map.
        /// </param>
        /// <param name="massFlowRateInitializer">
        /// Initializes the "mass flow rate" key expansion.
        /// </param>
        /// <param name="r_qdot">
        /// Growth rate coefficient for the heat transfer logistic map.
        /// </param>
        /// <param name="heatTransferInitializer">
        /// Initializers the "heat flux" key expansion.
        /// </param>
        /// <param name="k0">
        /// The initial "turbulent kinetic energy".
        /// </param>
        /// <param name="epsilon">
        /// The "turbulent kinetic energy dissipation rate" for
        /// the decay function.
        /// </param>
        /// <param name="tframe">
        /// The "time snapshot" to read K.
        /// </param>
        /// <param name="secretImage">
        /// This is the secret image that will be XOR-ed
        /// with the intermediate image.
        /// </param>
        public FluidDynamicsKey(
            double r_mdot, double massFlowRateInitializer,
            double r_qdot, double heatTransferInitializer,
            byte k0, byte epsilon,
            byte tframe, Bitmap secretImage)
        {
            R_mdot = r_mdot;
            R_qdot = r_qdot;
            mDotKey = massFlowRateInitializer;
            qDotKey = heatTransferInitializer;
            K0 = k0;
            Epsilon = epsilon;
            TFrame = tframe;
            SecretImage = (Bitmap)secretImage.Clone();
        }

        /**************************************************
        *                   Properties                    *
        **************************************************/

        /// <summary>
        /// The growth rate coefficient (3.569955672, 4]
        /// of the row mutation logistic map.
        /// </summary>
        public Double R_mdot
        {
            get { return r_mdot; }
            set
            {
                if (ValidDomain(value))
                    r_mdot = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The growth rate coefficient (3.569955672, 4]
        /// of the column mutation logistic map.
        /// </summary>
        public Double R_qdot
        {
            get { return r_qdot; }
            set
            {
                if (ValidDomain(value))
                    r_qdot = value;
                else
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The initializer for the "mass flow rate" key expansion.
        /// </summary>
        public Double MassFlowRateInitializer
        {
            get { return mDotKey; }
            set
            {
                if (mDotKey < 0.0 || mDotKey > 1.0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    mDotKey = value;
            }
        }

        /// <summary>
        /// The initializer for the "heat flux" key expansion.
        /// </summary>
        public Double HeatTransferInitializer
        {
            get { return qDotKey; }
            set
            {
                if (qDotKey < 0.0 || qDotKey > 1.0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    qDotKey = value;
            }
        }

        /// <summary>
        /// The initial "turbulent kinetic energy".
        /// </summary>
        public byte K0
        {
            get { return k0; }
            set
            {
                if (value < 0 || value > 255)
                    throw new System.ArgumentOutOfRangeException();
                else
                    k0 = value;
            }
        }

        /// <summary>
        /// The "turbulent kinetic energy dissipation rate" for
        /// the decay function.
        /// </summary>
        public byte Epsilon
        {
            get { return epsilon; }
            set
            {
                if (value < 0 || value > 255)
                    throw new System.ArgumentOutOfRangeException();
                else if (k0 < value)
                {
                    throw new System.ArgumentException(
                        "Epsilon must be less than K0.");
                }
                else
                    epsilon = value;
            }
        }

        /// <summary>
        /// The "time snapshot" to read K.
        /// </summary>
        public byte TFrame
        {
            get { return tFrame; }
            set
            {
                if (value < 0 || value > 255)
                    throw new System.ArgumentOutOfRangeException();
                else
                    tFrame = value;
            }
        }

        /**************************************************
        *                 Public Methods                  *
        **************************************************/

        /// <summary>
        /// Checks that all of the stored values indicate a
        /// valid FluidDynamicsKey object.
        /// </summary>
        /// <returns>
        /// True if the values represent a valid key; false otherwise.
        /// </returns>
        public bool IsValidKey ()
        {
            if (epsilon < k0 && ValidDomain(r_mdot) && ValidDomain(r_qdot))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Creates a clone of this FluidDynamicsKey object.
        /// </summary>
        /// <returns>
        /// A new FluidDynamicsKey object whose values are
        /// copied from the calling object.
        /// </returns>
        public FluidDynamicsKey Clone()
        {
            FluidDynamicsKey newKey = new FluidDynamicsKey(
                this.r_mdot, this.mDotKey, this.r_qdot, this.qDotKey,
                this.k0, this.epsilon, this.tFrame, this.SecretImage);

            return newKey;
        }

        /// <summary>
        /// Generates a new random key that is within the valid keyspace.
        /// </summary>
        /// <returns>
        /// A new FluidDyanmicsKey object whose values are within the
        /// correct logistic map keyspace.
        /// </returns>
        public static FluidDynamicsKey Generate()
        { 
            FluidDynamicsKey newKey = new FluidDynamicsKey();
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

    }  // End class Fluid Dynamics Key.
}
