/* Task 7. Write a class GSMTest to test the GSM class:
 * Create an array of few instances of the GSM class.
 * Display the information about the GSMs in the array.
 * Display the information about the static property IPhone4S. */

using CellularClasses;
using System;
using System.Collections.Generic;

class GSMTest
{
    static void Main()
    {
        List<GSM> cellPhones = new List<GSM>();

        GSM currentGSM = new GSM("Galaxy SIV", "Samsung", 999.99, "Ganka", new Battery("normal", BatteryType.LiIon, 500, 250), new Display("5.0\"", 16000000));
        cellPhones.Add(currentGSM);

        currentGSM = new GSM("One", "HTC", 949.99, "Tosho");
        cellPhones.Add(currentGSM);

        currentGSM = new GSM("Lumia", "Nokia", 799.99, "test", new Battery("duracell", BatteryType.NiMh));
        cellPhones.Add(currentGSM);

        foreach (var phone in cellPhones)
        {
            Console.WriteLine(phone.ToString());
        }

        Console.WriteLine(GSM.IPhone4S.ToString());

        currentGSM.AddCall(DateTime.Now, "0883412079", 75);

        Console.WriteLine(currentGSM.CalculateTotalCallPrice(0.50m));
    }
}
