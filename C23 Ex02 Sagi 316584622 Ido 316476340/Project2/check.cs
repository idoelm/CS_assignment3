using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Project1;
namespace Project2
{
    public class check
    {

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

        public static void Main()
        {
            VehicleInGarage a = new VehicleInGarage();
            List<VehicleInGarage> m_ArrayVehicle = new List<VehicleInGarage>();
            a.NameOwner = "ori";
            a.PhoneOwner = "0542961188";
            a.MyVehicle.NameOfModel = "honda";
            a.MyVehicle.LicenseNumber = "12xs";
            a.MyVehicle.MyEngine = new Fuel();
            (a.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan98;
            (a.MyVehicle.MyEngine as Fuel).MaxAmountFuel = 10;
            (a.MyVehicle.MyEngine as Fuel).CurrentAmountLiters = 5;
            a.MyVehicle.MyTypeVehicle = new Truck();
            (a.MyVehicle.MyTypeVehicle as Truck).LeadingRefrigeration = true;
            (a.MyVehicle.MyTypeVehicle as Truck).Cargo = 67868;
            SetWheelPressure(ref a);
            Console.WriteLine(a);
            m_ArrayVehicle.Add(a);
            a.NameOwner = "ido";
            a.PhoneOwner = "0542118896";
            a.MyVehicle.NameOfModel = "tesla";
            a.MyVehicle.LicenseNumber = "678gh";
            a.MyVehicle.MyEngine = new Electric();
            (a.MyVehicle.MyEngine as Electric).MaxTime = 10;
            (a.MyVehicle.MyEngine as Electric).TimeLeft = 4;
            a.MyVehicle.MyTypeVehicle = new Car();
            (a.MyVehicle.MyTypeVehicle as Car).MyColor = Color.White;
            (a.MyVehicle.MyTypeVehicle as Car).NumOfDoors = 4;
            SetWheelPressure(ref a);
            m_ArrayVehicle.Add(a);
            a = new VehicleInGarage();
            a.NameOwner = "shilo";
            a.PhoneOwner = "0542881196";
            a.MyVehicle.NameOfModel = "ford";
            a.MyVehicle.LicenseNumber = "cv45";
            a.MyVehicle.MyEngine = new Fuel();
            (a.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan96;
            (a.MyVehicle.MyEngine as Fuel).MaxAmountFuel = 40;
            (a.MyVehicle.MyEngine as Fuel).CurrentAmountLiters = 23;
            a.MyVehicle.MyTypeVehicle = new Car();
            (a.MyVehicle.MyTypeVehicle as Car).MyColor = Color.Black;
            (a.MyVehicle.MyTypeVehicle as Car).NumOfDoors = 3;
            SetWheelPressure(ref a);
            m_ArrayVehicle.Add(a);
            a = new VehicleInGarage();
            a.NameOwner = "ori";
            a.PhoneOwner = "0542961188";
            a.MyVehicle.NameOfModel = "honda";
            a.MyVehicle.LicenseNumber = "12xs";
            a.MyVehicle.MyEngine = new Fuel();
            (a.MyVehicle.MyEngine as Fuel).MyTypeFuel = Fuel.TypeFuel.Octan98;
            (a.MyVehicle.MyEngine as Fuel).MaxAmountFuel = 10;
            (a.MyVehicle.MyEngine as Fuel).CurrentAmountLiters = 5;
            a.MyVehicle.MyTypeVehicle = new Motorcycle();
            (a.MyVehicle.MyTypeVehicle as Motorcycle).MyTypeLicense = TypeLicense.A1;
            (a.MyVehicle.MyTypeVehicle as Motorcycle).EngineCapacity = 300;
            SetWheelPressure(ref a);
            m_ArrayVehicle.Add(a);

            foreach (VehicleInGarage vehicleInGarage in m_ArrayVehicle)
            {
                Console.WriteLine(vehicleInGarage);
            }


        }
    }

}
