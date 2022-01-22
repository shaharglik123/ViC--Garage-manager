// <copyright file="ElectricEngine.cs" company="Shahar & Aviv">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Shahar & Aviv</author>

namespace Ex03.GarageLogic.Vehicles
{
    using System;
    using Ex03.GarageLogic.VehiclesParts;

    /// <summary>
    /// Electric engine class
    /// </summary>
    public class ElectricEngine : Engine
    {
        /// <summary>
        /// Initializes a new instance of the  <see cref="ElectricEngine"/> class.
        /// </summary>
        /// <param name="i_MaximumBatteryTime">input engine's maximum battery capacity</param>
        /// <param name="i_RemainingBatteryTime">input engine's current battery capacity</param>
        internal ElectricEngine(float i_MaximumBatteryTime, float i_RemainingBatteryTime)
        {
            this.MaximumEnergy = i_MaximumBatteryTime;
            this.CurrentEnergy = i_RemainingBatteryTime;
        }

        /// <summary>
        /// method to charge battery with how many hours to charge input
        /// </summary>
        /// <param name="i_HoursToCharge">input of how many hours do you want to charge the battery</param>
        public void ChargeBattery(float i_HoursToCharge)
        {
            if (i_HoursToCharge < 0)
            {
                ArgumentException e = new ArgumentException("Hours can not be lass then 0");
                Console.WriteLine(e.Message);
            }
            else if (this.CurrentEnergy + i_HoursToCharge > this.MaximumEnergy)
            {
                ArgumentException e = new ArgumentException("The current energy that you want is more then the maximum capacity try recharging again");
                Console.WriteLine(e.Message);
            }
            else
            {
                this.CurrentEnergy += i_HoursToCharge;
                Console.WriteLine("Battery Charged");
            }
        }

        /// <summary>
        /// print method that prints the electric engine object
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("The current battery capacity is : {0} hours.\nThe maximum battery capacity possible is : {1} hours.\nThe battery percentage is {2}%.", this.CurrentEnergy, this.MaximumEnergy, this.EnergyPercentage);
        }
    }
}
