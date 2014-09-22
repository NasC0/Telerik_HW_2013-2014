using System;

class Program
{
    static void Main(string[] args)
    {
        int cat1 = 0;
        int cat2 = 0;
        int cat3 = 0;
        int cat4 = 0;
        int cat5 = 0;
        int cat6 = 0;
        int cat7 = 0;
        int cat8 = 0;
        int cat9 = 0;
        int cat10 = 0;

        int voters = int.Parse(Console.ReadLine());

        for (int i = 0; i < voters; i++)
        {
            int vote = int.Parse(Console.ReadLine());

            switch (vote)
            {
                case 1:
                    cat1++;
                    break;
                case 2:
                    cat2++;
                    break;
                case 3:
                    cat3++;
                    break;
                case 4:
                    cat4++;
                    break;
                case 5:
                    cat5++;
                    break;
                case 6:
                    cat6++;
                    break;
                case 7:
                    cat7++;
                    break;
                case 8:
                    cat8++;
                    break;
                case 9:
                    cat9++;
                    break;
                case 10:
                    cat10++;
                    break;
                default:
                    Console.WriteLine("blabla");
                    break;
            }
        }

        int greatest = 0;
        int winnerCat = 0;

        if (cat1 > greatest)
        {
            greatest = cat1;
            winnerCat = 1;
        }
        if (cat2 > greatest)
        {
            greatest = cat2;
            winnerCat = 2;
        }
        if (cat3 > greatest)
        {
            greatest = cat3;
            winnerCat = 3;
        }
        if (cat4 > greatest)
        {
            greatest = cat4;
            winnerCat = 4;
        }
        if (cat5 > greatest)
        {
            greatest = cat5;
            winnerCat = 5;
        }
        if (cat6 > greatest)
        {
            greatest = cat6;
            winnerCat = 6;
        }
        if (cat7 > greatest)
        {
            greatest = cat7;
            winnerCat = 7;
        }
        if (cat8 > greatest)
        {
            greatest = cat8;
            winnerCat = 8;
        }
        if (cat9 > greatest)
        {
            greatest = cat9;
            winnerCat = 9;
        }
        if (cat10 > greatest)
        {
            greatest = cat10;
            winnerCat = 10;
        }
        Console.WriteLine(winnerCat);
    }
}