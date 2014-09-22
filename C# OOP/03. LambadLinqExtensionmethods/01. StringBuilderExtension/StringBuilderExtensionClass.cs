namespace StringBuilderExtension
{
    using System;
    using System.Text;
    public static class StringBuilderExtensionClass
    {
        public static StringBuilder Substring(this StringBuilder sr, int startIndex)
        {
            StringBuilder result = new StringBuilder();
            for (int i = startIndex; i < sr.Length; i++)
            {
                result.Append(sr[i]);
            }

            return result;
        }

        public static StringBuilder Substring(this StringBuilder sr, int startIndex, int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(sr[startIndex]);
                startIndex++;
            }

            return result;
        }
    }
}
