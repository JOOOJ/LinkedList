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
            SingleLinkedList<int> temp = new SingleLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                temp.Add(i);
                Console.WriteLine(temp[i]);
            }
           
            
        }
    }

    
}
