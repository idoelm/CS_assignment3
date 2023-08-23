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
            private float m_CurrentAmountLiters;
            private float m_MaxAmountFuel;

        public override float PercentageCalculation()
        {

            return (((((m_CurrentAmountLiters / m_MaxAmountFuel) / 100)) * 100));
        }
                 
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
            public float CurrentAmountLiters
            {
                set
                {
                    this.m_CurrentAmountLiters = value;
                }
                get
                {
                    return m_CurrentAmountLiters;
                }
            }
            public float MaxAmountFuel
            {
                set
                {
                    this.m_MaxAmountFuel = value;
                }
                get
                {
                    return m_MaxAmountFuel;
                }
            }
            public void Refueling(float i_Amount, string i_MyTypeFuel)
            {
                if (i_MyTypeFuel.Equals(i_MyTypeFuel))
                {
                    this.CurrentAmountLiters += i_Amount;
                }
            }
        public override string ToString()
        {
            return string.Format(@"
Type fuel: {0}
Max amount fuel: {1}
Current amount: {2}
", m_MyTypeFuel, m_MaxAmountFuel, m_CurrentAmountLiters);
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

