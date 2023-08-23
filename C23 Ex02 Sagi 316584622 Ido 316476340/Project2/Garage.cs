using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project2
{
    public class Garage
    {
        private List<VehicleInGarage> m_ArrayVehicle = new List<VehicleInGarage>();
        private string m_Message;
        private string m_MyLicenseNumber;
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
        public void SetModelName(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("Enter the vehicle model");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            o_NewVehicle.MyVehicle.NameOfModel = choice;
        }
        public bool ChooseVehicleType(ref VehicleInGarage o_NewVehicle)
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
                            o_NewVehicle.MyVehicle.MyEngine = new Fuel();
                            o_NewVehicle.MyVehicle.MyTypeVehicle = new Car();
                            return true;
                        }
                    case "2":
                    case "Fuel motorcycle":
                        {
                            o_NewVehicle.MyVehicle.MyEngine = new Fuel();
                            o_NewVehicle.MyVehicle.MyTypeVehicle = new Motorcycle();
                            return true;
                        }
                    case "3":
                    case "Electric car":
                        {
                            o_NewVehicle.MyVehicle.MyEngine = new Electric();
                            o_NewVehicle.MyVehicle.MyTypeVehicle = new Car();
                            return true;
                        }
                    case "4":
                    case "Electric motorcycle":
                        {
                            o_NewVehicle.MyVehicle.MyEngine = new Electric();
                            o_NewVehicle.MyVehicle.MyTypeVehicle = new Motorcycle();
                            return true;
                        }
                    case "5":
                    case "Truck":
                        {
                            o_NewVehicle.MyVehicle.MyEngine = new Fuel();
                            o_NewVehicle.MyVehicle.MyTypeVehicle = new Truck();
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
        public bool SetWheelPressure(ref VehicleInGarage o_NewVehicle)
        {
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
        public bool SetEnergy(ref VehicleInGarage o_NewVehicle)
        {
            float maxCapacity;
            float remaining;
            if (o_NewVehicle.MyVehicle.MyEngine is Electric)
            {
                try
                {
                    m_Message = string.Format("Please enter the battery capacity (in hours)");
                    Console.WriteLine(m_Message);
                    maxCapacity = float.Parse(Console.ReadLine());
                    m_Message = string.Format("Please enter the number of hours left");
                    Console.WriteLine(m_Message);
                    remaining = float.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input");
                    return false;
                }
                try
                {
                    if (remaining > maxCapacity)
                    {
                        throw new ValueOutOfRangeException("Entering a larger amount than the maximum capacity");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                (o_NewVehicle.MyVehicle.MyEngine as Electric).MaxTime = maxCapacity;
                (o_NewVehicle.MyVehicle.MyEngine as Electric).TimeLeft = remaining;
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
                            (o_NewVehicle.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Soler;
                            break;
                        case "2":
                        case "Octan95":
                            (o_NewVehicle.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan95;
                            break;
                        case "3":
                        case "Octan96":
                            (o_NewVehicle.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan96;
                            break;
                        case "4":
                        case "Octan98":
                            (o_NewVehicle.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan98;
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

                m_Message = string.Format("Please enter the tank capacity (in liters)");
                Console.WriteLine(m_Message);
                maxCapacity = float.Parse(Console.ReadLine());
                m_Message = string.Format("Please enter the number of liters left");
                Console.WriteLine(m_Message);
                remaining = float.Parse(Console.ReadLine());
                try
                {
                    if (remaining > maxCapacity)
                    {
                        throw new ValueOutOfRangeException("Entering a larger amount than the maximum capacity");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                (o_NewVehicle.MyVehicle.MyEngine as Fuel).MaxAmountFuel = maxCapacity;
                (o_NewVehicle.MyVehicle.MyEngine as Fuel).CurrentAmountLiters = remaining;
            }
            return true;
        }
        public bool ChooseColorCar(ref VehicleInGarage o_NewVehicle)
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
                        (o_NewVehicle.MyVehicle.MyTypeVehicle as Car).MyColor = Color.Black;
                        break;
                    case "2":
                    case "White":
                        (o_NewVehicle.MyVehicle.MyTypeVehicle as Car).MyColor = Color.White;
                        break;
                    case "3":
                    case "Red":
                        (o_NewVehicle.MyVehicle.MyTypeVehicle as Car).MyColor = Color.Red;
                        break;
                    case "4":
                    case "blue":
                        (o_NewVehicle.MyVehicle.MyTypeVehicle as Car).MyColor = Color.Blue;
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
            return true;
        }
        public bool SetNumOfDoors(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("How many doors does your car have? (2-5)");
            choice = Console.ReadLine();
            try
            {
                if(int.Parse(choice) <= 1 || int.Parse(choice) >=6)
                {
                    throw new ArgumentException("The number of doors must be between 2 and 5");
                }
            }
            catch( ArgumentException ex) 
            {
                Console.WriteLine(ex);
                return false;
            }
            (o_NewVehicle.MyVehicle.MyTypeVehicle as Car).NumOfDoors = int.Parse(choice);
            return true;
        }
        public bool SetTypeLiLicense(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format(@"What type of motorcycle license do you have?
1.A
2.A1
3.A2
4.AB");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                    case "A":
                        {
                            (o_NewVehicle.MyVehicle.MyTypeVehicle as Motorcycle).MyTypeLicense = TypeLicense.A;
                            return true;
                        }
                    case "2":
                    case "A1":
                        {
                            (o_NewVehicle.MyVehicle.MyTypeVehicle as Motorcycle).MyTypeLicense = TypeLicense.A1;
                            return true;
                        }
                    case "3":
                    case "A2":
                        {
                            (o_NewVehicle.MyVehicle.MyTypeVehicle as Motorcycle).MyTypeLicense = TypeLicense.A2;
                            return true;
                        }
                    case "4":
                    case "AB":
                        {
                            (o_NewVehicle.MyVehicle.MyTypeVehicle as Motorcycle).MyTypeLicense = TypeLicense.AB;
                            return true;
                        }
                    default:
                        throw new Exception("Invalid selection");

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool SetEngineCapacity(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("What is the size of your engine in cc?");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            try
            {
                (o_NewVehicle.MyVehicle.MyTypeVehicle as Motorcycle).EngineCapacity = int.Parse(choice);
                return true;
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input");
                return false;
            }      
        }
        public bool SetTruckDefinitions(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format(@"Does the truck transport refrigerated?
1.yes
2.no");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                    case "yes":
                        {
                            (o_NewVehicle.MyVehicle.MyTypeVehicle as Truck).LeadingRefrigeration = true;
                            break;
                        }
                    case "2":
                    case "no":
                        {
                            (o_NewVehicle.MyVehicle.MyTypeVehicle as Truck).LeadingRefrigeration = false;
                            break;
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
            m_Message = string.Format("What is the size of the cargo");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            try
            {
                (o_NewVehicle.MyVehicle.MyTypeVehicle as Truck).Cargo = float.Parse(choice);
                return true;
            }
            catch(FormatException) 
            {
                Console.WriteLine("Invalid input");
                return false;
            }
        }
        public bool InsertOwnerDetails(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("what is the vehicle owner's name?");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            if (!choice.All(Char.IsLetter))
            {
               Console.WriteLine("Invalid input");
                return false;
            }
            o_NewVehicle.NameOwner = choice;
            m_Message = string.Format("what is the vehicle owner's phone?");
            Console.WriteLine(m_Message);
            choice = Console.ReadLine();
            if (!choice.All(Char.IsDigit))
            {
                Console.WriteLine("Invalid input");
                return false;
            }
            o_NewVehicle.PhoneOwner = choice;
            return true;
        }
        public void Add()
        {
            VehicleInGarage VehicleToAdd = new VehicleInGarage();
            do
            {
                m_Message = string.Format("Enter the license number");
                m_MyLicenseNumber = Console.ReadLine();

            } while (!CheckValidLicenseNumber(ref m_MyLicenseNumber));

            if (SerachLicenseNumber(ref m_MyLicenseNumber, ref VehicleToAdd))
            {
                VehicleToAdd.MyStatus = Status.Repair;
            }
            else
            {
                VehicleToAdd.MyVehicle.LicenseNumber = m_MyLicenseNumber;
                SetModelName(ref VehicleToAdd);
                while (!ChooseVehicleType(ref VehicleToAdd));
                SetWheelPressure(ref VehicleToAdd);
                while (!SetEnergy(ref VehicleToAdd)) ;
                if(VehicleToAdd.MyVehicle.MyTypeVehicle is Car) 
                {
                    while (!ChooseColorCar(ref VehicleToAdd));
                    while(!SetNumOfDoors(ref  VehicleToAdd));
                }
                else if(VehicleToAdd.MyVehicle.MyTypeVehicle is Motorcycle)
                {
                    SetTypeLiLicense(ref VehicleToAdd);
                    SetEngineCapacity(ref VehicleToAdd);
                }
                else
                {
                    while(!SetTruckDefinitions(ref VehicleToAdd));
                }
                while (!InsertOwnerDetails(ref  VehicleToAdd));
                m_ArrayVehicle.Add(VehicleToAdd);
            }
        }
    }
}
