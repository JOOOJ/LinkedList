using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyList
{
    internal class LinkedNode<T>
    {
        public virtual T Value { get; set; }
        public LinkedNode<T> Next { get; set; }
    }
}
