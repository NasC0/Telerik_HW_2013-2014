using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeOperations
{
    public class TreeOperations
    {
        public static List<TreeNode<int>> GetAllNodesFromPairs(List<string> pairs)
        {
            List<TreeNode<int>> nodes = new List<TreeNode<int>>();

            foreach (var pair in pairs)
            {
                string[] splitPairs = pair.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int parentNodeValue;
                int.TryParse(splitPairs[0], out parentNodeValue);

                int childNodeValue;
                int.TryParse(splitPairs[1], out childNodeValue);

                TreeNode<int> childNode = nodes.Where(x => x.Value.Equals(childNodeValue)).FirstOrDefault();
                if (childNode == null)
                {
                    childNode = new TreeNode<int>(childNodeValue);
                    nodes.Add(childNode);
                }

                var parentNode = nodes.Where(x => x.Value.Equals(parentNodeValue)).FirstOrDefault();
                if (parentNode == null)
                {
                    parentNode = new TreeNode<int>(parentNodeValue);
                    nodes.Add(parentNode);
                }

                parentNode.AddNode(childNode);
            }

            return nodes;
        }

        public static Tree<int> BuildTree(List<TreeNode<int>> nodes)
        {
            TreeNode<int> treeRoot = nodes.Where(x => x.HasParent == false).FirstOrDefault();
            Tree<int> resultTree = new Tree<int>(treeRoot);

            return resultTree;
        }

        // Task 01.B. Find all leaf nodes
        public static List<TreeNode<int>> FindAllLeaves(Tree<int> tree)
        {
            Stack<TreeNode<int>> dfsStack = new Stack<TreeNode<int>>();
            dfsStack.Push(tree.Root);
            List<TreeNode<int>> nodeList = new List<TreeNode<int>>();

            while (dfsStack.Count > 0)
            {
                var currentNode = dfsStack.Pop();
                if (!currentNode.HasChildren)
                {
                    nodeList.Add(currentNode);
                }
                else
                {
                    foreach (var node in currentNode)
                    {
                        dfsStack.Push(node);
                    }
                }
            }

            return nodeList;
        }

        // 01.C. Find all middle nodes
        public static List<TreeNode<int>> FindAllMiddleNodes(Tree<int> tree)
        {
            Queue<TreeNode<int>> bfsQueue = new Queue<TreeNode<int>>();
            bfsQueue.Enqueue(tree.Root);
            List<TreeNode<int>> nodeList = new List<TreeNode<int>>();

            while (bfsQueue.Count > 0)
            {
                var currentNode = bfsQueue.Dequeue();
                if (currentNode.HasParent && currentNode.HasChildren)
                {
                    nodeList.Add(currentNode);
                }

                foreach (var node in currentNode)
                {
                    bfsQueue.Enqueue(node);
                }
            }

            return nodeList;
        }

        // 01.D. Find longest path
        public static int LongestPath(TreeNode<int> root)
        {
            if (!root.HasChildren)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root)
            {
                maxPath = Math.Max(maxPath, LongestPath(node));
            }

            return maxPath + 1;
        }

        public static void Main()
        {
            //Console.Write("Enter the number of pairs: ");
            //int numberOfEdges;
            //int.TryParse(Console.ReadLine(), out numberOfEdges);

            List<string> pairs = new List<string>()
            {
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
                "1 7"
            };

            //for (int i = 0; i < numberOfEdges - 1; i++)
            //{
            //    string currentPair = Console.ReadLine();
            //    pairs.Add(currentPair);
            //}

            var pairNodes = GetAllNodesFromPairs(pairs);
            var tree = BuildTree(pairNodes);

            // Task 01.A. Find the root node of the tree
            Console.WriteLine("The tree root is: {0}", tree.Root);

            Console.WriteLine("-------------------");

            // Task 01.B. Find all leaf nodes
            Console.WriteLine("Leaf nodes: ");
            var leafNodes = FindAllLeaves(tree);
            foreach (var leaf in leafNodes)
            {
                Console.WriteLine(leaf);
            }

            Console.WriteLine("-------------------");

            // Task 01.C. Find all middle nodes
            Console.WriteLine("Middle nodes: ");
            var middleNodes = FindAllMiddleNodes(tree);
            foreach (var node in middleNodes)
            {
                Console.WriteLine(node);
            }

            Console.WriteLine("-------------------");

            // Task 01.D. Find longest path
            int longestPath = LongestPath(tree.Root);
            Console.WriteLine("The longest path is: {0}", longestPath);
        }
    }
}
