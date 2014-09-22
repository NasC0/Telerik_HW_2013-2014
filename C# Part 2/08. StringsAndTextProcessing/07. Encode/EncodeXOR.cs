/* 07. Write a program that encodes and decodes a string using given encryption key (cipher). 
 * The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) 
 * operation over the first letter of the string with the first of the key, the second – with the second, etc. 
 * When the last key character is reached, the next is the first. */

using System;
using System.Text;

class EncodeXOR
{
    static string EncodeDecode(string message, string cypher)
    {
        StringBuilder codedMessage = new StringBuilder();

        if (message.Length < cypher.Length)
        {
            int messageIndex = 0;
            for (int i = 0; i < cypher.Length; i++)
            {
                if (messageIndex >= message.Length)
                {
                    messageIndex = 0;
                }

                codedMessage.Append(message[messageIndex] ^ cypher[i]);
                messageIndex++;
            }
        }
        else if (cypher.Length < message.Length)
        {
            int cypherIndex = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (cypherIndex >= cypher.Length)
                {
                    cypherIndex = 0;
                }

                codedMessage.Append(message[i] ^ cypher[cypherIndex]);
                cypherIndex++;
            }
        }
        else
        {
            for (int i = 0; i < message.Length; i++)
            {
                codedMessage.Append(message[i] ^ cypher[i]);
            }
        }

        return codedMessage.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Enter your message:");
        string message = Console.ReadLine();
        Console.WriteLine("Enter your cypher:");
        string cypher = Console.ReadLine();

        string codedMessage = EncodeDecode(message, cypher);
        Console.WriteLine(codedMessage);
    }
}
