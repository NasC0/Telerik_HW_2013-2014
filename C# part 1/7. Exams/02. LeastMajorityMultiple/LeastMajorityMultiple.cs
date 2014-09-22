using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] numbers = new int[5];
        int greatest = 1;
        for (int i = 0; i < 5; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        while (true)
        {
            int divisionCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (greatest % numbers[i] == 0)
                {
                    divisionCount++;
                }
            }
            if (divisionCount >= 3)
            {
                Console.WriteLine(greatest);
                break;
            }
            greatest++;
        }
    }
}
