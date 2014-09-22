/* Task 1. Define GSM class */

namespace CellularClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class GSM
    {
        /* Task 6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S. */
        private static readonly GSM iPhone4S = new GSM("IPhone 4s", "Apple", 499.99, "None", new Battery("normal", BatteryType.LiIon), new Display("3,7\""));

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        private string model;
        private string manufacturer;
        private double? price;
        private string owner;

        // Task 2. Multiple constructors
        public GSM(string phoneModel, string phoneManufacturer)
            : this(phoneModel, phoneManufacturer, null, null, null, null)
        {

        }

        public GSM(string phoneModel, string phoneManufacturer, double? phonePrice)
            : this(phoneModel, phoneManufacturer, phonePrice, null, null, null)
        {

        }

        public GSM(string phoneModel, string phoneManufacturer, double? phonePrice, string phoneOwner)
            : this(phoneModel, phoneManufacturer, phonePrice, phoneOwner, null, null)
        {

        }

        public GSM(string phoneModel, string phoneManufacturer, double? phonePrice, string phoneOwner, Battery phoneBattery)
            : this(phoneModel, phoneManufacturer, phonePrice, phoneOwner, phoneBattery, null)
        {

        }

        public GSM(string phoneModel, string phoneManufacturer, double? phonePrice, string phoneOwner, Battery phoneBattery, Display phoneDisplay)
        {
            this.Model = phoneModel;
            this.Manufacturer = phoneManufacturer;
            this.Price = phonePrice;
            this.Owner = phoneOwner;
            this.PhoneBattery = phoneBattery;
            this.PhoneDisplay = phoneDisplay;
            this.CallHistory = new List<Call>();
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
                if (value.Length <= 1)
                {
                    throw new ArgumentOutOfRangeException("Phone model cannot be shorter than 2 symbols.");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value.Length <= 1)
                {
                    throw new ArgumentOutOfRangeException("Phone manufacturer cannot be shorter than 2 symbols.");
                }

                this.manufacturer = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Phone price cannot be 0 or negative.");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (value != null && value.Length <= 1)
                {
                    throw new ArgumentOutOfRangeException("Phone owner name cannot be shorter than 2 symbols.");
                }

                if (!string.IsNullOrEmpty(this.owner) && string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Phone owner name cannot be null or empty.");
                }

                this.owner = value;
            }
        }

        public Battery PhoneBattery { get; set; }
        public Display PhoneDisplay { get; set; }

        /* Task 9. Add a property CallHistory in the GSM class to hold a list of the performed calls. 
         * Try to use the system class List<Call>. */
        public List<Call> CallHistory { get; private set; }

        /* Task 4. Add a method in the GSM class for displaying all information about it. Try to override ToString(). */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Model: {0} \n", this.Model);
            sb.AppendFormat("Manufacturer: {0} \n", this.Manufacturer);
            if (this.Price != null)
            {
                sb.AppendFormat("Price: {0} \n", this.Price);
            }
            if (this.Owner != null)
            {
                sb.AppendFormat("Owner: {0} \n", this.Owner);
            }
            if (this.PhoneBattery != null)
            {
                sb.Append(this.PhoneBattery.ToString());
            }
            if (this.PhoneDisplay != null)
            {
                sb.Append(this.PhoneDisplay.ToString());
            }

            return sb.ToString();
        }

        /* Task 10. Add methods in the GSM class for adding and deleting calls from the calls history. 
         * Add a method to clear the call history. */
        public void AddCall(DateTime timeOfCall, string number, int duration)
        {
            this.CallHistory.Add(new Call(timeOfCall, number, duration));
        }

        public void DeleteCall(int index)
        {
            this.CallHistory.RemoveAt(index);
        }

        public void ClearHistory()
        {
            this.CallHistory.Clear();
        }

        /* Task 11. Add a method that calculates the total price of the calls in the call history. 
         * Assume the price per minute is fixed and is provided as a parameter. */
        public decimal CalculateTotalCallPrice(decimal pricePerMinute)
        {
            double totalDuration = 0;
            foreach (var call in CallHistory)
            {
                totalDuration += call.Duration;
            }

            double totalMinutes = totalDuration / 60;
            decimal totalPrice = (decimal)totalMinutes * pricePerMinute;

            return totalPrice;
        }
    }
}
