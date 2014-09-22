/* 10. Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. */

using System;
using System.Text;

class ConvertStringToUnicodeChars
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string original = "Hello C#!";
        for (int i = 0; i < original.Length; i++)
        {
            ushort unicode = (ushort)original[i];
            sb.Append(String.Format(@"\u{0:x4}", unicode));
            sb.Append(" ");
        }
        Console.WriteLine(sb);
    }
}
