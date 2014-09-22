int value = 0;
for (int i = 0; i < 100; i++) 
{
    if (i % 10 == 0)
    {
        Console.WriteLine(array[i]);
        if (array[i] == expectedValue) 
        {
            value = 666;
        }
    }
    else
    {
        Console.WriteLine(array[i]);
    }
}
// More code here
if (value == 666)
{
    Console.WriteLine("Value Found");
}