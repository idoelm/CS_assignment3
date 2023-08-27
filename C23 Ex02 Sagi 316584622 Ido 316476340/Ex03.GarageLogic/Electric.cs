using Ex03.GarageLogic.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Electric : TypeEngine
    {
        public void charging(float i_AddTime)
        {

            base.fillingEnergySource(i_AddTime);
        }
        public override string ToString()
        {
            return string.Format(@"
Max time: {0} hours
Time left: {1} hours
", MaxAmountEnergy, AmountEnergyLeft);

        }

    }
}
