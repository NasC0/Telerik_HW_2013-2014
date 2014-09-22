namespace FriendsOfPesho
{
    public class Connection<T>
    {
        public Connection(Node<T> source, Node<T> destination, double distance)
        {
            this.Source = source;
            this.Destination = destination;
            this.Distance = distance;
        }

        public Node<T> Source { get; set; }

        public Node<T> Destination { get; set; }

        public double Distance { get; set; }
    }
}
