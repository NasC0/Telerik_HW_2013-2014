/* 12. We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
	Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
	n = 5 (00000101), p=2, v=0 -> 1 (00000001) */

using System;

class ModifyBit
{
    static void Main()
    {
        Console.WriteLine("Please input your number, value and position of the bit: ");
        int number, value, position;
        int.TryParse(Console.ReadLine(), out number);
        int.TryParse(Console.ReadLine(), out value);
        int.TryParse(Console.ReadLine(), out position);

        if (value == 1)
        {
            number = number | (1 << position);
            Console.WriteLine(number);
        }
        else if (value == 0)
        {
            number = number & (~ (1 << position));
            Console.WriteLine(number);
        }
    }
}