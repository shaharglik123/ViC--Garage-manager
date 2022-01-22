// <copyright file="GarageManager.cs" company="Shahar & Aviv">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Shahar & Aviv</author>

namespace Ex03.GarageLogic.GarageManagement
{
    using System;
    using System.Collections.Generic;
    using Ex03.GarageLogic.Enums;
    using Ex03.GarageLogic.Exceptions;
    using Ex03.GarageLogic.Vehicles;
    using Ex03.GarageLogic.VehiclesParts;

    /// <summary>   
    /// garage manager class 
    /// </summary>
    public class GarageManager
    {
        /// <summary>
        /// list of all the vehicle that are in the garage
        /// </summary>
        private readonly List<VehicleInTheGarage> r_VehiclesInTheGarage = new List<VehicleInTheGarage>();

        /// <summary>
        /// 1 - method - enters a vehicle to the garage
        /// </summary>
        public void enterACarToTheGarage()
        {
            string ownerName = string.Empty;
            int ownerNum = 0;
            string vehicleType = string.Empty;
            string engineType = string.Empty;
            Engine engine = null;
            Vehicle newVehicle = null;

            this.firstStageOfReceivingCar(ref ownerName, ref ownerNum, ref vehicleType);
            this.secondStageOfReceivingCar(ref newVehicle, ref vehicleType, ref engine, ref engineType, ref ownerName, ref ownerNum);
        }

        /// <summary>
        /// 2 - method - prints all vehicles license numbers that is in the garage
        /// </summary>
        public void printAllGarageVehicleLicenses()
        {
            Console.WriteLine("If you want to screen out vehicle by status enter vehicle status (Repaired, InRepair,Paid) to screen out or any other \nkeyword for all the cars: ");
            string sortStatus = this.GettingStringInput();
            foreach (VehicleInTheGarage vehicleInTheGarage in this.r_VehiclesInTheGarage)
            {
                if (sortStatus == "InRepair" && vehicleInTheGarage.VehicleStatus == eVehicleStatus.InRepair)
                {
                    Console.WriteLine(vehicleInTheGarage.Vehicle.LicensePlateNumber);
                }
                else if (sortStatus == "Repaired" && vehicleInTheGarage.VehicleStatus == eVehicleStatus.Repaired)
                {
                    Console.WriteLine(vehicleInTheGarage.Vehicle.LicensePlateNumber);
                }
                else if (sortStatus == "Paid" && vehicleInTheGarage.VehicleStatus == eVehicleStatus.Paid)
                {
                    Console.WriteLine(vehicleInTheGarage.Vehicle.LicensePlateNumber);
                }
                else if (sortStatus != "InRepair" && sortStatus != "Repaired" && sortStatus != "Paid")
                {
                    Console.WriteLine(vehicleInTheGarage.Vehicle.LicensePlateNumber);
                }
            }
        }

