namespace PriorityQueueImplementation
{
    public class PriorityQueueImplementation
    {
        public static void Main()
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(PriorityQueueOrder.MaxPriority);
            priorityQueue.Enqueue(4);
            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(200);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(200);
            System.Console.WriteLine(priorityQueue.Dequeue());
        }
    }
}
