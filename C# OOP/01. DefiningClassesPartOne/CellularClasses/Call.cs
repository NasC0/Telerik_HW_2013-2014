/* 8. Create a class Call to hold a call performed through a GSM. 
 * It should contain date, time, dialed phone number and duration (in seconds). */

namespace CellularClasses
{
    using System;

    public class Call
    {
        private DateTime callDate;
        private string dialedNumber;
        private int duration;

        public Call(DateTime timeOfCall, string number, int callDuration)
        {
            this.CallDate = timeOfCall;
            this.Number = number;
            this.Duration = callDuration;
        }

        public DateTime CallDate
        {
            get
            {
                return this.callDate;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Date and time of call cannot be null.");
                }
                this.callDate = value;
            }
        }

        public string Number
        {
            get
            {
                return this.dialedNumber;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Dialed number cannot be null or empty.");
                }

                if (value.Length <= 5)
                {
                    throw new ArgumentOutOfRangeException("Dialed number must at least 5 digits long.");
                }

                this.dialedNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Call duration cannot be 0 or negative seconds.");
                }

                this.duration = value;
            }
        }

        public override string ToString()
        {
            return string.Join("\n", this.CallDate.ToString(), this.Number, this.Duration.ToString());
        }
    }
}
