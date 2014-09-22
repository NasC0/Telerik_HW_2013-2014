using System;
using System.Collections.Generic;

namespace FriendsOfPesho
{
    public class Node<T> : IComparable
    {
        T value;
        
        public Node(T value, NodeType type)
        {
            this.Value = value;
            this.Connections = new HashSet<Connection<T>>();
            this.DijkstraDistance = 0;
            this.Type = type;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ICollection<Connection<T>> Connections { get; set; }

        public double DijkstraDistance { get; set; }

        public NodeType Type { get; set; }

        public void AddConnection(Connection<T> connection)
        {
            this.Connections.Add(connection);
        }

        public void AddConnection(Node<T> destination, double distance)
        {
            this.Connections.Add(new Connection<T>(this, destination, distance));
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Node<T>))
            {
                return -1;
            }

            return this.DijkstraDistance.CompareTo((obj as Node<T>).DijkstraDistance);
        }

        public override bool Equals(object obj)
        {
            var objAsNode = obj as Node<T>;
            if (objAsNode == null)
            {
                return false;
            }
            return this.DijkstraDistance == objAsNode.DijkstraDistance;
        }
    }
}
