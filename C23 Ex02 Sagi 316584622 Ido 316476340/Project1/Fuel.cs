using Project1.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Fuel : TypeEngine
    {
        private TypeFuel m_MyTypeFuel;
            public TypeFuel MyTypeFuel
            {
                set
                {
                    this.m_MyTypeFuel = value;
                }
                get
                {
                    return m_MyTypeFuel;
                }
            }
        public void Refueling(float i_LitersToAdd, TypeFuel i_MyTypeFuel)
        {
            if (i_MyTypeFuel != m_MyTypeFuel)
            {
                throw new ArgumentException();
            }
            base.fillingEnergySource(i_LitersToAdd);
        }
        public override string ToString()
        {
            return string.Format(@"
Type fuel: {0}
Max amount fuel: {1} Liters
Current amount: {2} Liters
", m_MyTypeFuel, MaxAmountEnergy, AmountEnergyLeft);
        }
        public enum TypeFuel
            {
                Soler,
                Octan95,
                Octan96,
                Octan98,
            }
        }

    }

