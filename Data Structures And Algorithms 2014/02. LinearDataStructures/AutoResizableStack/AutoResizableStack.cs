using System;
namespace AutoResizableStack
{
    public class AutoResizableStack
    {
        public static void Main()
        {
            AutoResStack<int> userImplemenetedStack = new AutoResStack<int>();
            userImplemenetedStack.Push(2);
            userImplemenetedStack.Push(3);
            userImplemenetedStack.Push(5);
            userImplemenetedStack.Push(10);
            userImplemenetedStack.Push(11);

            Console.WriteLine(userImplemenetedStack.Count);
            Console.WriteLine(userImplemenetedStack.Pop());
            Console.WriteLine(userImplemenetedStack.Pop());
            Console.WriteLine(userImplemenetedStack.Pop());

            userImplemenetedStack.Push(90);
            Console.WriteLine(userImplemenetedStack.Peek());

            userImplemenetedStack.Push(900);
            Console.WriteLine(userImplemenetedStack.Pop());
            Console.WriteLine(userImplemenetedStack.Pop());
            Console.WriteLine(userImplemenetedStack.Pop());
            Console.WriteLine(userImplemenetedStack.Pop());
            Console.WriteLine(userImplemenetedStack.Pop());
        }
    }
}
