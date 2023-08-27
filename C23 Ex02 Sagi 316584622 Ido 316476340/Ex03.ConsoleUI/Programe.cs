using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class Programe
    {
        public static void Main()
        {
            Garage myGarage = new Garage();
            myGarage.StartGarage();
        }
    }

}
