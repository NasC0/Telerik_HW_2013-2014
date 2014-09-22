/* 9. Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
 * Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly. */

using System;

class CopyrightIsoscelesTriangle
{
    static void Main()
    {
        int copyright = 0169;

        Console.WriteLine("    {0}   ", (char)copyright);
        Console.WriteLine("   {0} {0}", (char) copyright);
        Console.WriteLine("  {0}   {0}", (char)copyright);
        Console.WriteLine(" {0} {0} {0} {0}", (char)copyright);
    }
}
