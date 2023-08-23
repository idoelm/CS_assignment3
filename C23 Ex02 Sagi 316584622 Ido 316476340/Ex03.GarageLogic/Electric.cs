using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Electricc
    {
        private float m_TimeLeft;
        private float m_MaxTime;

        public float TimeLeft
        {
            set
            {
                m_TimeLeft = value;
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

