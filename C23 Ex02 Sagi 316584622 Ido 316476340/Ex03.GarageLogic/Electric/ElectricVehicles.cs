using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Electric
{
    public abstract class ElectricVehicles : Vehicles
    {
        private float m_TimeLeft;
        private float m_MaxTime;

        public float TimeLeft
        {
            set
            {
                m_TimeLeft = value;
                float CurrentEnergyPercentage = ((m_TimeLeft / m_MaxTime) * 100.0f) / 100.0f;
                base.EnergyPercentage = CurrentEnergyPercentage;
            }
            get
            {
                return m_TimeLeft;
            }
        }
        public float MaxTime
        {
            set
            {
                this.m_MaxTime = value;
            }
            get
            {
                return this.m_MaxTime;
            }
        }
        public void charging(float i_AddTime)
        {
            this.m_TimeLeft += i_AddTime;
        }
    }
}
