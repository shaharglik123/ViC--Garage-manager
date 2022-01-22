// <copyright file="FuelEngine.cs" company="Shahar & Aviv">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Shahar & Aviv</author>

namespace Ex03.GarageLogic.Vehicles
{
    using Ex03.GarageLogic.Exceptions;
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.VehiclesParts;
    using System;

    /// <summary>
    /// Fuel engine class
    /// </summary>
    public class FuelEngine : Engine
    {
        /// <summary>
        /// engine's fuel type
        /// </summary>
        private readonly eFuelType r_FuelType;

        /// <summary>
        /// Initializes a new instance of the  <see cref="FuelEngine"/> class.
        /// </summary>
        /// <param name="i_MaximumTankCapacity">input engine's maximum tank capacity</param>
        /// <param name="i_CurrentTankCapacity">input engine's current tank capacity</param>
        /// <param name="i_FuelType">input engine's fuel type</param>
        internal FuelEngine(float i_MaximumTankCapacity, float i_CurrentTankCapacity, eFuelType i_FuelType)
        {
            this.MaximumEnergy = i_MaximumTankCapacity;
            this.CurrentEnergy = i_CurrentTankCapacity;
            this.r_FuelType = i_FuelType;
        }

        /// <summary>
        /// Gets the fuel type
        /// </summary>
        public eFuelType FuelType
        {
            get { return this.r_FuelType; }
        }

        /// <summary>
        /// method that fills fuel with input amount
        /// </summary>
        /// <param name="i_Liters">input amount of litters to add to the tank</param>
        public void FillFuel(float i_Liters)
        {
            if (i_Liters < 0)
            {
                Console.WriteLine(new ValueOutOfRangeException(this.MaximumEnergy, 0, "input fuel amount can not bw less then 0.").Message);
            }
            else if (this.CurrentEnergy + i_Liters > this.MaximumEnergy)
            {
                Console.WriteLine(new ValueOutOfRangeException(this.MaximumEnergy, 0, string.Format("Maximum fuel cannot be higher than {0}, current fuel amount is {1}.", this.MaximumEnergy, this.CurrentEnergy)).Message);
            }
            else
            {
                this.CurrentEnergy += i_Liters;
                Console.WriteLine("Fuel filled");
            }
        }

        /// <summary>
        /// print method that prints the fuel engine object
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("The current fuel amount is : {0} liters.\nThe maximum fuel amount possible is : {1} Liters.\nThe fuel percentage is {2}% and the type of fuel is {3},", this.CurrentEnergy, this.MaximumEnergy, EnergyPercentage, this.FuelType);
        }
    }
}
