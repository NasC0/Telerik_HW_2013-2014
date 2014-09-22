/* 12. Write a program that parses an URL address given in the format: [protocol]://[server]/[resource]
		and extracts from it the [protocol], [server] and [resource] elements. */

using System;

class ExctraxtProtocolServerAndResources
{
    static void Main()
    {
        Console.Write("Enter the url: ");
        string url = Console.ReadLine();
        try
        {
            string protocol = url.Substring(0, url.IndexOf(':'));
            int index = url.IndexOf('/') + 2;
            int secondIndex = url.IndexOf('/', index);
            if (secondIndex == -1)
            {
                string server = url.Substring(index);
                Console.WriteLine("[protocol] = {0}", protocol);
                Console.WriteLine("[server] = {0}", server);
            }
            else
            {
                string server = url.Substring(index, secondIndex - index);
                string resource = url.Substring(secondIndex);
                Console.WriteLine("[protocol] = {0}", protocol);
                Console.WriteLine("[server] = {0}", server);
                Console.WriteLine("[resource] = {0}", resource);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please enter the website in the format: protocol://server/resource");
        }
    }
}

