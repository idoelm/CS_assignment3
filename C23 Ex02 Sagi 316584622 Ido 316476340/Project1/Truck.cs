using Project1.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Truck : TypeVehicle
    {
        private bool m_LeadingRefrigeration;
        private float m_Cargo;
        public Truck()
        {
            int i_NumOfWheels = 8;
            base.CollectWheels = new Wheel[i_NumOfWheels];
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                base.CollectWheels[i] = new Wheel();
            }
        }
        public bool LeadingRefrigeration
        {
            get
            {
                return m_LeadingRefrigeration;
            }
            set
            {
                m_LeadingRefrigeration = value;
            }
        }
        public float Cargo
        {
            get
            {
                return m_Cargo;
            }
            set
            {
                m_Cargo = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"
Leading Refrigeration: {0}
Size of cargo: {1}
Wheels:
{2}
", m_LeadingRefrigeration, m_Cargo,base.ToString());

        }
    }
}
