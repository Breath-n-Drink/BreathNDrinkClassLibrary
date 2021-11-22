using System;

namespace BreathNDrinkClassLibrary
{
    public class AlcoholMeasurement
    {
        private double _measurement;
        private string _userId;
        private DateTime _timeStamp;

        public double Measurement
        {
            get
            {
                return _measurement;
            }
            set
            {
                _measurement = value;
            }
        }

        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return _timeStamp;
            }
            set
            {
                _timeStamp = value;
            }
        }
    }
}
