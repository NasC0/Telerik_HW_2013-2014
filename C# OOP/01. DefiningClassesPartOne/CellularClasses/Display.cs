/* Task 1. Define Display Class */

namespace CellularClasses
{
    using System;
    using System.Text;
    public class Display
    {
        private string size;
        private int? colors;

        /* Task 2. Multiple Constructors */
        public Display(string size)
            : this(size, null)
        {
            
        }

        public Display(string displaySize, int? displayColors)
        {
            this.Size = displaySize;
            this.Colors = displayColors;
        }

        // Task 5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
        public int? Colors
        {
            get
            {
                return this.colors;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number of colors cannot be 0 or negative.");
                }

                this.colors = value;
            }
        }

        public string Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Display Size cannot be null or empty.");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Display Size must be longer than 2 symbols");
                }

                this.size = value;
            }
        }

        // Task 4.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Display size: {0} \n", this.Size);
            if (this.Colors != null)
            {
                sb.AppendFormat("Display colors: {0} \n", this.Colors);
            }

            return sb.ToString();
        }
    }
}
