﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Electric
{
    public class ElectricCar : ElectricVehicles
    {
        private Color m_Color;
        private int m_NumOfDoors;
        public ElectricCar()
        {
            int i_NumOfWheels = 4;
            base.CollectWheels = new Wheel[i_NumOfWheels];
        }
        public Color Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                this.Color = value;
            }
        }
        public int NumOfDoors
        {
            set
            {
                this.m_NumOfDoors = value;
            }
            get
            {
                return this.m_NumOfDoors;
            }
        }
    }
    public enum Color
    {
        Black,
        White,
        Red,
        Blue
    }
}

