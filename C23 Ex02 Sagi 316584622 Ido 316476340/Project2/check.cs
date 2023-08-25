using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Project1;
namespace Project2
{
    public class check
    {
        static List<VehicleInGarage> m_ArrayVehicle = new List<VehicleInGarage>();
        

        public static bool SetWheelPressure(ref VehicleInGarage o_NewVehicle)
        {
            string choice;
            string m_Message;
            float maxAirPressure;
            float currentAirPressure;
            int numOfWheel = 0;
            string nameOfManufacturer;
            m_Message = string.Format("Enter the name of the manufacturer of the wheels");
            Console.WriteLine(m_Message);
            nameOfManufacturer = Console.ReadLine();
            m_Message = string.Format("What is the Max air pressure in the wheels?");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            try
            {
                maxAirPressure = float.Parse(choice);
                m_Message = string.Format("What is the air pressure in the wheels now?");
                Console.WriteLine(m_Message);
                choice = Console.ReadLine();
                currentAirPressure = float.Parse(choice);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                return false;
            }
            if ((o_NewVehicle.MyVehicle.MyTypeVehicle is Motorcycle))
            {
                numOfWheel = 2;
            }
            else if ((o_NewVehicle.MyVehicle.MyTypeVehicle is Car))
            {
                numOfWheel = 4;
            }
            else
            {
                numOfWheel = 8;
            }

            for (int i = 0; i < numOfWheel; i++)
            {
                o_NewVehicle.MyVehicle.MyTypeVehicle.CollectWheels[i].NameOfMaker = nameOfManufacturer;
                o_NewVehicle.MyVehicle.MyTypeVehicle.CollectWheels[i].CurrentAirPressure = currentAirPressure;
                o_NewVehicle.MyVehicle.MyTypeVehicle.CollectWheels[i].MaxAirPressure = maxAirPressure;
            }
            return true;
        }

        public static VehicleInGarage InflatingWheels(ref List<VehicleInGarage> m_ArrayVehicle)
        {
            string m_Message, m_MyLicenseNumber;
            VehicleInGarage m_Vehicle;
            m_Message = string.Format("Please enter the license number");
            Console.WriteLine(m_Message);
            m_MyLicenseNumber = Console.ReadLine();
            return m_ArrayVehicle.Find(vehicle => vehicle.MyVehicle.LicenseNumber == m_MyLicenseNumber);
            foreach (Wheel wheel in m_Vehicle.MyVehicle.MyTypeVehicle.CollectWheels)
            {
                wheel.CurrentAirPressure = wheel.MaxAirPressure;
            }
        }

