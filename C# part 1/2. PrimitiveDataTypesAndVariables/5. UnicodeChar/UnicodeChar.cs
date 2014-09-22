/* 5. Declare a character variable and assign it with the symbol that has Unicode code 72. 
 * Hint: first use the Windows Calculator to find the hexadecimal representation of 72. */

using System;

class UnicodeChar
{
    static void Main()
    {
        char unicodeChar = '\u0072';
        Console.WriteLine(unicodeChar);
    }
}
