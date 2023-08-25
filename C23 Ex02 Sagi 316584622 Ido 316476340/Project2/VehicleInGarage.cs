using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1;
namespace Project2
{
    public class VehicleInGarage
    {
        private Vehicle m_MyVehicle;
        private String m_NameOwner;
        private String m_PhoneOwner;
        private Status m_MyStatus;

        public VehicleInGarage()
        {
            m_MyVehicle = new Vehicle();
        }
        public Vehicle MyVehicle
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

        public override string ToString()
        {
            return string.Format(@"Details of owner:
Owner Name: {0}
Owner's phone number: {1}
Status: {2}{3}", m_NameOwner,m_PhoneOwner, m_MyStatus,MyVehicle);
        }
    }
    public enum Status
    {
        Repair,
        Fixed,
        Paid
    }
}
