using System;
using System.Collections.Generic;

namespace TreeOperations
{
    public class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Tree root cannot be null.");
                }

                this.root = value;
            }
        }

        public TreeNode<T> FindChild(T value)
        {
            Queue<TreeNode<T>> bfsQueue = new Queue<TreeNode<T>>();
            bfsQueue.Enqueue(this.Root);
            TreeNode<T> resultNode = null;

            while (bfsQueue.Count > 0)
            {
                var currentNode = bfsQueue.Dequeue();
                if (currentNode.Value.Equals(value))
                {
                    resultNode = currentNode;
                    break;
                }

                foreach (var childNode in currentNode)
                {
                    bfsQueue.Enqueue(childNode);
                }
            }

            return resultNode;
        }
    }
}
