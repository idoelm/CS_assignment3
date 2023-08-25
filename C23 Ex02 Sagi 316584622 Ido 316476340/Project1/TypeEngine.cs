using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Definitions
{
    public abstract class TypeEngine
    {
        protected float m_AmountEnergyLeft;
        protected float m_MaxAmountEnergy;
        public float AmountEnergyLeft
        {
            set
            {
                this.m_AmountEnergyLeft = value;
            }
            get
            {
                return m_AmountEnergyLeft;
            }
        }
        public float MaxAmountEnergy
        {
            set
            {
                this.m_MaxAmountEnergy = value;
            }
            get
            {
                return this.m_MaxAmountEnergy;
            }
        }
        public  float PercentageCalculation()
        {
            return (((((AmountEnergyLeft / MaxAmountEnergy) / 100)) * 100));
        }

        protected void fillingEnergySource(float i_AmountToAdd)
        {
            if (m_AmountEnergyLeft + i_AmountToAdd > m_MaxAmountEnergy)
            {
                throw new ValueOutOfRangeException("An amount above the maximum capacity has been entered");
            }
            m_AmountEnergyLeft += i_AmountToAdd;
        }
        public abstract override string ToString();
    }
}
