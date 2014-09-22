/* 07. * Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
 * Real numbers, e.g. 5, 18.33, 3.14159, 12.6
 * Arithmetic operators: +, -, *, / (standard priorities)
 * Mathematical functions: ln(x), sqrt(x), pow(x,y)
 * Brackets (for changing the default priorities)
 * Examples:
 * (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
 * pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
 * Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation". */


using System;
using System.Collections.Generic;
using System.Text;

class MathExpressionCalculator
{
    static List<char> operators = new List<char>() { '+', '-', '*', '/' };
    static List<char> brackets = new List<char>() { '(', ')' };
    static List<char> numbers = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
    static List<string> functions = new List<string>() { "pow", "ln", "sqrt" };

    // RPN - Reverse Polish Notation
    static double RPNCalculate(string rpn)
    {
        string[] split = rpn.Split(',');
        Stack<double> stack = new Stack<double>();
        Queue<string> queue = new Queue<string>();

        for (int i = 0; i < split.Length; i++)
        {
            double currentNumber;
            string operatorString;
            if (double.TryParse(split[i], out currentNumber))
            {
                stack.Push(currentNumber);
            }
            else
            {
                operatorString = split[i];
                switch (operatorString)
                {
                    case "+":
                        if (stack.Count < 2)
                        {
                            throw new ArgumentOutOfRangeException("Insufficient operands!");
                        } 
                        else
                        {
                            double firstOperand = stack.Pop(), secondOperand = stack.Pop();
                            double result = firstOperand + secondOperand;
                            stack.Push(result);
                        }
                        break;
                    case "-":
                        if (stack.Count < 2)
                        {
                            throw new ArgumentOutOfRangeException("Insufficient operands!");
                        }
                        else
                        {
                            double firstOperand = stack.Pop(), secondOperand = stack.Pop();
                            double result = secondOperand - firstOperand;
                            stack.Push(result);
                        }
                        break;
                    case "*":
                        if (stack.Count < 2)
                        {
                            throw new ArgumentOutOfRangeException("Insufficient operands!");
                        }
                        else
                        {
                            double firstOperand = stack.Pop(), secondOperand = stack.Pop();
                            double result = secondOperand * firstOperand;
                            stack.Push(result);
                        }
                        break;
                    case "/":
                        if (stack.Count < 2)
                        {
                            throw new ArgumentOutOfRangeException("Insufficient operands!");
                        }
                        else
                        {
                            double firstOperand = stack.Pop(), secondOperand = stack.Pop();
                            double result = secondOperand / firstOperand;
                            stack.Push(result);
                        }
                        break;
                    case "ln":
                        if (stack.Count < 1)
                        {
                            throw new ArgumentOutOfRangeException("Insufficient operands!");
                        }
                        else
                        {
                            double firstOperand = stack.Pop();
                            double result = Math.Log(firstOperand);
                            stack.Push(result);
                        }
                        break;
                    case "sqrt":

                        if (stack.Count < 1)
                        {
                            throw new ArgumentOutOfRangeException("Insufficient operands!");
                        }
                        else
                        {
                            double firstOperand = stack.Pop();
                            double result = Math.Sqrt(firstOperand);
                            stack.Push(result);
                        }
                        break;
                    case "pow":
                        if (stack.Count < 2)
                        {
                            throw new ArgumentOutOfRangeException("Insufficient operands!");
                        }
                        else
                        {
                            double firstOperand = stack.Pop(), secondOperand = stack.Pop();
                            double result = Math.Pow(secondOperand, firstOperand);
                            stack.Push(result);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        return stack.Pop();
    }

    static string TrimWhitespace(string input)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
            {
                result.Append(input[i].ToString());
            }
        }

        return result.ToString();
    }

    static List<string> SplitInput(string input)
    {
        List<string> result = new List<string>();
        bool isFloatingPoint = false;
        bool isFunction = false;
        bool isMultipartNumber = false;
        StringBuilder holder = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i - 1] == ',' || input[i - 1] == '('))
            {
                holder.Append('-');
                if (input[i + 2] == '.')
                {
                    isFloatingPoint = true;
                    holder.Append(input[i + 1]);
                    i++;
                }
                else
                {
                    isMultipartNumber = true;
                }
            }
            else if (isFloatingPoint)
            {
                if ((numbers.Contains(input[i]) || input[i] == '.') && i != input.Length - 1 && numbers.Contains(input[i + 1]))
                {
                    holder.Append(input[i].ToString());
                }
                else
                {
                    holder.Append(input[i].ToString());
                    result.Add(holder.ToString());
                    holder.Clear();
                    isFloatingPoint = false;
                }
            }
            else if (isMultipartNumber)
            {
                if (i != input.Length - 1 && numbers.Contains(input[i + 1]))
                {
                    holder.Append(input[i].ToString());
                }
                else
                {
                    holder.Append(input[i]);
                    result.Add(holder.ToString());
                    holder.Clear();
                    isMultipartNumber = false;
                }
            }
            else if (isFunction)
            {
                if (i != input.Length - 1 && !operators.Contains(input[i + 1]) && !brackets.Contains(input[i + 1]))
                {
                    holder.Append(input[i].ToString().ToLower());
                }
                else
                {
                    holder.Append(input[i].ToString().ToLower());
                    result.Add(holder.ToString());
                    holder.Clear();
                    isFunction = false;
                }
            }
            else if (operators.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (brackets.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            else if (numbers.Contains(input[i]))
            {
                if (i != input.Length - 1 && input[i + 1] == '.')
                {
                    holder.Append(input[i]);
                    isFloatingPoint = true;
                }
                else if (i != input.Length - 1 && numbers.Contains(input[i + 1]))
                {
                    holder.Append(input[i]);
                    isMultipartNumber = true;
                }
                else
                {
                    result.Add(input[i].ToString());
                }
            }
            else if (input[i] == ',')
            {
                result.Add(",");
            }
            else
            {
                isFunction = true;
                holder.Append(input[i].ToString().ToLower());
            }
        }

        return result;
    }

