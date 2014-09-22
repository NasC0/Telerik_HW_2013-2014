/* 8. Declare two string variables and assign them with following value:
    The "use" of quotations causes difficulties.
	Do the above in two different ways: with and without using quoted strings. */

using System;

class EscapingStrings
{
    static void Main()
    {
        string firstEscape = "The \"use\" of quotations causes difficulties";
        string secondEscape = @"The ""use"" of quotations causes difficulties";

        Console.WriteLine(firstEscape);
        Console.WriteLine(secondEscape);
    }
}
