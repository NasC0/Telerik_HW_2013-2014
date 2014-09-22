/* Task 5. Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=. */

namespace _05.BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private int[] bitArray;

        public BitArray64()
        {
            this.bitArray = new int[64];
        }

        public BitArray64(byte[] array)
        {
            if (array.Length != this.bitArray.Length)
            {
                throw new ArgumentException("Invalid array passed.");
            }

            foreach (var bit in array)
            {
                if (bit > 1 || bit < 0)
                {
                    throw new ArgumentException("Invalid bit values passed.");
                }
            }

            this.bitArray = array.Clone() as int[];
        }

        public BitArray64(ulong value)
        {
            // BitConverter returns byte[] array, so i have to cast it through Array.ConvertAll()
            this.bitArray = Array.ConvertAll(BitConverter.GetBytes(value), b => (int)b);
        }

        public ulong Value
        {
            get
            {
                // BitConverter only accepts byte[] array, so i have to cast the class member bitArray to byte[] through Array.ConvertALl()
                return BitConverter.ToUInt64(Array.ConvertAll(bitArray, b => (byte) b), 0);
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= this.bitArray.Length || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Specified index was outside the bounds of the array.");
                }

                return this.bitArray[index];
            }
            set
            {
                if (index >= this.bitArray.Length || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Specified index was outside the bounds of the array.");
                }

                if (value > 1 || value < 0)
                {
                    throw new ArgumentException("Invalid value specified.");
                }

                this.bitArray[index] = value;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < bitArray.Length; i++)
            {
                yield return bitArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            BitArray64 otherArray = obj as BitArray64;

            if (otherArray == null)
            {
                return false;
            }

            return this.Value == otherArray.Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode() ^ this.bitArray[0].GetHashCode() ^ this.bitArray[this.bitArray.Length - 1].GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this[0]);
            for (int i = 1; i < this.bitArray.Length; i++)
            {
                if (i % 4 == 0)
                {
                    result.Append(' ');
                }

                result.Append(this[i]);
            }

            return result.ToString();
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
    }
}
