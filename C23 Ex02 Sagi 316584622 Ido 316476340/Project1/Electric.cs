using Project1.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Electric : TypeEngine
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

        public override float PercentageCalculation()
        {
            return (((((TimeLeft / MaxTime) / 100)) * 100));
        }
        public override string ToString()
        {
            return string.Format(@"
Max time: {0}
Time left: {1}
", m_MaxTime, m_TimeLeft);

        }

    }
}
