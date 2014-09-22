namespace _07.TimerClassWithDelegates
{
    using System;

    class TimerClassWithDelegatesTest
    {
        public static void PrintHello()
        {
            Console.WriteLine("Hello");
        }

        public static void PrintWorld()
        {
            Console.WriteLine("World");
        }

        static void Main()
        {
            Timer timerTest = new Timer(1000, 30);
            timerTest.ExecuteMethod += PrintHello;
            timerTest.ExecuteMethod += PrintWorld;

            timerTest.Execute();
        }
    }
}
