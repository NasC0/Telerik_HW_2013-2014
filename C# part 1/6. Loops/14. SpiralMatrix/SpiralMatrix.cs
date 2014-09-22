/* 14. * Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral. */

using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the matrix: ");
        int size;
        int.TryParse(Console.ReadLine(), out size);
        int[,] matrix = new int[size, size];
        int counter = 1;
        int xPos = 0;
        int yPos = 0;
        int sizeHolder = size;
        bool breakWhile = false;
        while (counter <= size * size)
        {
            for (int i = 0; i < sizeHolder; i++)
            {
                if (counter > size * size)
                {
                    breakWhile = true;
                    break;
                }
                matrix[xPos, yPos] = counter;
                counter++;
                yPos++;
            }
            xPos++;
            yPos--;
            for (int i = 0; i < sizeHolder - 1; i++)
            {
                if (counter > size * size)
                {
                    breakWhile = true;
                    break;
                }
                matrix[xPos, yPos] = counter;
                counter++;
                xPos++;
            }
            xPos--;
            yPos--;
            for (int i = 0; i < sizeHolder - 1; i++)
            {
                if (counter > size * size)
                {
                    breakWhile = true;
                    break;
                }
                matrix[xPos, yPos] = counter;
                counter++;
                yPos--;
            }
            yPos++;
            xPos--;
            for (int i = 0; i < sizeHolder - 2; i++)
            {
                if (counter > size * size)
                {
                    breakWhile = true;
                    break;
                }

                matrix[xPos, yPos] = counter;
                counter++;
                xPos--;
            }
            if (breakWhile == true)
            {
                break;
            }
            xPos++;
            yPos++;
            sizeHolder -= 1;
        }
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
