using Project1.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Car : TypeVehicle
    {
        private Color m_MyColor;
        private int m_NumOfDoors;
        public Car()
        {
            int i_NumOfWheels = 4;
           base.CollectWheels = new Wheel[i_NumOfWheels];
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                base.CollectWheels[i] = new Wheel();
            }
        }
        public Color MyColor
        {
            get
            {
                return this.m_MyColor;
            }
            set
            {
                this.m_MyColor = value;
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
        public override string ToString()
        {
            return string.Format(@"
Color: {0}
The number of doors: {1}
Wheels: {2}
", m_MyColor, m_NumOfDoors, base.ToString());
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

