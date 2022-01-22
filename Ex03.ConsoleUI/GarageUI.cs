// <copyright file="GarageManager.cs" company="Shahar & Aviv">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Shahar & Aviv</author>
namespace Ex03.ConsoleUI
{
    using System;
    using GarageLogic.GarageManagement;
    public class GarageUI
    {
        public void MainMenu()
        {
            bool flag = true;
            GarageManager garageManager = new GarageManager();

            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Add new Car");
                Console.WriteLine("2) Showing all the vehicles licenses number by garage status ");
                Console.WriteLine("3) Changing vehicle status ");
                Console.WriteLine("4) Filling wheels in a vehicle by license number");
                Console.WriteLine("5) Fuel filling");
                Console.WriteLine("6) Battery charging");
                Console.WriteLine("7) Search a vehicle by license");
                Console.WriteLine("Q) to exit the program");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        garageManager.enterACarToTheGarage();
                        break;
                    case "2":
                        garageManager.printAllGarageVehicleLicenses();
                        break;
                    case "3":
                        garageManager.updateVehicleStatus();
                        break;
                    case "4":
                        garageManager.fillingVehicleWheels();
                        break;
                    case "5":
                        garageManager.fillingVehicleFuelTank();
                        break;
                    case "6":
                        garageManager.chargeBattery();
                        break;
                    case "7":
                        garageManager.printGarageCarByLicense();
                        break;
                    case "Q":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("input entered is invalid");
                        Console.ReadKey();
                        break;
                }
                if (flag)
                {

                    Console.WriteLine("press any key to go back to the menu. . . .");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Bye");
                }
            }
        }
    }
}
