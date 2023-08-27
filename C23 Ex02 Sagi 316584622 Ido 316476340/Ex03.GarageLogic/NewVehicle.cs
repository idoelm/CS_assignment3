using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class NewVehicle
    {
        public static void CreateVehicle(ref Vehicle o_Vehicle, int i_Input)
        {
            switch (i_Input)
            {
                case 1:
                    {
                        o_Vehicle.MyEngine = new Fuel();
                        o_Vehicle.MyTypeVehicle = new Car();
                        break;
                    }
                case 2:
                    {
                        o_Vehicle.MyEngine = new Fuel();
                        o_Vehicle.MyTypeVehicle = new Motorcycle();
                        break;
                    }
                case 3:
                    {
                        o_Vehicle.MyEngine = new Electric();
                        o_Vehicle.MyTypeVehicle = new Car();
                        break;
                    }
                case 4:
                    {
                        o_Vehicle.MyEngine = new Electric();
                        o_Vehicle.MyTypeVehicle = new Motorcycle();
                        break;
                    }
                case 5:
                    {
                        o_Vehicle.MyEngine = new Fuel();
                        o_Vehicle.MyTypeVehicle = new Truck();
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid selection");
                    }

            }

        }
    }
}
