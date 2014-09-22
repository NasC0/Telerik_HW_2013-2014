/* Task 12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
 * Create an instance of the GSM class.
 * Add few calls.
 * Display the information about the calls.
 * Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
 * Remove the longest call from the history and calculate the total price again.
 * Finally clear the call history and print it. */

using CellularClasses;
using System;

class GSMCallHistoryTest
{
    static void Main()
    {
        // Initialise an object to the already set static property
        GSM currentGSM = GSM.IPhone4S;

        // Add some calls
        currentGSM.AddCall(DateTime.Now, "12315123", 43);
        currentGSM.AddCall(DateTime.Now, "123156341", 27);
        currentGSM.AddCall(DateTime.Now, "080823874", 132);

        // Get the longest duration call and display details about each call
        int longestDurationIndex = int.MinValue;
        int longestDuration = int.MinValue;
        for (int i = 0; i < currentGSM.CallHistory.Count; i++)
        {
            Console.WriteLine(currentGSM.CallHistory[i].ToString());
            Console.WriteLine();

            if (currentGSM.CallHistory[i].Duration > longestDuration)
            {
                longestDurationIndex = i;
                longestDuration = currentGSM.CallHistory[i].Duration;
            }
        }

        // Calculate total call history price
        Console.WriteLine("{0:0.00}", currentGSM.CalculateTotalCallPrice(0.37m));

        // Remove the longest duration call and recalculate the call history price
        currentGSM.DeleteCall(longestDurationIndex);

        Console.WriteLine("{0:0.00}", currentGSM.CalculateTotalCallPrice(0.37m));

        // Clear the call history
        currentGSM.ClearHistory();

        foreach (var call in currentGSM.CallHistory)
        {
            Console.WriteLine(call.ToString());
        }
    }
}
