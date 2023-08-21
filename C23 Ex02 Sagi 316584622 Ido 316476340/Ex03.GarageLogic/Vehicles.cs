using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicles
    {
        private string m_NameOfModel;
        private string m_LicenseNumber;
        private float m_EnergyPercentage;
        private Wheel[] m_CollectWheels;
        public string NameOfModel
        {
            set
            {
                NameOfModel = value;
            }
            get
            {
                return NameOfModel;
            }
        }
        public string LicenseNumber
        {
            set
            {
                LicenseNumber = value;
            }
            get
            {
                return LicenseNumber;
            }
        }
        public Wheel[] CollectWheels
        {
            set
            {
                this.m_CollectWheels = value;
            }
            get
            {
                return this.m_CollectWheels;
            }
        }
        public float EnergyPercentage
        {
            set
            {
                m_EnergyPercentage = value;
            }
            get
            {
                return m_EnergyPercentage;
            }
        }

        public enum TypeVehicle
        {
            FuelCar,
            FuelMotorcycle,
            ElectricCar,
            ElectricMotorcycle,
            Truck
        }
    }
}
//public Vehicles(string i_NameOfModel, string i_LicenseNumber, float i_EnergyPercentage, int i_NumOfWheels)
//{
//    this.m_NameOfModel = i_NameOfModel;
//    this.m_LicenseNumber = i_LicenseNumber;
//    this.m_EnergyPercentage = i_EnergyPercentage;
//    this.m_CollectWheels = new Wheel[i_NumOfWheels];
//}

