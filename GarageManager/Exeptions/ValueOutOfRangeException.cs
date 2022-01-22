// <copyright file="ValueOutOfRangeException.cs" company="Shahar & Aviv">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Shahar & Aviv</author>

namespace Ex03.GarageLogic.Exceptions
{
    using System;

    /// <summary>
    /// ValueOutOfRangeException exception class
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        /// <summary>
        /// maximum member for exception
        /// </summary>
        private readonly float r_MaximumValue;

        /// <summary>
        /// minimum member for for the exception
        /// </summary>
        private readonly float r_MinimumValue;

        /// <summary>
        /// Initializes a new instance of the  <see cref="ValueOutOfRangeException"/> class.
        /// </summary>
        /// <param name="i_MaximumValue">input maximum value</param>
        /// <param name="i_MinimumValue">input minimum value</param>
        /// <param name="i_Msg">input message for the exception</param>
        public ValueOutOfRangeException(float i_MaximumValue, float i_MinimumValue, string i_Msg)
            : base(i_Msg)
        {
            this.r_MaximumValue = i_MaximumValue;
            this.r_MinimumValue = i_MinimumValue;
        }

        /// <summary>
        /// Gets the maximum member value
        /// </summary>
        public float MaximumValue
        {
            get { return this.r_MaximumValue; }
        }

        /// <summary>
        /// Gets the minimum member value
        /// </summary>
        public float MinimumValue
        {
            get { return this.r_MinimumValue; }
        }
    }
}