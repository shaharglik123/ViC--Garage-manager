// <copyright file="VehicleInTheGarage.cs" company="Shahar & Aviv">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Shahar & Aviv</author>

namespace Ex03.GarageLogic.GarageManagement
{
    using System;
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Vehicles;

    /// <summary>
    /// VehicleInTheGarage class
    /// </summary>
    public class VehicleInTheGarage
    {
        /// <summary>
        /// The vehicle in the garage owner name
        /// </summary>
        private string m_OwnerName;

        /// <summary>
        /// The vehicle in the garage in the garage owner number
        /// </summary>
        private int m_OwnerNumber;

        /// <summary>
        /// The vehicle in the garage in the garage status
        /// </summary>
        private eVehicleStatus m_VehicleStatus;

        /// <summary>
        /// The vehicle in the garage in the garage's vehicle
        /// </summary>
        private Vehicle m_Vehicle;

        /// <summary>
        /// Initializes a new instance of the  <see cref="VehicleInTheGarage"/> class.
        /// </summary>
        /// <param name="i_Vehicle">input vehicle in the garage's vehicle</param>
        /// <param name="i_OwnerName">input vehicle in the garage owner name</param>
        /// <param name="i_OwnerNumber">input vehicle in the garage owner number</param>
        /// <param name="i_VehicleStatus">input vehicle in the garage status</param>
        public VehicleInTheGarage(Vehicle i_Vehicle, string i_OwnerName, int i_OwnerNumber, eVehicleStatus i_VehicleStatus)
        {
            this.m_Vehicle = i_Vehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerNumber = i_OwnerNumber;
            this.m_VehicleStatus = i_VehicleStatus;
        }

        /// <summary>
        /// Gets or sets the vehicle in the garage owner name
        /// </summary>
        public string OwnerName
        {
            get => this.m_OwnerName;
            set => this.m_OwnerName = value;
        }

        /// <summary>
        ///  Gets or sets the vehicle in the garage owner number
        /// </summary>
        public int OwnerNumber
        {
            get => this.m_OwnerNumber;
            set => this.m_OwnerNumber = value;
        }

        /// <summary>
        ///  Gets or sets the vehicle in the garage status
        /// </summary>
        public eVehicleStatus VehicleStatus
        {
            get => this.m_VehicleStatus;
            set => this.m_VehicleStatus = value;
        }

        /// <summary>
        ///  Gets or sets the vehicle in the garage vehicle
        /// </summary>
        public Vehicle Vehicle
        {
            get => this.m_Vehicle;
            set => this.m_Vehicle = value;
        }

        /// <summary>
        /// print method that prints the VehicleInTheGarage object
        /// </summary>
        internal void Print()
        {
            string vehiclePrint = string.Format(
                "Vehicle owner information :\n"
                + "Vehicle owner name :{0}\n"
                + "Vehicle owner number :{1}\n"
                + "Vehicle current status :{2}\n",
                this.m_OwnerName,
                this.m_OwnerNumber,
                this.m_VehicleStatus.ToString());
            Console.WriteLine(vehiclePrint);
            this.m_Vehicle.Print();
        }
    }
}