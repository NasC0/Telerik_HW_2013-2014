using System;

class Fire
{
    static void Main()
    {
        int torchSize = int.Parse(Console.ReadLine());
        int usableSize = torchSize / 2;

        for (int k = 1; k <= usableSize; k++)
        {
            Console.Write(new string('.', usableSize - k));
            Console.Write('#');
            Console.Write(new string('.', (k - 1) * 2));
            Console.Write('#');
            Console.WriteLine(new string('.', usableSize - k));
        }

        for (int j = 1; j <= torchSize / 4; j++)
        {
            Console.Write(new string('.', j - 1));
            Console.Write('#');
            Console.Write(new string('.', (torchSize / 2 - j) * 2));
            Console.Write('#');
            Console.WriteLine(new string('.', j - 1));
        }

        Console.WriteLine(new string('-', torchSize));

        for (int i = 1; i <= usableSize; i++)
        {
            Console.Write(new string('.', i - 1));
            Console.Write(new string('\\', usableSize - (i - 1)));
            Console.Write(new string('/', usableSize - (i - 1)));
            Console.WriteLine(new string('.', i - 1));
        }
    }
}
