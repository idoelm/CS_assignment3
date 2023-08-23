using Project1.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Vehicle
    {
        private string m_NameOfModel;
        private string m_LicenseNumber;
        private float m_EnergyPercentage;
        private TypeVehicle m_MyTypeVehicle;
        private TypeEngine m_MyEngine;

        public Vehicle()
        {
            m_NameOfModel = string.Empty;
            m_LicenseNumber = string.Empty;
            m_EnergyPercentage = 0;
            m_MyTypeVehicle = null;
            m_MyEngine = null;
        }
        public string NameOfModel
        {
            set
            {
                m_NameOfModel = value;
            }
            get
            {
                return m_NameOfModel;
            }
        }

        public string LicenseNumber
        {
            set { m_LicenseNumber = value; }
            get { return m_LicenseNumber; }
        }
        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage = MyEngine.PercentageCalculation();
            }
        }

        public TypeVehicle MyTypeVehicle
        {
            set
            { 
                m_MyTypeVehicle = value;
            }
            get
            {
                return m_MyTypeVehicle;
            }
        }
        public TypeEngine MyEngine
        {
            set
            {
                m_MyEngine = value;
            }
            get
            {
                return m_MyEngine;
            }
        }
        public override string ToString()
        {
            return string.Format(@"
Name of model: {0}
License number: {1}
Energy percentage: {2}
Vehicle details:
{3}
Engine deatils:
{4}
", m_NameOfModel, m_LicenseNumber, m_EnergyPercentage, m_MyTypeVehicle, m_MyEngine);
        }
    }
}

