using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float maxValue;
        private float minValue;
        public ValueOutOfRangeException(float value, float maxValue, float minValue) : base(string.Format("The value {0} is out of range.", value))
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }
        public float GetMaxValue()
        {
            return maxValue;
        }
        public float GetMinValue()
        {
            return minValue;
        }
    }


}
