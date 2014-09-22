/* 03. Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
 * Find in MSDN how to use System.IO.File.ReadAllText(…).
 * Be sure to catch all possible exceptions and print user-friendly error messages. */

using System;
using System.IO;

class ReadTextFromPath
{
    static void Main()
    {
        try
        {
            string path = Console.ReadLine();
            Console.WriteLine(File.ReadAllText(path));
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid path");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid path");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
        }
        catch (UnauthorizedAccessException accesEx)
        {
            Console.WriteLine(accesEx.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
    }
}
