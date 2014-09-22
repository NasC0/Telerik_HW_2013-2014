/* Task 1. Define Battery Class */

namespace CellularClasses
{
    using System;
    using System.Text;
    public class Battery
    {
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;

        /* Task 3. Use BatteryType enum as a field in Battery class */
        private BatteryType batteryType;

        /* Task 2. Multiple Constructors */
        public Battery(string model, BatteryType typeOfBattery)
            : this(model, typeOfBattery, null, null)
        {
            
        }

        public Battery(string model, BatteryType typeOfBattery, double? hoursIdle)
            : this(model, typeOfBattery, hoursIdle, null)
        {
            
        }

        public Battery(string batteryModel, BatteryType typeOfBattery, double? batteryHoursIdle, double? batteryHoursTalk)
        {
            this.Model = batteryModel;
            this.HoursIdle = batteryHoursIdle;
            this.HoursTalk = batteryHoursTalk;
            this.BatteryType = typeOfBattery;
        }

        // Task 5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Battery model cannot be null or empty");
                }

                if (value.Length <= 1)
                {
                    throw new ArgumentOutOfRangeException("Battery model must be at least 2 symbols long");
                }

                this.model = value;
            }
        }

        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            private set
            {
                if (hoursIdle <= 0)
                {
                    throw new ArgumentOutOfRangeException("Battery idle hours cannot be 0 or negative.");
                }

                this.hoursIdle = value;
            }
        }

        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Battery talk hours cannot be 0 or negative.");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            private set
            {
                this.batteryType = value;
            }
        }
        
        // Task 4.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Battery Model: {0} \n", this.Model);
            sb.AppendFormat("Battery Type: {0} \n", this.BatteryType);
            if (this.HoursIdle != null)
            {
                sb.AppendFormat("Idle hours: {0} \n", this.HoursIdle);
            }
            if (this.HoursTalk != null)
            {
                sb.AppendFormat("Talk hours: {0} \n", this.HoursTalk);
            }

            return sb.ToString();
        }
    }
}
