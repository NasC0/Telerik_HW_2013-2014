using System;
using System.Text;

class DrunkenNumbers
{
    static void Main()
    {
        int numOfRounds = int.Parse(Console.ReadLine());

        int mitkoBeers = 0;
        int vladoBeers = 0;
        for (int i = 0; i < numOfRounds; i++)
        {
            int drunkenNumerInput;
            int.TryParse(Console.ReadLine(), out drunkenNumerInput);

            if (drunkenNumerInput < 0)
            {
                drunkenNumerInput *= -1;
            }

            string drunkenNumber = drunkenNumerInput.ToString();
            int drunkenNumberLength = drunkenNumber.Length;
            int size = drunkenNumberLength / 2;

            int initialNumber = 0;
            if (drunkenNumberLength % 2 != 0)
            {
                initialNumber = (int)Char.GetNumericValue(drunkenNumber[size]);
            }

            mitkoBeers += initialNumber;
            vladoBeers += initialNumber;

            int start = 0;
            int end = drunkenNumberLength - 1;
            for (int k = 0; k < size; k++)
            {
                mitkoBeers += (int)Char.GetNumericValue(drunkenNumber[start]);
                vladoBeers += (int)Char.GetNumericValue(drunkenNumber[end]);

                start++;
                end--;
            }
        }
        if (mitkoBeers > vladoBeers)
        {
            Console.WriteLine("M " + (mitkoBeers - vladoBeers));
        }
        else if (vladoBeers > mitkoBeers)
        {
            Console.WriteLine("V " + (vladoBeers - mitkoBeers));
        }
        else
        {
            Console.WriteLine("No " + (vladoBeers + mitkoBeers) );
        }
    }
}
