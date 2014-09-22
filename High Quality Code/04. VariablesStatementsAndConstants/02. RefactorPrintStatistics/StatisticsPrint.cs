using System;

public class StatisticsPrint
{
    public void PrintStatistics(double[] numbers, int maxLength)
    {
        double biggestElement = double.MinValue;
        for (int i = 0; i < maxLength; i++)
        {
            if (numbers[i] > biggestElement)
            {
                biggestElement = numbers[i];
            }
        }

        PrintMax(biggestElement);

        double smallestElement = double.MaxValue;
        for (int i = 0; i < maxLength; i++)
        {
            if (numbers[i] < smallestElement)
            {
                smallestElement = numbers[i];
            }
        }

        PrintMin(smallestElement);

        double totalSum = 0;
        for (int i = 0; i < maxLength; i++)
        {
            totalSum += numbers[i];
        }

        PrintAvg(totalSum / maxLength);
    }

    static void Main()
    {
    }
}