    public static Queue<string> ConvertToRPN(List<string> input)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();
        for (int i = 0; i < input.Count; i++)
        {
            var token = input[i];
            double number;

            if (double.TryParse(token, out number))
            {
                queue.Enqueue(number.ToString());
            }
            else if (functions.Contains(token))
            {
                stack.Push(token);
            }
            else if (token == "," && stack.Count > 0)
            {
                if (!stack.Contains("("))
                {
                    throw new ArgumentException("Invalid expression!");
                }
                while (stack.Peek() != "(" && stack.Count > 0)
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            else if (operators.Contains(token[0]))
            {
                while (stack.Count != 0)
                {
                    if ((stack.Peek() == "+" || stack.Peek() == "-") && (token == "*" || token == "/"))
                    {
                        break;
                    }
                    else if(operators.Contains(stack.Peek()[0]))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    else
                    {
                        break;
                    }
                }
                stack.Push(token);
            }
            else if (token == "(")
            {
                stack.Push(token);
            }
            else if (token == ")")
            {
                if (!stack.Contains("("))
                {
                    throw new ArgumentException("Invalid expression!");
                }
                while (stack.Peek() != "(" && stack.Count > 0)
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Pop();
                if (stack.Count != 0 && functions.Contains(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
            }
        }
        if (stack.Contains("(") || stack.Contains(")"))
        {
            throw new ArgumentException("Invalid expression!");
        }
        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        return queue;
    }

    public static string ConvertToRPNString(Queue<string> input)
    {
        StringBuilder sb = new StringBuilder();
        while (input.Count > 0)
        {
            sb.Append(input.Dequeue());
            sb.Append(',');
        }

        return sb.ToString();
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string trimmedInput = TrimWhitespace(input);
        var splitInput = SplitInput(trimmedInput);

        var queue = ConvertToRPN(splitInput);
        string RPNString = ConvertToRPNString(queue);
        Console.Write("Reverse Polish Notation: ");
        Console.WriteLine(RPNString);

        double result = RPNCalculate(RPNString);
        Console.WriteLine();
        Console.WriteLine("Result: {0:0.00}", result);
    }
}
