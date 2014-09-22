/* 5. Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. 
 * The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
 * The output should be a single number in a separate text file. */

using System;
using System.IO;

class MatrixSum
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");

        using (sr)
        {
            int size;
            string line = sr.ReadLine();
            int.TryParse(line, out size);

            int[,] matrix = new int[size, size];

            line = sr.ReadLine();
            int rows = 0;

            while (line != null)
            {
                string[] splitLine = line.Split(' ');

                for (int i = 0; i < splitLine.Length; i++)
                {
                    int.TryParse(splitLine[i], out matrix[rows, i]);
                }

                rows++;
                line = sr.ReadLine();
            }

            StreamWriter sw = new StreamWriter("../../result.txt");

            int maxSum = 0;

            for (int row = 0; row < size - 1; row++)
            {
                for (int col = 0; col < size - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            using (sw)
            {
                sw.WriteLine(maxSum);
            }
        }

        Console.WriteLine("Maximum sum saved in \"result.txt\"");
    }
}
