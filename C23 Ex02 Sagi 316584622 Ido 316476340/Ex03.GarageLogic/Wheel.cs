using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_NameOfMaker;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_NameOfMaker, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.m_NameOfMaker = i_NameOfMaker;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public string NameOfMaker
        {
            set
            {
                m_NameOfMaker = value;
            }
            get
            {
                return m_NameOfMaker;
            }
        }

        public float CurrentAirPressure
        {
            set
            {
                m_CurrentAirPressure = value;
            }
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public float MaxAirPressure
        {
            set
            {
                m_MaxAirPressure = value;
            }
            get
            {
                return m_MaxAirPressure;
            }
        }
    }
}
