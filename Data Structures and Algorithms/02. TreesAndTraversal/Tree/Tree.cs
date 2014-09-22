using System;

namespace Tree
{
    public class Tree<T>
    {
        private Node<T> root;

        public Tree(Node<T> rootValue)
        {
            this.Root = rootValue;
        }

        public Tree(T value)
        {
            this.Root = new Node<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                this.Root.AddChildNode(child.Root);
            }
        }

        public Node<T> Root
        {
            get
            {
                return this.root;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Root node cannot be null.");
                }

                this.root = value;
            }
        }
    }
}
