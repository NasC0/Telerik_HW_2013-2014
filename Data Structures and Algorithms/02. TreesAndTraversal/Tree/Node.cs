using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T>
    {
        private T value;
        private List<Node<T>> children;

        public Node(T value)
        {
            this.Value = value;
            this.children = new List<Node<T>>();
        }

        public Node(T value, List<Node<T>> children)
            :this(value)
        {
            this.children.AddRange(children);
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Node value cannot be null.");
                }

                this.value = value;
            }
        }

        public bool HasParent { get; private set; }

        public List<Node<T>> Children
        {
            get
            {
                return new List<Node<T>>(this.children);
            }
        }

        public void AddChildNode(Node<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Child cannot be null.");
            }

            child.HasParent = true;
            this.children.Add(child);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
