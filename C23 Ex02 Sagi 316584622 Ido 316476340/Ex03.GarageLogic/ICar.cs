using Ex03.GarageLogic.Fuel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ICar : Vehicles
    {
        private Color m_MyColor;
        private int m_NumOfDoors;
        public ICar()
        {
            int i_NumOfWheels = 4;
            base.CollectWheels = new Wheel[i_NumOfWheels];
        }
        public  Color MyColor
        {
            get
            {
                return this.MyColor;
            }
            set
            {
                this.MyColor = value;
            }
        }
        public  int NumOfDoors
        {
            set
            {
                this.NumOfDoors = value;
            }
            get
            {
                return this.NumOfDoors;
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
