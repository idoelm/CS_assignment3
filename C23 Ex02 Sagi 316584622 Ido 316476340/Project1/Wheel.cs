namespace Project1
{
    public class Wheel
    {
        private string m_NameOfMaker;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        public string NameOfMaker
        {
            set
            {
                m_NameOfMaker = value;
            }
            get
            {
                return m_NameOfMaker;
            }
        }

        public float CurrentAirPressure
        {
            set
            {
                m_CurrentAirPressure = value;
            }
            get
            {
                return m_CurrentAirPressure;
            }
        }
        public float MaxAirPressure
        {
            set
            {
                m_MaxAirPressure = value;
            }
            get
            {
                return m_MaxAirPressure;
            }
        }
        public override string ToString()
        {
            return string.Format(@"
manufacturer: {0}
Max air pressure: {1}
Current air pressure: {2}
", m_NameOfMaker, m_MaxAirPressure, m_CurrentAirPressure);
        }
    }
}