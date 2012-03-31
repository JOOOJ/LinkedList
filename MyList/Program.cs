using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleLinkedList<int> temp = new SingleLinkedList<int>();
            //for (int i = 0; i < 5; i++)
            //{
            //    temp.Add(i);
            //    Console.WriteLine(temp[i]);
            //}

            SortedTree<int> stree = new SortedTree<int>();
            stree.Add(20);
            stree.Add(8);
            stree.Add(12);
            stree.Add(9);
            stree.Add(14);
            stree.FindSpecialNode(10);
        }
    }

    
}
