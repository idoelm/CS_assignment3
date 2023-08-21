using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Fuel
{
    public class FuelMotorcycle : FuelVehicles
    {
        private string m_TypeLicense;
        private int m_EngineCapacity;

        public FuelMotorcycle()
        {
            int i_NumOfWheels = 2;
            base.CollectWheels = new Wheel[i_NumOfWheels];
        }
        public string TypeLicense
        {
            set
            {
                bool isValidChoice = false;

                while (!isValidChoice)
                {
                    switch (value)
                    {
                        case "1":
                            m_TypeLicense = "A";
                            isValidChoice = true;
                            break;
                        case "2":
                            m_TypeLicense = "A1";
                            isValidChoice = true;
                            break;
                        case "3":
                            m_TypeLicense = "A2";
                            isValidChoice = true;
                            break;
                        case "4":
                            m_TypeLicense = "AB";
                            isValidChoice = true;
                            break;
                        default:
                            Console.WriteLine("Wrong choice. Please select again.");
                            value = Console.ReadLine();
                            break;
                    }
                }
            }
            get
            {
                return m_TypeLicense;
            }
        }
        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }
    }
}
