using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuell
    {
        private TypeFuel m_MyTypeFuel;
        private float m_CurrentAmountLiters;
        private float m_MaxAmountFuel;
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

        public enum TypeFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }
    }
}

