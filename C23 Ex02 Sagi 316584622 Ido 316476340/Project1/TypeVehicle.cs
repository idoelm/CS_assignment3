using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Definitions
{
    public abstract class TypeVehicle
    {
        private Wheel[] m_CollectWheels;
        public Wheel[] CollectWheels
        {
            set
            {
                this.m_CollectWheels = value;
            }
            get
            {
                return this.m_CollectWheels;
            }
        }
        public override string ToString()
        {
            return string.Join("\n", CollectWheels.Select((w, index) => $"wheel number: {index + 1}: {w}"));
            
        }
    }
}

