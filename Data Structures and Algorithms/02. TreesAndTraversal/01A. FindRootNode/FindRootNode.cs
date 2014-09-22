/* 01. You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1).
 * Write a program to read the tree and find:
 * A) the root node
 * B) all leaf nodes
 * C) all middle nodes
 * D) the longest path in the tree
 * E) all paths in the tree with given sum S of their nodes
 * F) all subtrees with given sum S of their nodes */

using System;
using System.Collections.Generic;
using System.Linq;
using Tree;

class FindRootNode
{

    #region Helper Functions (Tree creation)
    static int[] ParseParentChildPair(string parentChildPair)
    {
        int[] result = new int[2];
        var parentChildPairSplit = parentChildPair.Split(' ');

        result[0] = int.Parse(parentChildPairSplit[0]);
        result[1] = int.Parse(parentChildPairSplit[1]);

        return result;
    }

    static Tree<int> ParseTree()
    {
        int treeSize = int.Parse(Console.ReadLine());

        var nodes = new Node<int>[treeSize];

        for (int i = 0; i < treeSize; i++)
        {
            nodes[i] = new Node<int>(i);
        }

        for (int i = 0; i < treeSize - 1; i++)
        {
            string parentAndChild = Console.ReadLine();
            var parentChildPair = ParseParentChildPair(parentAndChild);

            nodes[parentChildPair[0]].AddChildNode(nodes[parentChildPair[1]]);
        }

        Node<int> root = null;

        foreach (var node in nodes)
        {
            if (!node.HasParent)
            {
                root = node;
            }
        }

        return new Tree<int>(root);
    }

    #endregion

    #region Task 01-B Find all leaf nodes
    static List<Node<int>> FindAllLeafNodes(Tree<int> tree)
    {
        List<Node<int>> result = new List<Node<int>>();

        Stack<Node<int>> dfsStack = new Stack<Node<int>>();
        dfsStack.Push(tree.Root);

        while (dfsStack.Count > 0)
        {
            var currentNode = dfsStack.Pop();
            if (currentNode.Children.Count < 1)
            {
                result.Add(currentNode);
            }
            else
            {
                foreach (var node in currentNode.Children)
                {
                    dfsStack.Push(node);
                }
            }
        }

        return result;
    }
    #endregion

    #region Task 01-C Find all middle nodes
    static List<Node<int>> FindAllMiddleNodes(Tree<int> tree)
    {
        var result = new List<Node<int>>();

        Stack<Node<int>> dfsStack = new Stack<Node<int>>();
        dfsStack.Push(tree.Root);

        while (dfsStack.Count > 0)
        {
            var currentNode = dfsStack.Pop();
            if (currentNode.HasParent && currentNode.Children.Count > 0)
            {
                result.Add(currentNode);
            }

            foreach (var child in currentNode.Children)
            {
                dfsStack.Push(child);
            }
        }

        return result;
    }
    #endregion

    #region Task 01-D Find the longest path in the tree
    static int FindLongestPath(Tree<int> tree)
    {
        int maxDepth = 0;

        Stack<Node<int>> dfsStack = new Stack<Node<int>>();
        dfsStack.Push(tree.Root);

        while (dfsStack.Count > 0)
        {
            var currentNode = dfsStack.Pop();

            if (currentNode.Children.Count > 0)
            {
                maxDepth++;
            }
            foreach (var child in currentNode.Children)
            {
                dfsStack.Push(child);
            }
        }

        return maxDepth;
    }
    #endregion

    static void Main()
    {
        var tree = ParseTree();

        #region Task 01A. Find the root node
        Console.WriteLine("The root element is: {0}", tree.Root.Value);
        #endregion

        #region Task 01B. Find all leaf nodes
        var leafNodes = FindAllLeafNodes(tree);

        Console.WriteLine("Leaf nodes: {0}", string.Join(" ", leafNodes));
        #endregion

        #region Task01C. Find all middle nodes
        var middleNodes = FindAllMiddleNodes(tree);

        Console.WriteLine("Middle nodes: {0}", string.Join(" ", middleNodes));
        #endregion

        Console.WriteLine(FindLongestPath(tree));
    }
}