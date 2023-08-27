using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Project2
{
    public class Garage
    {
        private List<VehicleInGarage> m_ArrayVehicle = new List<VehicleInGarage>();
        private VehicleInGarage m_Vehicle = new VehicleInGarage();
        private string m_Message;
        private string m_Message2;
        private string m_MyLicenseNumber;
        private string input;
        private bool m_Exit = false;
        protected VehicleInGarage SearchLicenseNumber()
        {
            m_Message = string.Format("Enter the license number");
            Console.WriteLine(m_Message);
            m_MyLicenseNumber = Console.ReadLine();
            return m_ArrayVehicle.Find(vehicle => vehicle.MyVehicle.LicenseNumber == m_MyLicenseNumber);
        }
        //public bool SerachLicenseNumber(ref string i_licenseNumberToCheck, ref VehicleInGarage o_Vehicle)
        //{
        //    foreach (VehicleInGarage vehicle in m_ArrayVehicle)
        //    {
        //        if (string.Equals(vehicle.MyVehicle.LicenseNumber, i_licenseNumberToCheck))
        //        {
        //            o_Vehicle = vehicle;
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        protected void SetModelName(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("Enter the vehicle model");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            o_NewVehicle.MyVehicle.NameOfModel = input;
        }
        protected bool ChooseVehicleType(ref VehicleInGarage o_NewVehicle)
        {
            Vehicle newVehicleToCreate = new Vehicle();

            m_Message = string.Format(@"Please choose the vehicle type
1. Fuel car
2. Fuel motorcycle
3. Electric car
4. Electric motorcycle
5. Truck");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            try
            {
                switch (input)
                {
                    case "1":
                    case "Fuel car":
                        {
                            NewVehicle.CreateVehicle(ref newVehicleToCreate, 1);
                            //o_NewVehicle.MyVehicle.MyEngine = new Fuel();
                            //o_NewVehicle.MyVehicle.MyTypeVehicle = new Car();
                            break;
                        }
                    case "2":
                    case "Fuel motorcycle":
                        {
                            NewVehicle.CreateVehicle(ref newVehicleToCreate, 2);
                            //o_NewVehicle.MyVehicle.MyEngine = new Fuel();
                            //o_NewVehicle.MyVehicle.MyTypeVehicle = new Motorcycle();
                            break;
                        }
                    case "3":
                    case "Electric car":
                        {
                            NewVehicle.CreateVehicle(ref newVehicleToCreate, 3);
                            //o_NewVehicle.MyVehicle.MyEngine = new Electric();
                            //o_NewVehicle.MyVehicle.MyTypeVehicle = new Car();
                            break;
                        }
                    case "4":
                    case "Electric motorcycle":
                        {
                            NewVehicle.CreateVehicle(ref newVehicleToCreate, 4);
                            o_NewVehicle.MyVehicle.MyEngine = new Electric();
                            o_NewVehicle.MyVehicle.MyTypeVehicle = new Motorcycle();
                            break;
                        }
                    case "5":
                    case "Truck":
                        {
                            NewVehicle.CreateVehicle(ref newVehicleToCreate, 5);
                            //o_NewVehicle.MyVehicle.MyEngine = new Fuel();
                            //o_NewVehicle.MyVehicle.MyTypeVehicle = new Truck();
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
            o_NewVehicle.MyVehicle = newVehicleToCreate;
            return true;
        }
        protected bool SetWheelPressure(ref VehicleInGarage o_NewVehicle)
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
            input = Console.ReadLine();
            try
            {
                maxAirPressure = float.Parse(input);
                m_Message = string.Format("What is the air pressure in the wheels now?");
                Console.WriteLine(m_Message);
                input = Console.ReadLine();
                currentAirPressure = float.Parse(input);
                if (currentAirPressure > maxAirPressure) 
                {
                    throw new ValueOutOfRangeException(currentAirPressure,maxAirPressure,0);
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
        protected bool SetEnergy(ref VehicleInGarage o_TheVehicle)
        {
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
                        throw new ValueOutOfRangeException(remaining,maxCapacity,0);
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
                    o_TheVehicle.MyVehicle.MyEngine.MaxAmountEnergy = maxCapacity;
                    o_TheVehicle.MyVehicle.MyEngine.AmountEnergyLeft = remaining;
                
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
                catch (ArgumentException)
                {
                    Console.WriteLine("you have selected a type of fuel that is not compatible with your vehicle.");
                    return false;
                }
            }
            return true;
        }
        protected bool ChooseColorCar(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format(@"Please select the car color: 
1. Balck
2. White
3. Red
4. Blue");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            try
            {
                switch (input)
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
                        throw new Exception("Wrong input");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }
        protected bool SetNumOfDoors(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("How many doors does your car have? (2-5)");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            try
            {
                if (int.Parse(input) <= 1 || int.Parse(input) >= 6)
                {
                    throw new ArgumentException("The number of doors must be between 2 and 5");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            (o_NewVehicle.MyVehicle.MyTypeVehicle as Car).NumOfDoors = int.Parse(input);
            return true;
        }
        protected bool SetTypeLiLicense(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format(@"What type of motorcycle license do you have?
1.A
2.A1
3.A2
4.AB");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            try
            {
                switch (input)
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
        protected bool SetEngineCapacity(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("What is the size of your engine in cc?");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            try
            {
                (o_NewVehicle.MyVehicle.MyTypeVehicle as Motorcycle).EngineCapacity = int.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                return false;
            }
        }
        protected bool SetTruckDefinitions(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format(@"Does the truck transport refrigerated?
1.yes
2.no");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            try
            {
                switch (input)
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
            input = Console.ReadLine();
            try
            {
                (o_NewVehicle.MyVehicle.MyTypeVehicle as Truck).Cargo = float.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                return false;
            }
        }
        protected bool InsertOwnerDetails(ref VehicleInGarage o_NewVehicle)
        {
            m_Message = string.Format("what is the vehicle owner's name?");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            if (!input.All(Char.IsLetter))
            {
                Console.WriteLine("Invalid input");
                return false;
            }
            o_NewVehicle.NameOwner = input;
            m_Message = string.Format("what is the vehicle owner's phone?");
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            if (!input.All(Char.IsDigit))
            {
                Console.WriteLine("Invalid input");
                return false;
            }
            o_NewVehicle.PhoneOwner = input;
            return true;
        }
        protected void Add()
        {
            m_Vehicle = SearchLicenseNumber();
            if (m_Vehicle == null)
            {
                m_Vehicle = new VehicleInGarage();
                m_Vehicle.MyStatus = Status.Repair;
                m_Vehicle.MyVehicle.LicenseNumber = m_MyLicenseNumber;
                SetModelName(ref m_Vehicle);
                while (!ChooseVehicleType(ref m_Vehicle));
                while (!SetWheelPressure(ref m_Vehicle));
                while (!SetEnergy(ref m_Vehicle)) ;
                if (m_Vehicle.MyVehicle.MyTypeVehicle is Car)
                {
                    while (!ChooseColorCar(ref m_Vehicle)) ;
                    while (!SetNumOfDoors(ref m_Vehicle)) ;
                }
                else if (m_Vehicle.MyVehicle.MyTypeVehicle is Motorcycle)
                {
                    SetTypeLiLicense(ref m_Vehicle);
                    SetEngineCapacity(ref m_Vehicle);
                }
                else
                {
                    while (!SetTruckDefinitions(ref m_Vehicle)) ;
                }
                while (!InsertOwnerDetails(ref m_Vehicle)) ;
                m_ArrayVehicle.Add(m_Vehicle);
            }
            else
            {
                m_Message = string.Format("this car already exists.");
                m_Vehicle.MyStatus = Status.Repair;
                Console.WriteLine(m_Message);
            }
        }
        protected void InflatingWheels()
        {
            m_Message = string.Format("Please enter the license number");
            Console.WriteLine(m_Message);
            m_MyLicenseNumber = Console.ReadLine();
            m_Vehicle = SearchLicenseNumber();
            foreach (Wheel wheel in m_Vehicle.MyVehicle.MyTypeVehicle.CollectWheels)
            {
                wheel.CurrentAirPressure = wheel.MaxAirPressure;
            }
        }
        protected void PrintByStatus(Status i_StatusToPrint)
        {
            m_Message = string.Format("{0}:", i_StatusToPrint);
            Console.WriteLine(m_Message);
            int index = 1;
            foreach (VehicleInGarage vehicles in m_ArrayVehicle)
            {
                if (vehicles.MyStatus == i_StatusToPrint)
                {
                    Console.WriteLine(string.Format("{0}) {1}", index, vehicles.MyVehicle.LicenseNumber));
                    index++;
                }
            }
        }
        protected void PrintLicenseNumber()
        {
            m_Message = string.Format(@"Do you want to print by status category?
1. yes
2. no");
            int index = 1;
            Console.WriteLine(m_Message);
            input = Console.ReadLine();
            try
            {
                switch (input)
                {
                    case "1":
                    case "yes":
                        {
                            for (; index < sizeof(Status); index++ )
                            {
                                PrintByStatus((Status)index);
                            }
                            break;
                        }
                    case "2":
                    case "no":
                        {
                            foreach (VehicleInGarage vehicles in m_ArrayVehicle)
                            {
                                
                                Console.WriteLine(string.Format("{0}) {1}", index, vehicles.MyVehicle.LicenseNumber));
                                index++;
                            }
                            break;
                        }
                    default:
                        {
                            throw new Exception();
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid selection");
            }
        }
        protected void ChangeStatus()
        {
            m_Vehicle = SearchLicenseNumber();
            if (m_Vehicle != null)
            {
                m_Message = string.Format(@"What type of motorcycle license do you have?
1.Repair
2.Fixed
3.Paid");
                Console.WriteLine(m_Message);
                input = Console.ReadLine();
                try
                {
                    switch (input)
                    {
                        case "1":
                        case "Repair":
                            {
                                m_Vehicle.MyStatus = Status.Repair;
                                break;
                            }
                        case "2":
                        case "Fixed":
                            {
                                m_Vehicle.MyStatus = Status.Fixed;
                                break;
                            }
                        case "3":
                        case "Paid":
                            {
                                m_Vehicle.MyStatus = Status.Paid;
                                break;
                            }
                        default:
                            throw new Exception("Invalid selection");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                m_Message = string.Format("Vehicle does not exist.");
            }
        }
        protected void RemoveVehicle()
        {
            m_Vehicle = SearchLicenseNumber();
            m_MyLicenseNumber = m_Vehicle.MyVehicle.LicenseNumber;
            m_ArrayVehicle.Remove(m_Vehicle);
            m_Message = string.Format("The vehicle {0} removed", m_MyLicenseNumber);
            Console.WriteLine(m_Message);
        }
        public void StartGarage()
        {
            do
            {
                if (m_ArrayVehicle.Count == 0)
                {
                    m_Message = string.Format(@"Choose the following option:
1. Add a vehicle
2. Exite");
                    Console.WriteLine(m_Message);
                    input = Console.ReadLine();
                    try
                    {
                        switch (input)
                        {
                            case "1":
                            case "Add a vehicle":
                                {
                                    Add();
                                    break;
                                }
                            case "2":
                            case "Exite":
                                {
                                    m_Exit = true;
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
                    }
                }
                else
                {
                    m_Message = string.Format(@"Choose the following option:
1. Add a vehicle
2. Printing a number of licenses
3. Change in vehicle status
4. To inflate the tires of a car to the maximum
5. To fill the vehicle's energy source
6. Printing full vehicle data
7. Reamove Vehicle
8. Exite");
                    Console.WriteLine(m_Message);
                    input = Console.ReadLine();
                    try
                    {
                        switch (input)
                        {
                            case "1":
                            case "Add a vehicle":
                                {
                                    Add();
                                    break;
                                }
                            case "2":
                            case "Printing a number of licenses":
                                {
                                    PrintLicenseNumber();
                                    break;
                                }
                            case "3":
                            case "Change in vehicle status":
                                {
                                    ChangeStatus();
                                    break;
                                }
                            case "4":
                            case "To inflate the tires of a car to the maximum":
                                {
                                    InflatingWheels();
                                    break;
                                }
                            case "5":
                            case "To fill the vehicle's energy source":
                                {
                                    m_Vehicle = SearchLicenseNumber();
                                    if(m_Vehicle != null)
                                    {
                                        SetEnergy(ref m_Vehicle);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not found");
                                    }
                                    break;
                                }
                            case "6":
                            case "Printing full vehicle data":
                                {
                                    m_Vehicle = SearchLicenseNumber();
                                    if (m_Vehicle != null)
                                    {
                                        Console.WriteLine(m_Vehicle);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not found");
                                    }
                                    break;
                                }
                            case "7":
                            case "Reamove Vehicle":
                                {
                                    RemoveVehicle();
                                    break;
                                }
                            case "8":
                            case "Exite":
                                {
                                    m_Exit = true;
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
                    }
                }
            } while (!m_Exit);
        }
    }
}
//        public void Refiling(ref VehicleInGarage o_NewVehicle)
//        {
//            float amountToAdd;
//            m_Message = string.Format("Please enter the license number");
//            Console.WriteLine(m_Message);
//            m_MyLicenseNumber = Console.ReadLine();

//            if (o_NewVehicle.MyVehicle.MyEngine is Electric)
//            {
//                try
//                {
//                    m_Message = string.Format("How many hours to add?");
//                    Console.WriteLine(m_Message);
//                    amountToAdd = float.Parse(Console.ReadLine());
//                    if(amountToAdd > (o_NewVehicle.MyVehicle.MyEngine as Electric).MaxTime)
//                    {
//                        throw new ValueOutOfRangeException("An amount above the maximum capacity has been entered");
//                    }
//                    (o_NewVehicle.MyVehicle.MyEngine as Electric).charging(amountToAdd);
//                }
//                catch(ValueOutOfRangeException ex)
//                {
//                    Console.WriteLine(ex);
//                }
//                catch (FormatException)
//                {
//                    Console.WriteLine("Invalid input");
//                }
//            }
//            else
//            {
//                Fuel.TypeFuel myType;
//                m_Message = string.Format(@"Please select the type of fuel
//1. Soler
//2. Octan95
//3. Octan96
//4. Octan98");
//                Console.WriteLine(m_Message);
//                input = Console.ReadLine();
//                try
//                {
//                    switch (input)
//                    {
//                        case "1":
//                        case "Soler":
//                            myType = Fuel.TypeFuel.Soler;
//                            break;
//                        case "2":
//                        case "Octan95":
//                            myType = Fuel.TypeFuel.Octan95;
//                            break;
//                        case "3":
//                        case "Octan96":
//                            myType = Fuel.TypeFuel.Octan96;
//                            break;
//                        case "4":
//                        case "Octan98":
//                            myType = Fuel.TypeFuel.Octan98;
//                            break;
//                        default:
//                            throw new ArgumentException("Wrong input");
//                    }
//                    if (myType != (o_NewVehicle.MyVehicle.MyEngine as Fuel).MyTypeFuel)
//                    {
//                        throw new ArgumentException(@"You have selected a type of fuel that is not compatible with your vehicle.
//Too bad about the engine.");
//                    }
//                }
//                catch (ArgumentException ex)
//                {
//                    Console.WriteLine(ex);
//                    return;
//                }
//                m_Message = string.Format("How many liters to fuel?");
//                Console.WriteLine(m_Message);
//                try
//                {
//                    amountToAdd = float.Parse(Console.ReadLine());
//                    if (amountToAdd > (o_NewVehicle.MyVehicle.MyEngine as Fuel).MaxAmountFuel)
//                    {
//                        throw new ValueOutOfRangeException("An amount above the maximum capacity has been entered");
//                    }
//                    (o_NewVehicle.MyVehicle.MyEngine as Fuel).Refueling(amountToAdd);
//                }
//                catch (ValueOutOfRangeException ex)
//                {
//                    Console.WriteLine(ex);
//                }
//                catch (FormatException)
//                {
//                    Console.WriteLine("Invalid input");
//                }

//            maxCapacity = float.Parse(Console.ReadLine());
//                m_Message = string.Format("Please enter the number of liters left");
//                Console.WriteLine(m_Message);
//                remaining = float.Parse(Console.ReadLine());
//                try
//                {
//                    if (remaining > maxCapacity)
//                    {
//                        throw new ValueOutOfRangeException("Entering a larger amount than the maximum capacity");
//                    }
//                }
//                catch (ValueOutOfRangeException ex)
//                {
//                    Console.WriteLine(ex);
//                    return false;
//                }
//                (o_NewVehicle.MyVehicle.MyEngine as Fuel).MaxAmountFuel = maxCapacity;
//                (o_NewVehicle.MyVehicle.MyEngine as Fuel).CurrentAmountLiters = remaining;
//            }
//        }