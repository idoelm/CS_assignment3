using Project1.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Motorcycle : TypeVehicle
    {
        private TypeLicense m_MyTypeLicense;
        private int m_EngineCapacity;
        public Motorcycle()
        {
            int i_NumOfWheels = 2;
            base.CollectWheels = new Wheel[i_NumOfWheels];
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                base.CollectWheels[i] = new Wheel();
            }
        }
        public TypeLicense MyTypeLicense
        {
            set
            {
                this.m_MyTypeLicense = value;
            }
            get
            {
                return this.m_MyTypeLicense;
            }
        }
        public int EngineCapacity
        {
            set
            {
                this.m_EngineCapacity = value;
            }
            get
            {
                return this.m_EngineCapacity;
            }
        }
        public override string ToString()
        {
            return string.Format(@"
Type license: {0}
Engine capacity: {1}
Wheels:{2}
", m_MyTypeLicense, m_EngineCapacity, base.ToString());
        }
    }
    public enum TypeLicense
    {
        A,
        A1,
        A2,
        AB
    }
}
