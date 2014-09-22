using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static int[] CountOccurence(List<int> list)
    {
        int[] occurences = new int[11];

        for (int i = 0; i < list.Count; i++)
        {
            occurences[list[i]]++;
        }

        return occurences;
    }
    static void Main()
    {
        //StreamWriter sw = new StreamWriter("../../test.txt");
        //Random generate = new Random();
        //List<int> generatedList = new List<int>();
        //for (int i = 0; i < generate.Next(10000, 99001); i++)
        //{
        //    generatedList.Add(generate.Next(1, 11));
        //}

        //using (sw)
        //{
        //    for (int i = 0; i < generatedList.Count; i++)
        //    {
        //        sw.WriteLine(generatedList[i]);
        //    }
        //    StreamWriter swTwo = new StreamWriter("../../occurences.txt");
        //    int[] occurence = CountOccurence(generatedList);
        //    using (swTwo)
        //    {
        //        for (int i = 0; i < occurence.Length; i++)
        //        {
        //            swTwo.WriteLine(String.Format("{0} {1}", i, occurence[i]));
        //            Console.WriteLine(String.Format("{0} {1}", i , occurence[i]));
        //        }
        //    }
        //}

        Console.WriteLine(1 - (-1));
    }
}
