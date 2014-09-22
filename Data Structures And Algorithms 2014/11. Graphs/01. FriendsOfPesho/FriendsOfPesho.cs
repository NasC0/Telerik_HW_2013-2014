using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendsOfPesho
{
    public class FriendsOfPesho
    {
        private static Dictionary<int, Node<int>> graph = new Dictionary<int, Node<int>>();
        private static readonly char[] splitParameters = new char[]
        {
            ' '
        };

        public static int[] ParseInput(string initialInput)
        {
            var inputSplit = initialInput.Split(splitParameters, StringSplitOptions.RemoveEmptyEntries);
            int connectionsCount = int.Parse(inputSplit[1]);
            int hospitalsCount = int.Parse(inputSplit[2]);
            int housesCount = int.Parse(inputSplit[0]) - hospitalsCount;

            return new int[] { housesCount, connectionsCount, hospitalsCount };
        }

        public static void AddHospitals(string hospitalsString)
        {
            var hospitalsSplit = hospitalsString.Split(splitParameters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var hospital in hospitalsSplit)
            {
                int hospitalNumber = int.Parse(hospital);
                var hospitalNode = new Node<int>(hospitalNumber, NodeType.Hospital);
                graph.Add(hospitalNumber, hospitalNode);
            }
        }

        public static void MakeConnections(string[] connections)
        {
            foreach (var connection in connections)
            {
                var splitConnection = connection.Split(splitParameters, StringSplitOptions.RemoveEmptyEntries);
                int sourceNumber = int.Parse(splitConnection[0]);
                int destinationNumber = int.Parse(splitConnection[1]);
                int distance = int.Parse(splitConnection[2]);

                Node<int> source;
                if (!graph.ContainsKey(sourceNumber))
                {
                    graph.Add(sourceNumber, new Node<int>(sourceNumber, NodeType.House));
                }

                source = graph[sourceNumber];

                Node<int> destination;
                if (!graph.ContainsKey(destinationNumber))
                {
                    graph.Add(destinationNumber, new Node<int>(destinationNumber, NodeType.House));
                }

                destination = graph[destinationNumber];

                source.AddConnection(destination, distance);
                destination.AddConnection(source, distance);
            }
        }

        public static double GetSmallestPath()
        {
            List<double> paths = new List<double>();
            var hospitals = graph.Where(n => n.Value.Type == NodeType.Hospital);
            var houses = graph.Where(n => n.Value.Type == NodeType.House);

            foreach (var hospital in hospitals)
            {
                double path = 0;
                PathBetweenNodes(hospital.Value);
                foreach (var house in houses)
                {
                    path += house.Value.DijkstraDistance;
                }

                paths.Add(path);
            }

            return paths.Min();
        }

        private static void PathBetweenNodes(Node<int> source)
        {
            var queue = new PriorityQueue<Node<int>>();

            foreach (var node in graph)
            {
                node.Value.DijkstraDistance = double.PositiveInfinity;
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbor in graph[currentNode.Value].Connections)
                {
                    var potDistance = currentNode.DijkstraDistance + neighbor.Distance;
                    if (potDistance < neighbor.Destination.DijkstraDistance)
                    {
                        neighbor.Destination.DijkstraDistance = potDistance;
                        queue.Enqueue(neighbor.Destination);
                    }
                }
            }
        }

        public static void Main()
        {
            string initialInput = Console.ReadLine();
            string hospitals = Console.ReadLine();

            var parsedInput = ParseInput(initialInput);
            int connectionsNumber = parsedInput[1];

            string[] connections = new string[connectionsNumber];
            for (int i = 0; i < connectionsNumber; i++)
			{
                connections[i] = Console.ReadLine();
			}

            AddHospitals(hospitals);
            MakeConnections(connections);
            double smallestPath = GetSmallestPath();
            Console.WriteLine(smallestPath);
        }
    }
}
