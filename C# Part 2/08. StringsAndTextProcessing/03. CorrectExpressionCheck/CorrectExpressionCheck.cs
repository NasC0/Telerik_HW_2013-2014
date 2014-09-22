/* Write a program to check if in a given expression the brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)). */

using System;

class CorrectExpressionCheck
{
    static bool IsCorrectExpression(string expression)
    {
        int bracketCount = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == ')' && bracketCount == 0)
            {
                return false;
            }
            else if (expression[i] == '(')
            {
                bracketCount++;
            }
            else if (expression[i] == ')')
            {
                bracketCount--;
            }
        }

        if (bracketCount != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static void Main()
    {
        Console.WriteLine("Please enter your expression: ");
        string expression = Console.ReadLine();

        if (IsCorrectExpression(expression) == true)
        {
            Console.WriteLine("The expression {0} is correct", expression);
        }
        else
        {
            Console.WriteLine("The expression {0} is incorrect", expression);
        }
    }
}
