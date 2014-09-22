using System;

class MissCat
{
    static void Main()
    {
        int voters = int.Parse(Console.ReadLine());

        byte[] cats = new byte[11];
        for (int i = 0; i < 10; i++)
        {
            cats[i] = 0;
        }

        int greatestVote = 0;
        int catsWithMaxVotes = 0;
        int index = 0;
        for (int i = 1; i <= voters; i++)
        {
            byte vote = byte.Parse(Console.ReadLine());

            cats[vote]++;
            if (cats[vote] > greatestVote)
            {
                greatestVote = cats[vote];
                index = vote;
            }
        }
        for (int i = 1; i < cats.Length; i++)
        {
            if (cats[i] == greatestVote)
            {
                catsWithMaxVotes++;
            }
        }
        if (catsWithMaxVotes < 2)
        {
            Console.WriteLine(index);
        }
        else
        {
            for (int i = 1; i < cats.Length; i++)
            {
                if (cats[i] == greatestVote)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}