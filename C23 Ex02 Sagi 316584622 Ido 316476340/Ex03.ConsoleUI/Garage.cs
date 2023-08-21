using Ex03.GarageLogic;
using Ex03.GarageLogic.Electric;
using Ex03.GarageLogic.Fuel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Fuel.FuelVehicles;

namespace Ex03.ConsoleUI
{
    internal class Garage
    {
        private List <VehicleInGarage> m_ArrayVehicle = new List<VehicleInGarage>();
        private string m_Message;
        private string m_LicenseNumberToCheck;
        private string choice;

        public bool CheckValidLicenseNumber(ref string licenseNumberToCheck)
        {
            try
            {
                int number = int.Parse(licenseNumberToCheck);
            }
            catch (ArgumentException ex)
            {
                m_Message = string.Format("Invalid license number");
                Console.WriteLine(m_Message);
                return false;
            }
            return true;
        }
        public bool SerachLicenseNumber(ref string i_licenseNumberToCheck, ref VehicleInGarage o_Vehicle)
        {
            foreach (VehicleInGarage vehicle in m_ArrayVehicle)
            {
                if (string.Equals(vehicle.MyVehicle.LicenseNumber, i_licenseNumberToCheck))
                {
                    o_Vehicle = vehicle;
                    return true;    
                }
            }
            return false;
        }
        public bool ChoosVehicleType(ref VehicleInGarage o_NewVehicle)
        {
            
            m_Message = string.Format(@"Please choose the vehicle type
1. Fuel car
2. Fuel motorcycle
3. Electric car
4. Electric motorcycle
5. Truck");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                    case "Fuel car":
                        {
                            o_NewVehicle.MyVehicle = new FuelCar();
                            return true;
                        }
                    case "2":
                    case "Fuel motorcycle":
                        {
                            o_NewVehicle.MyVehicle = new FuelMotorcycle();
                            return true;
                        }
                    case "3":
                    case "Electric car":
                        {
                            o_NewVehicle.MyVehicle = new ElectricCar();
                            return true;
                        }
                    case "4":
                    case "Electric motorcycle":
                        {
                            o_NewVehicle.MyVehicle = new ElectricMotorcycle();
                            return true;
                        }
                    case "5":
                    case "Truck":
                        {
                            o_NewVehicle.MyVehicle = new Truck();
                            return true;
                        }
                    default:
                        {
                            throw new Exception("Invalid selection");
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
        public bool SetEnergy(ref VehicleInGarage o_NewVehicle)
        {
            float m_MaxCapacity;
            float m_AmountLeft;
            if (o_NewVehicle is ElectricVehicles)
            {
                m_Message = string.Format("Please enter the battery capacity (in hours)");
                Console.WriteLine(m_Message);
                m_MaxCapacity = float.Parse(Console.ReadLine());
                ((ElectricVehicles)o_NewVehicle.MyVehicle).MaxTime = m_MaxCapacity;
                m_Message = string.Format("Please enter the number of hours left");
                Console.WriteLine(m_Message);
                m_AmountLeft = float.Parse(Console.ReadLine());
                try
                {
                    if (m_AmountLeft > m_MaxCapacity)
                    {
                        throw new ValueOutOfRangeException("Entering a larger amount than the maximum capacity");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
            else
            {
                m_Message = string.Format(@"Please select the type of fuel
1. Soler
2. Octan95
3. Octan96
4. Octan98");
                Console.WriteLine(m_Message);
                choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                        case "Soler":
                            ((FuelVehicles)o_NewVehicle.MyVehicle).MyTypeFuel = TypeFuel.Soler;
                            break;
                        case "2":
                        case "Octan95":
                            ((FuelVehicles)o_NewVehicle.MyVehicle).MyTypeFuel = TypeFuel.Octan95;
                            break;
                        case "3":
                        case "Octan96":
                            ((FuelVehicles)o_NewVehicle.MyVehicle).MyTypeFuel = TypeFuel.Octan96;
                            break;
                        case "4":
                        case "Octan98":
                            ((FuelVehicles)o_NewVehicle.MyVehicle).MyTypeFuel = TypeFuel.Octan98;
                            break;
                        default:
                            throw new Exception("Wrong choice");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
            return true;
        }
        public bool DefiningCarProperties(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format(@"Please select the car color: 
1. Balck
2. White
3. Red
4. Blue");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            try 
            {
                switch (choice)
                {
                    case "1":
                    case "Black":

                        break;
                    case "2":
                    case "White":

                        break;
                    case "3":
                    case "Red":

                        break;
                    case "4":
                    case "blue":

                        break;
                    default:
                        throw new Exception("Wrong choice");
                    }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
        public void Add()
        {
            VehicleInGarage VehicleToAdd = new VehicleInGarage();
            do
            {
                m_Message = string.Format("Enter the license number");
                m_LicenseNumberToCheck = Console.ReadLine();

            } while (!CheckValidLicenseNumber(ref m_LicenseNumberToCheck));

            if(SerachLicenseNumber(ref m_LicenseNumberToCheck,ref VehicleToAdd)) 
            {
                VehicleToAdd.MyStatus = Status.Repair;
            }
            else
            {
                while (!ChoosVehicleType(ref VehicleToAdd));
                while (!SetEnergy(ref VehicleToAdd));
                while(!DefiningCarProperties(ref VehicleToAdd));
            }
        }     
    }



}
