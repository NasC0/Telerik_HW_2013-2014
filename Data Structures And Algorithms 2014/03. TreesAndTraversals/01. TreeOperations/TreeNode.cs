using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TreeOperations
{
    public class TreeNode<T> : IEnumerable<TreeNode<T>>
    {
        private T value;
        private List<TreeNode<T>> children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            this.Value = value;
            this.HasParent = false;
            this.HasChildren = false;
        }

        public TreeNode(T value, List<TreeNode<T>> children)
            : this(value)
        {
            this.children = children;
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
                    throw new ArgumentNullException("Tree node value cannot be null.");
                }

                this.value = value;
            }
        }

        public bool HasParent { get; private set; }

        public bool HasChildren { get; private set; }

        public TreeNode<T> this[int index]
        {
            get
            {
                return this.children[index];
            }
        }

        public void AddNode(TreeNode<T> child)
        {
            child.HasParent = true;
            this.children.Add(child);
            this.HasChildren = true;
        }

        public void AddValue(T value)
        {
            TreeNode<T> currentNode = new TreeNode<T>(value);
            currentNode.HasParent = true;
            this.children.Add(currentNode);
        }

        public TreeNode<T> FindChild(T value)
        {
            var childNode = this.children.Where(x => x.Value.Equals(value)).FirstOrDefault();
            return childNode;
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            foreach (var node in this.children)
            {
                yield return node;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