        /// <summary>
        /// 3 - method - update a vehicle status that is in the garage that is found by license number
        /// </summary>
        public void updateVehicleStatus()
        {
            Console.WriteLine("Enter a license plate number :");
            string licensePlateNumber = Console.ReadLine();

            bool vehicleFound = false;

            if (this.r_VehiclesInTheGarage.Count != 0)
            {
                while (vehicleFound == false)
                {
                    // if (!m_VehiclesInTheGarage.Contains(null))
                    // {
                    foreach (VehicleInTheGarage vehicleInTheGarage in this.r_VehiclesInTheGarage)
                    {
                        if (vehicleInTheGarage.Vehicle.LicensePlateNumber == licensePlateNumber)
                        {
                            vehicleFound = true;
                            Console.WriteLine("Enter status update :");
                            string statusUpdate = this.GettingStringInput();
                            if (statusUpdate == "InRepair")
                            {
                                vehicleInTheGarage.VehicleStatus = eVehicleStatus.InRepair;
                                Console.WriteLine("Status updated");
                            }
                            else if (statusUpdate == "Repaired")
                            {
                                vehicleInTheGarage.VehicleStatus = eVehicleStatus.Repaired;
                                Console.WriteLine("Status updated");
                            }
                            else if (statusUpdate == "Paid")
                            {
                                vehicleInTheGarage.VehicleStatus = eVehicleStatus.Paid;
                                Console.WriteLine("Status updated");
                            }
                            else
                            {
                                Console.WriteLine("There is no such status the status did not updated");
                            }
                        }
                    }

                    if (!vehicleFound)
                    {
                        Console.WriteLine("Could not find any vehicle please enter license plate number again :");
                        licensePlateNumber = Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("The garage is empty");
            }
        }

        /// <summary>
        /// 4 - method - filling a vehicle's wheels that is found by license number
        /// </summary>
        public void fillingVehicleWheels()
        {
            Console.WriteLine("Enter a license plate number to fill wheels:");
            string licensePlateNumber = this.GettingStringInput();
            bool vehicleFound = false;
            while (vehicleFound == false)
            {
                foreach (VehicleInTheGarage vehicleInTheGarage in this.r_VehiclesInTheGarage)
                {
                    if (vehicleInTheGarage.Vehicle.LicensePlateNumber == licensePlateNumber)
                    {
                        vehicleFound = true;
                        vehicleInTheGarage.Vehicle.Wheels[0].FillTire();
                        Console.WriteLine("Filled air in the wheel");
                    }
                }

                if (vehicleFound == false)
                {
                    Console.WriteLine("Could not find vehicle try again");
                    licensePlateNumber = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// 5 - method - filling a fueled vehicle in the garage that is found by license number
        /// </summary>
        public void fillingVehicleFuelTank()
        {
            Console.WriteLine("Enter a license plate number to fill fuel tank:");
            string licensePlateNumber = this.GettingStringInput();

            bool vehicleFound = false;
            while (!vehicleFound)
            {
                foreach (VehicleInTheGarage vehicleInTheGarage in this.r_VehiclesInTheGarage)
                {
                    if (vehicleInTheGarage.Vehicle.LicensePlateNumber == licensePlateNumber)
                    {
                        vehicleFound = true;

                        try
                        {
                            FuelEngine engine = (FuelEngine)vehicleInTheGarage.Vehicle.VehicleEngine;
                            Console.WriteLine("Enter vehicle's fuel type :");
                            string fuelType = this.GettingStringInput();
                            if (Enum.TryParse(fuelType, out eFuelType eFuelType)
                               && ((FuelEngine)vehicleInTheGarage.Vehicle.VehicleEngine).FuelType == eFuelType)
                            {
                                Console.WriteLine("Enter amount of fuel that you want too add :");
                                string amountOfFuel = this.GettingStringInput();
                                try
                                {
                                    float fAmountOfFuel = float.Parse(amountOfFuel);
                                    engine.FillFuel(fAmountOfFuel);
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Fuel type is wrong try again");
                            }
                        }
                        catch (Exception e)
                        {
                            e = new Exception("vehicle is not Fueled Type");
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                if (vehicleFound == false)
                {
                    Console.WriteLine("Could not find vehicle try again");
                    licensePlateNumber = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// 6 - method - charging an electric vehicle in the garage that is found by license number
        /// </summary>
        public void chargeBattery()
        {
            Console.WriteLine("Enter a license plate number to charge the cars battery:");
            string licensePlateNumber = this.GettingStringInput();
            bool vehicleFound = false;
            while (vehicleFound == false)
            {
                foreach (VehicleInTheGarage vehicleInTheGarage in this.r_VehiclesInTheGarage)
                {
                    if (vehicleInTheGarage.Vehicle.LicensePlateNumber == licensePlateNumber)
                    {
                        vehicleFound = true;
                        try
                        {
                            ElectricEngine electricEngine = (ElectricEngine)vehicleInTheGarage.Vehicle.VehicleEngine;
                            Console.WriteLine("Enter capacity of hours that you want to charge :");
                            string capacityToCharge = this.GettingStringInput();
                            try
                            {
                                float fCapacityToCharge = float.Parse(capacityToCharge);
                                electricEngine.ChargeBattery(fCapacityToCharge);
                            }
                            catch (FormatException e)
                            {
                                e = new FormatException("float input invalid");
                                Console.WriteLine(e.Message);
                            }
                        }
                        catch (Exception e)
                        {
                            e = new Exception("vehicle is not electric");
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                if (vehicleFound == false)
                {
                    Console.WriteLine("Could not find vehicle try again");
                    licensePlateNumber = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// 7 - method - prints all vehicle's information that is found by license number
        /// </summary>
        public void printGarageCarByLicense()
        {
            Console.WriteLine("Enter vehicle license plate number : ");
            string vehicleLicensePlateNumber = this.GettingStringInput();
            bool vehicleFound = false;
            while (vehicleFound == false)
            {
                foreach (VehicleInTheGarage vehicleInTheGarage in this.r_VehiclesInTheGarage)
                {
                    if (vehicleInTheGarage.Vehicle.LicensePlateNumber == vehicleLicensePlateNumber)
                    {
                        vehicleFound = true;
                        vehicleInTheGarage.Print();
                    }
                }

                Console.WriteLine();

                if (vehicleFound == false)
                {
                    Console.WriteLine("Could not find vehicle try again");
                    vehicleLicensePlateNumber = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// A method that sets the vehicle air pressure
        /// </summary>
        /// <param name="i_VehicleMaxAirPressure">input for setting the vehicle wheels' max pressure</param>
        /// <returns>return if the air pressure if the value entered in the method is valid </returns>
        public float setVehicleAirPressure(float i_VehicleMaxAirPressure)
        {
            float wheelCurrentAirPressure = 0;
            bool innerFlag = false;
            while (innerFlag == false)
            {
                Console.Write("Enter wheel's current air pressure :");
                try
                {
                    wheelCurrentAirPressure = this.GettingFloatInput();
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("wheels current air pressure set to default value - 0");
                    wheelCurrentAirPressure = 0;
                }

                if (wheelCurrentAirPressure > i_VehicleMaxAirPressure)
                {
                    Console.WriteLine(
                        new ValueOutOfRangeException(
                            i_VehicleMaxAirPressure,
                            0,
                            string.Format("Current air pressure cannot be higher than {0}.", i_VehicleMaxAirPressure)).Message);
                }
                else
                {
                    innerFlag = true;
                }
            }

            return wheelCurrentAirPressure;
        }

        /// <summary>
        /// A method used by creating a vehicle method for the first stage of receiving a vehicle
        /// </summary>
        /// <param name="i_OwnerName">input for owner name</param>
        /// <param name="i_OwnerNum">input for owner number</param>
        /// <param name="i_vehicleType">input for the vehicle type</param>
        private void firstStageOfReceivingCar(ref string i_OwnerName, ref int i_OwnerNum, ref string i_vehicleType)
        {
            Console.Write("Enter vehicle's ownerName : ");
            i_OwnerName = this.GettingStringInput();
            Console.Write("Enter vehicle's owner number : ");
            i_OwnerNum = this.GettingNumberInput();

            bool flag = true;
            Console.Write("Enter vehicle's Type (Car,Motorcycle,Truck) : ");
            while (flag)
            {
                i_vehicleType = this.GettingStringInput();
                if (i_vehicleType != "Car" && i_vehicleType != "Motorcycle" && i_vehicleType != "Truck")
                {
                    Exception e = new ArgumentException("Vehicle type is invalid, please try again");
                    Console.WriteLine(e.Message);
                }
                else
                {
                    flag = false;
                }
            }
        }

        /// <summary>
        /// A method used by creating a vehicle method for the second stage of receiving a vehicle
        /// </summary>
        /// <param name="i_NewVehicleInTheGarage">input vehicle reference to create the vehicle in the method</param>
        /// <param name="i_VehicleType">input vehicle type reference to create the vehicle type in the method</param>
        /// <param name="i_Engine">input vehicle' engine reference to create the vehicle's engine in the method</param>
        /// <param name="i_EngineType">input vehicle engine's type reference to create the vehicle engine's type in the method</param>
        /// <param name="i_OwnerName">input vehicle's owner name reference that passed from the first stage to create a new vehicle in the garage</param>
        /// <param name="i_OwnerNum">input vehicle's owner number reference that passed from the first stage to create a new vehicle in the garage</param>
        private void secondStageOfReceivingCar(ref Vehicle i_NewVehicleInTheGarage, ref string i_VehicleType, ref Engine i_Engine, ref string i_EngineType, ref string i_OwnerName, ref int i_OwnerNum)
        {
            float vehicleMaxAirPressure;
            Console.Write("Enter vehicle's model name :");
            string modelName = this.GettingStringInput();
            Console.Write("Enter vehicle's license number :");
            string licensePlateNumber = Console.ReadLine();
            foreach (VehicleInTheGarage vehicleInTheGarage in this.r_VehiclesInTheGarage)
            {
                if (licensePlateNumber == vehicleInTheGarage.Vehicle.LicensePlateNumber)
                {
                    vehicleInTheGarage.VehicleStatus = eVehicleStatus.InRepair;
                    Console.WriteLine("Car is already exist in the garage, status updated to InRepair.");
                    return;
                }
            }

            Console.WriteLine("Enter the wheel's specifications");
            Console.Write("Enter wheel's manufacturer : ");
            string manufacturerName = this.GettingStringInput();

            Wheel receivingVehicleWheel;
            bool flag;
            float currentAirPressure;
            switch (i_VehicleType)
            {
                case "Car":
                    vehicleMaxAirPressure = 29;
                    currentAirPressure = this.setVehicleAirPressure(vehicleMaxAirPressure);
                    receivingVehicleWheel = new Wheel(manufacturerName, vehicleMaxAirPressure, currentAirPressure);
                    Console.Write("Enter Car's door's colors (Red,White,Black) : ");
                    string carsColor = this.GettingStringInput();
                    eCarColor carColor = 0;
                    flag = true;
                    while (flag)
                    {
                        if (Enum.TryParse(carsColor, out carColor))
                        {
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Car's input Color is invalid try again");
                            carsColor = Console.ReadLine();
                        }
                    }

                    Console.Write("Enter car's amount of doors (2,3,4 or 5): ");
                    string amountOfDoors = Console.ReadLine();
                    eAmountOfDoors carAmountOfDoors = 0;
                    flag = true;
                    while (flag)
                    {
                        if (Enum.TryParse(amountOfDoors, out carAmountOfDoors))
                        {
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Car's amount of door is invalid try again");
                            amountOfDoors = this.GettingStringInput();
                        }
                    }

                    flag = true;
                    Console.WriteLine("Is the car electric or fuel based : F for fuel and E for electric");
                    while (flag)
                    {
                        i_EngineType = Console.ReadLine();
                        if (i_EngineType == "F" || i_EngineType == "E")
                        {
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Car's Engine type  is invalid try again");
                        }
                    }

                    this.gettingEngine(i_EngineType, ref i_Engine);
                    i_NewVehicleInTheGarage = new Car(modelName, licensePlateNumber, receivingVehicleWheel, i_Engine, carColor, carAmountOfDoors);
                    break;
                case "Motorcycle":
                    vehicleMaxAirPressure = 30;
                    currentAirPressure = this.setVehicleAirPressure(vehicleMaxAirPressure);
                    receivingVehicleWheel = new Wheel(manufacturerName, vehicleMaxAirPressure, currentAirPressure);
                    eLicenseType motorLicenseType = 0;
                    flag = true;
                    while (flag)
                    {
                        Console.Write("Enter motorcycle's license type (AA,A2,AA,B ) : ");
                        string licenseType = Console.ReadLine();
                        if (Enum.TryParse(licenseType, out motorLicenseType))
                        {
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("license type is invalid try again");
                        }
                    }

                    Console.Write("Enter motorcycle's engine capacity number: ");
                    int engineCapacity = 0;
                    try
                    {
                        engineCapacity = this.GettingNumberInput();
                    }
                    catch (Exception e)
                    {
                        e = new FormatException("engine capacity enter is invalid number");
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine("Is the motorcycle electric or fuel based - E for electric F for fuel ");
                    flag = true;
                    while (flag)
                    {
                        i_EngineType = Console.ReadLine();
                        if (i_EngineType == "F" || i_EngineType == "E")
                        {
                            flag = false;
                        }
                        else
                        {
                            Console.WriteLine("Motorcycle's Engine type  is invalid try again");
                        }
                    }

                    this.gettingEngine(i_EngineType, ref i_Engine);
                    i_NewVehicleInTheGarage = new Motorcycle(modelName, licensePlateNumber, receivingVehicleWheel, i_Engine, motorLicenseType, engineCapacity);
                    break;
                case "Truck":
                    vehicleMaxAirPressure = 25;
                    currentAirPressure = this.setVehicleAirPressure(vehicleMaxAirPressure);
                    receivingVehicleWheel = new Wheel(manufacturerName, vehicleMaxAirPressure, currentAirPressure);
                    Console.Write("Does the truck Drives refrigerated contents: (yes or no) ");
                    bool boolDrivesRefrigeratedContents = false;
                    flag = true;
                    while (flag)
                    {
                        string drivesRefrigeratedContents = this.GettingStringInput();
                        if (drivesRefrigeratedContents == "yes")
                        {
                            boolDrivesRefrigeratedContents = true;
                            flag = false;
                        }
                        else if (drivesRefrigeratedContents == "no")
                        {
                            flag = false;
                        }
                        else if (drivesRefrigeratedContents != "no" && drivesRefrigeratedContents != "yes")
                        {
                            Console.WriteLine("Entered invalid answer try again");
                        }
                    }

                    flag = true;
                    while (flag)
                    {
                        Console.Write("Enter truck's cargo capacity: ");
                        try
                        {
                            int cargoCapacity = this.GettingNumberInput();
                            flag = false;
                            this.gettingEngine("F", ref i_Engine);
                            i_NewVehicleInTheGarage = new Truck(modelName, licensePlateNumber, receivingVehicleWheel, i_Engine, boolDrivesRefrigeratedContents, cargoCapacity);
                        }
                        catch (Exception e)
                        {
                            e = new ArgumentException("you enter invalid number, please try again");
                            Console.WriteLine(e.Message);
                        }
                    }

                    break;
            }

            this.r_VehiclesInTheGarage.Add(
                new VehicleInTheGarage(i_NewVehicleInTheGarage, i_OwnerName, i_OwnerNum, eVehicleStatus.InRepair));
            Console.WriteLine("Vehicle has added to the garage. . . .");
            Console.WriteLine("================================================================================");
        }

        /// <summary>
        /// A method that create and gets the engine for the creation of a new vehicle
        /// </summary>
        /// <param name="i_EngineType">input from the second stage of the engine type for the creation in the getting engine method</param>
        /// <param name="i_Engine">input from the second stage of the engine member for the creation in the getting engine method</param>
        private void gettingEngine(string i_EngineType, ref Engine i_Engine)
        {
            bool flag = false;
            while (flag == false)
            {
                switch (i_EngineType)
                {
                    case "F":
                        flag = true;
                        bool innerFlag = true;
                        string fuelType = string.Empty;
                        float fCurrentFuelTankCapacity = 0;
                        float fMaxFuelTankCapacity = 0;
                        while (innerFlag)
                        {
                            Console.Write("Enter fuel type : (Soler ,Octan95 ,Octan96 ,Octan98 )");
                            fuelType = this.GettingStringInput();
                            if (fuelType != "Soler" && fuelType != "Octan95" && fuelType != "Octan96"
                               && fuelType != "Octan98")
                            {
                                Exception e = new ArgumentException("Fuel type is invalid, please try again");
                                Console.WriteLine(e.Message);
                            }
                            else
                            {
                                innerFlag = false;
                            }
                        }

                        innerFlag = true;
                        while (innerFlag)
                        {
                            Console.Write("Enter max fuel tank capacity :");
                            string maxFuelTankCapacity = Console.ReadLine();
                            fMaxFuelTankCapacity = 0;
                            try
                            {
                                fMaxFuelTankCapacity = float.Parse(maxFuelTankCapacity);
                                innerFlag = false;
                            }
                            catch (Exception e)
                            {
                                e = new FormatException("you entered invalid number ");
                                Console.WriteLine(e.Message);
                            }
                        }

                        innerFlag = true;
                        while (innerFlag)
                        {
                            Console.Write("Enter current fuel tank capacity :");
                            string currentFuelTankCapacity = Console.ReadLine();
                            fCurrentFuelTankCapacity = 0;
                            try
                            {
                                fCurrentFuelTankCapacity = float.Parse(currentFuelTankCapacity);
                                if (fCurrentFuelTankCapacity <= fMaxFuelTankCapacity && fCurrentFuelTankCapacity >= 0)
                                {
                                    innerFlag = false;
                                }
                                else
                                {
                                    Console.WriteLine("current tank input capacity is greater then maximum \ncapacity or less then zero, try entering a number again");
                                }
                            }
                            catch (Exception e)
                            {
                                e = new FormatException("you entered invalid number ");
                                Console.WriteLine(e.Message);
                            }
                        }

                        switch (fuelType)
                        {
                            case "Soler":
                                i_Engine = new FuelEngine(fMaxFuelTankCapacity, fCurrentFuelTankCapacity, eFuelType.Soler);
                                break;
                            case "Octan95":
                                i_Engine = new FuelEngine(
                                    fMaxFuelTankCapacity,
                                    fCurrentFuelTankCapacity,
                                    eFuelType.Octan95);
                                break;
                            case "Octan96":
                                i_Engine = new FuelEngine(
                                    fMaxFuelTankCapacity,
                                    fCurrentFuelTankCapacity,
                                    eFuelType.Octan96);
                                break;
                            case "Octan98":
                                i_Engine = new FuelEngine(
                                    fMaxFuelTankCapacity,
                                    fCurrentFuelTankCapacity,
                                    eFuelType.Octan98);
                                break;
                            default:
                                Console.WriteLine("your enter invalid number");
                                break;
                        }

                        break;
                    case "E":
                        flag = true;
                        innerFlag = true;
                        float fMaximumBatteryCapacity = 0;
                        float fCurrentBatteryCapacity = 0;
                        while (innerFlag)
                        {
                            try
                            {
                                Console.Write("Enter battery maximum energy capacity (hours) :");
                                string maximumBatteryCapacity = Console.ReadLine();
                                fMaximumBatteryCapacity = float.Parse(maximumBatteryCapacity);
                                innerFlag = false;
                            }
                            catch (FormatException e)
                            {
                                e = new FormatException("float input invalid");
                                Console.WriteLine(e.Message);
                            }
                        }

                        innerFlag = true;
                        while (innerFlag)
                        {
                            try
                            {
                                Console.Write("Enter battery remaining energy (hours) :");
                                string currentBatteryCapacity = Console.ReadLine();
                                fCurrentBatteryCapacity = float.Parse(currentBatteryCapacity);

                                if (fCurrentBatteryCapacity <= fMaximumBatteryCapacity)
                                {
                                    innerFlag = false;
                                }
                                else
                                {
                                    Console.WriteLine("The current battery capacity cannot be greater than " + fMaximumBatteryCapacity);
                                }
                            }
                            catch (Exception e)
                            {
                                e = new FormatException("float input invalid");
                                Console.WriteLine(e.Message);
                            }

                            i_Engine = new ElectricEngine(fMaximumBatteryCapacity, fCurrentBatteryCapacity);
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Gets string and check validation and return the string
        /// </summary>
        /// <returns>return the string after validation check</returns>
        private string GettingStringInput()
        {
            bool flag = true;
            string inputString = string.Empty;
            while (flag)
            {
                flag = false;
                inputString = Console.ReadLine();
                if (inputString != string.Empty)
                {
                    foreach (char c in inputString)
                    {
                        if (!char.IsLetter(c))
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        Console.WriteLine("invalid string input try again");
                    }
                }
                else
                {
                    Console.WriteLine("you entered empty string, try again");
                    flag = true;
                }
            }

            return inputString;
        }

        /// <summary>
        /// Gets integer and check validation and return the integer
        /// </summary>
        /// <returns>return the integer after validation check</returns>
        private int GettingNumberInput()
        {
            bool flag = true;
            string inputString = string.Empty;
            while (flag)
            {
                flag = false;
                inputString = Console.ReadLine();
                if (inputString != string.Empty)
                {
                    foreach (char c in inputString)
                    {
                        if (!char.IsDigit(c))
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        Console.WriteLine("invalid number input try again");
                    }
                }
                else
                {
                    Console.WriteLine("you entered empty string, try again");
                    flag = true;
                }
            }

            int inputNumber = int.Parse(inputString);
            return inputNumber;
        }

        /// <summary>
        /// Gets float and check validation and return the float
        /// </summary>
        /// <returns> return a float if valid</returns>
        private int GettingFloatInput()
        {
            bool flag = true;
            string inputStringToFloat = string.Empty;
            while (flag)
            {
                flag = false;
                inputStringToFloat = Console.ReadLine();
                if (inputStringToFloat != string.Empty)
                {
                    foreach (char c in inputStringToFloat)
                    {
                        if (!char.IsDigit(c))
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        Console.WriteLine("invalid number input try again");
                    }
                }
                else
                {
                    Console.WriteLine("you entered empty string, try again");
                    flag = true;
                }
            }

            int inputFloat = int.Parse(inputStringToFloat);
            return inputFloat;
        }
    }
}