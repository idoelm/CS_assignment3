using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class VehicleInGarage
    {
        private Vehicles m_MyVehicle;
        private String m_NameOwner;
        private String m_PhoneOwner;
        private Status m_MyStatus;

        public Vehicles MyVehicle
        {
            set 
            {
                m_MyVehicle = value;
            }
            get
            {
                return m_MyVehicle;
            }
        }
        public String NameOwner
        {
            set
            {
                m_NameOwner = value;
            }
            get
            {
                return m_NameOwner;
            }
        }
        public String PhoneOwner
        {
            set 
            {
                m_PhoneOwner = value;
            }
            get
            {
                return m_PhoneOwner;
            }
        }
        public Status MyStatus
        {
            set
            {
                m_MyStatus = value;
            }
            get
            {
                return m_MyStatus;
            }
        }
    }
    public enum Status
    {
        Repair,
        Fixed,
        Paid
    }
}
