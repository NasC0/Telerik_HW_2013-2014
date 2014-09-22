/* 04. Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. 
 * Find in Google how to download files in C#. 
 * Be sure to catch all exceptions and to free any used resources in the finally block. */

using System;
using System.Net;

class DownloadImage
{
    static void Main()
    {
        WebClient client = new WebClient();
        using (client)
        {
            try
            {
                Console.WriteLine("Downloading");
                string path = "http://www.devbg.org/img/Logo-BASD.jpg";
                client.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../logo.jpg");
                Console.WriteLine("Done");
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
