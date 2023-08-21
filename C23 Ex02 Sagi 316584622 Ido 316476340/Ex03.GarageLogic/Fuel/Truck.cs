using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Fuel
{
    public class Truck : FuelVehicles
    {
        private bool m_LeadingRefrigeration;
        private float m_Trunk;

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
        public float Trunk
        {
            get
            {
                return m_Trunk;
            }
            set
            {
                m_Trunk = value;
            }
        }
    }
}

