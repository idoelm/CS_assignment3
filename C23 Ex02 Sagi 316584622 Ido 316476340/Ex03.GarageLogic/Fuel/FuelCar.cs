using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Fuel
{
    public class FuelCar : ICar
    {
        private Fuell m_FuellCar;
        public FuelCar()
        {
            this.m_FuellCar = new Fuell();
        }

        public Fuell FuellCar
        {
            get { return this.m_FuellCar; }
        }
    }
}

