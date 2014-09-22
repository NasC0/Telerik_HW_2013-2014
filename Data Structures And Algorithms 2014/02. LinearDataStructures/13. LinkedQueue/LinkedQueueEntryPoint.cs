namespace LinkedQueue
{
    public class LinkedQueueEntryPoint
    {
        public static void Main()
        {
            LinkedQueue<int> linkedQueueTest = new LinkedQueue<int>();

            linkedQueueTest.Enqueue(1);
            linkedQueueTest.Enqueue(2);
            linkedQueueTest.Enqueue(3);
            linkedQueueTest.Enqueue(4);
            linkedQueueTest.Enqueue(5);

            System.Console.WriteLine(linkedQueueTest.Dequeue());
            System.Console.WriteLine(linkedQueueTest.Dequeue());
            System.Console.WriteLine(linkedQueueTest.Dequeue());
            System.Console.WriteLine(linkedQueueTest.Dequeue());
            System.Console.WriteLine(linkedQueueTest.Dequeue());
            System.Console.WriteLine(linkedQueueTest.Dequeue());
        }
    }
}
