/* 3. A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. 
 * Write a program that reads the information about a company and its manager and prints them on the console. */

using System;

class CompanyVariables
{
    static void Main()
    {
        Console.Write("Please enter the company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Please enter the company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Please enter the company phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Please enter the company fax numer: ");
        string faxNumber = Console.ReadLine();
        Console.Write("Please enter the company web site: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Please enter the manager's first and last name: ");
        string managerName = Console.ReadLine();
        Console.Write("Please enter the manager's age: ");
        byte managerAge = byte.Parse(Console.ReadLine());
        Console.Write("Please enter the manager's phone number: ");
        string managerPhoneNumber = Console.ReadLine();

        Console.WriteLine("Company name: {0}", companyName);
        Console.WriteLine("Company address: {0}", companyAddress);
        Console.WriteLine("Company phone number: {0}", phoneNumber);
        Console.WriteLine("Company fax number: {0}", faxNumber);
        Console.WriteLine("Company web site: {0}", companyWebSite);
        Console.WriteLine("Manager name: {0}", managerName);
        Console.WriteLine("Manager age: {0}", managerAge);
        Console.WriteLine("Manager phone number: {0}", managerPhoneNumber);
    }
}
