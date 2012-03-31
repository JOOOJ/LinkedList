using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyList
{
    internal class TreeNode<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> LNode { get; set; }
        public TreeNode<T> RNode { get; set; }

        public void AddNode(T data)
        {
            if (data.CompareTo(Value)<0)
            {
                if (LNode == null)
                {
                    LNode = new TreeNode<T>() { Value = data };
                }
                else
                {
                    LNode.AddNode(data);
                }
            }
            else if (data.CompareTo(Value) > 0)
            {
                if (RNode == null)
                {
                    RNode = new TreeNode<T>() { Value = data };
                }
                else
                {
                    RNode.AddNode(data);
                }
            }
        }
    }
}
