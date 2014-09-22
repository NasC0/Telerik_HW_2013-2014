/* 02. Write a program that concatenates two text files into another text file. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class ConcatFiles
{
    static void Main()
    {
        StreamWriter rw = new StreamWriter("../../result.txt");

        using (rw)
        {
            StreamReader firstReader = new StreamReader("../../first_input.txt");

            using (firstReader)
            {
                string line = firstReader.ReadLine();
                while (line != null)
                {
                    rw.WriteLine(line);
                    line = firstReader.ReadLine();
                }

                rw.WriteLine();
            }

            StreamReader secondReader = new StreamReader("../../second_input.txt");

            using (secondReader)
            {
                string line = secondReader.ReadLine();

                while (line != null)
                {
                    rw.WriteLine(line);
                    line = secondReader.ReadLine();
                }

                rw.WriteLine();
            }
        }

        Console.WriteLine("File concatenation succesful");
    }
}
