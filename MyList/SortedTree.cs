using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyList
{
    public class SortedTree<T>
        where T:IComparable<T>
    {
        private TreeNode<T> root;

        /// <summary>
        /// Add a tree node
        /// </summary>
        /// <param name="data">the value you want to add into the tree</param>
        public void Add(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>() { Value = data };
            }
            else
            {
                root.AddNode(data);
            }

        }

        public bool Contains(T data)
        {
            TreeNode<T> node = root;
            while (root != null)
            {
                if (data.CompareTo(root.Value)>0)
                {
                    node = node.RNode;
                }
                else if (data.CompareTo(root.Value) < 0)
                {
                    node = node.LNode;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find a node whose value not bigger than specific value but bigger than others which less than the specific value.
        /// </summary>
        /// <param name="data">The object want to be compared</param>
        public void FindSpecialNode(T data)
        {
            TreeNode<T> node = root;
            T temp=default(T);
            while (node != null)
            {
                if (data.CompareTo(node.Value) < 0)
                {
                    node = node.LNode;
                }
                else if (data.CompareTo(node.Value) > 0)
                {
                    temp = node.Value;
                    node = node.RNode;
                }
                else
                {
                    Console.WriteLine(node.Value);
                }
            }
            if (node == null)
            {
                if (temp.CompareTo(default(T)) == 0)
                {
                    Console.WriteLine("Not found this node");
                }
                else
                {
                    Console.WriteLine(temp.ToString());
                }
            }
        }
    }
}