        public static bool SetEnergy(ref VehicleInGarage o_TheVehicle)
        {
            string m_Message;
            string m_Message2;
            string input;

            float maxCapacity;
            float remaining;
            Fuel.TypeFuel? TypeOfFuel = null;
            if (o_TheVehicle.MyVehicle.MyEngine is Fuel)
            {
                m_Message = string.Format(@"Please select the type of fuel
1. Soler
2. Octan95
3. Octan96
4. Octan98");
                Console.WriteLine(m_Message);
                input = Console.ReadLine();
                try
                {
                    switch (input)
                    {
                        case "1":
                        case "Soler":
                            TypeOfFuel = Fuel.TypeFuel.Soler;
                            break;
                        case "2":
                        case "Octan95":
                            TypeOfFuel = Fuel.TypeFuel.Octan95;
                            break;
                        case "3":
                        case "Octan96":
                            TypeOfFuel = Fuel.TypeFuel.Octan96;
                            break;
                        case "4":
                        case "Octan98":
                            TypeOfFuel = Fuel.TypeFuel.Octan98;
                            break;
                        default:
                            throw new ArgumentException("Wrong input");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }

            if (o_TheVehicle.MyVehicle.MyEngine.MaxAmountEnergy == 0)
            { 
                if (o_TheVehicle.MyVehicle.MyEngine is Fuel)
                {
                    m_Message = string.Format("Please enter the tank capacity (in liters)");
                     m_Message2 = string.Format("Please enter the number of liters left");
                    (o_TheVehicle.MyVehicle.MyEngine as Fuel).MyTypeFuel = TypeOfFuel.Value;
                }
                else
                {
                    m_Message = string.Format("Please enter the battery capacity (in hours)");
                    m_Message2 = string.Format("Please enter the number of hours left");
                }
                Console.WriteLine(m_Message);
                maxCapacity = float.Parse(Console.ReadLine());
                Console.WriteLine(m_Message2);
                remaining = float.Parse(Console.ReadLine());
                try
                {
                    if (remaining > maxCapacity)
                    {
                        throw new ValueOutOfRangeException("Entering a larger amount than the maximum capacity");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                    return false;
                }

                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                finally
                {
                    o_TheVehicle.MyVehicle.MyEngine.MaxAmountEnergy = maxCapacity;
                    o_TheVehicle.MyVehicle.MyEngine.AmountEnergyLeft = remaining;
                }
            }
            else
            {
                try
                {
                    if ((o_TheVehicle.MyVehicle.MyEngine is Fuel))
                    {
                        m_Message = string.Format("How many liters to add?");
                        Console.WriteLine(m_Message);
                        input = Console.ReadLine();
                        (o_TheVehicle.MyVehicle.MyEngine as Fuel).Refueling(float.Parse(input), TypeOfFuel.Value);
                    }
                    else if (o_TheVehicle.MyVehicle.MyEngine is Electric)
                    {
                        m_Message = string.Format("How many hours to add?");
                        Console.WriteLine(m_Message);
                        input = Console.ReadLine();
                        (o_TheVehicle.MyVehicle.MyEngine as Electric).charging(float.Parse(input));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                    return false;
                }

                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("An amount above the maximum capacity has been entered");
                    return false;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("you have selected a type of fuel that is not compatible with your vehicle.");
                    return false;
                }
            }
            return true;
        }


        public static void PrintByStatus(ref List<VehicleInGarage> m_ArrayVehicle)
        {
            int index = 1;
            foreach (VehicleInGarage vehicles in m_ArrayVehicle)
            {
                if (vehicles.MyStatus == Status.Repair)
                {
                    Console.WriteLine(string.Format("{0}) {1}", index, vehicles.MyVehicle.LicenseNumber));
                    index++;
                }
            }
            index = 1;
            foreach (VehicleInGarage vehicles in m_ArrayVehicle)
            {
                if (vehicles.MyStatus == Status.Fixed)
                {
                    Console.WriteLine(string.Format("{0}) {1}", index, vehicles.MyVehicle.LicenseNumber));
                    index++;
                }
            }
            index = 1;
            foreach (VehicleInGarage vehicles in m_ArrayVehicle)
            {
                if (vehicles.MyStatus == Status.Paid)
                {
                    Console.WriteLine(string.Format("{0}) {1}", index, vehicles.MyVehicle.LicenseNumber));
                    index++;
                }
            }
        }

        public static VehicleInGarage SearchLicenseNumber(string i_licenseNumberToSearch)
        {   
            return m_ArrayVehicle.Find(vehicle => vehicle.MyVehicle.LicenseNumber == i_licenseNumberToSearch);
        }
        public static void ChangeStatus(ref string i_LicenseNumber, Status i_NewStatus)
        {
            VehicleInGarage m_Vehicle;
            m_Vehicle = SearchLicenseNumber(i_LicenseNumber);
            if (m_Vehicle != null)
            {
                m_Vehicle.MyStatus = i_NewStatus;
            }
            else
            {
                Console.WriteLine( string.Format("vehicle does not exist."));
            }
        }



        public static void Main()
        {
            Garage myGarage = new Garage();
            myGarage.StartGarage();
            //VehicleInGarage a = new VehicleInGarage();
            //string g = "12xs";
            //a.NameOwner = "ori";
            //a.PhoneOwner = "0542961188";
            //a.MyVehicle.NameOfModel = "honda";
            //a.MyVehicle.LicenseNumber = "12xs";
            //a.MyVehicle.MyEngine = new Fuel();
            //a.MyStatus = Status.Repair;

            PrintByStatus(Status.Repair);
            //m_ArrayVehicle.Add(a);
            //ChangeStatus(ref g, Status.Paid);
            //Console.WriteLine(a.MyStatus);


            //a = new VehicleInGarage();
            //a.NameOwner = "shilo";
            //a.PhoneOwner = "0542881196";
            //a.MyVehicle.NameOfModel = "ford";
            //a.MyVehicle.LicenseNumber = "cv45";
            //a.MyVehicle.MyEngine = new Fuel();
            //a.MyStatus = Status.Fixed;
            //m_ArrayVehicle.Add(a);
            //(a.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan96;
            //(a.MyVehicle.MyEngine as Fuel).MaxAmountFuel = 40;
            //(a.MyVehicle.MyEngine as Fuel).CurrentAmountLiters = 23;
            //a.MyVehicle.MyTypeVehicle = new Car();
            //(a.MyVehicle.MyTypeVehicle as Car).MyColor = Color.Black;
            //(a.MyVehicle.MyTypeVehicle as Car).NumOfDoors = 3;
            //SetWheelPressure(ref a);
            //m_ArrayVehicle.Add(a);
            //a = new VehicleInGarage();
            //a.NameOwner = "retre";
            //a.PhoneOwner = "0542961188";
            //a.MyVehicle.NameOfModel = "renault";
            //a.MyVehicle.LicenseNumber = "3443fff";
            //a.MyVehicle.MyEngine = new Electric();
            //a.MyStatus = Status.Paid;
            //m_ArrayVehicle.Add(a);
            //(a.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan98;
            //(a.MyVehicle.MyEngine as Fuel).MaxAmountFuel = 10;
            //(a.MyVehicle.MyEngine as Fuel).CurrentAmountLiters = 5;
            //a.MyVehicle.MyTypeVehicle = new Motorcycle();
            //(a.MyVehicle.MyTypeVehicle as Motorcycle).MyTypeLicense = TypeLicense.A1;
            //(a.MyVehicle.MyTypeVehicle as Motorcycle).EngineCapacity = 300;
            //SetWheelPressure(ref a);
            //m_ArrayVehicle.Add(a);
            //a.NameOwner = "mor";
            //a.PhoneOwner = "0542911886";
            //a.MyVehicle.NameOfModel = "renault";
            //a.MyVehicle.LicenseNumber = "dsf213";
            //a.MyVehicle.MyEngine = new Electric();
            //a.MyStatus = Status.Repair;
            //m_ArrayVehicle.Add(a);
            //PrintByStatus(ref m_ArrayVehicle);
            //foreach (VehicleInGarage vehicleInGarage in m_ArrayVehicle)
            //{
            //    Console.WriteLine(vehicleInGarage);
            //}


        }
    }

}
