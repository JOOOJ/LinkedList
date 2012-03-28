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
            LinkedList<int> temp = new LinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                temp.Add(i);
                //Console.WriteLine(temp[i]);
            }
            int[] aa=new int[6];
            temp.CopyTo(aa, 2);
            foreach (int item in aa)
            {
                Console.WriteLine(item);
            }

            
            
        }
    }

    internal class LinkedList<T>:IList<T>, ICollection<T>,IEnumerable<T>, IList, ICollection, IEnumerable
    {
        private Node<T> root = new Node<T>();

        private Node<T> GetNode(int index)
        {
            Node<T> node = root;
            while (index > 0 && node.Next != null)
            {
                node = node.Next;
                index--;
            }
            if (index == 0)
            {
                return node;
            }
            throw new ArgumentOutOfRangeException();
        }

        private static bool IsCompatibleObject(object obj)
        {
            return((obj is T)||(obj==null)||(default(T)==null));
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire LinkedList(Of T).
        /// </summary>
        /// <param name="item">The object to locate in the LinkedList(Of T). The value can be Nothing for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire LinkedList(Of T), if found; otherwise, –1 </returns>
        public int IndexOf(T item)
        {
            Node<T> node = root.Next;
            int index = 0;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return index;
                }
                index++;
                node = node.Next;
            }
            return -1;
        }

        /// <summary>
        /// Inserts an element into the LinkedList(Of T) at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted</param>
        /// <param name="item">The object to insert. The value can be Nothing for reference types</param>
        public void Insert(int index, T item)
        {
            Node<T> node = GetNode(index);
            Node<T> newNode = new Node<T>() { Value = item, Next = node.Next };
            node.Next = newNode;
        }

        /// <summary>
        /// Removes the element at the specified index of the LinkedList(Of T).
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public void RemoveAt(int index)
        {
            Node<T> node = GetNode(index);
            node.Next = node.Next.Next;
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                Node<T> node = GetNode(index);
                return node.Next.Value;
            }
            set
            {
                Node<T> node = GetNode(index);
                node.Next.Value = value;
            }
        }

        /// <summary>
        /// Adds an object to the end of the LinkedList(Of T).
        /// </summary>
        /// <param name="item">The object to be added to the end of the LinkedList(Of T). The value can be Nothing for reference types</param>
        public void Add(T item)
        {
            Node<T> node = root;
            while (node.Next != null)
            {
                node = node.Next;
            }
            Node<T> newNode = new Node<T>() { Value = item };
            node.Next = newNode;
        }

        /// <summary>
        /// Removes all elements from the LinkedList(Of T).
        /// </summary>
        public void Clear()
        {
            root.Next = null;
        }

        /// <summary>
        /// Determines whether an element is in the LinkedList(Of T).
        /// </summary>
        /// <param name="item">The object to locate in the LinkedList(Of T). The value can be Nothing for reference types</param>
        /// <returns>true if item is found in the LinkedList(Of T); otherwise, false</returns>
        public bool Contains(T item)
        {
            Node<T> node = root.Next;
            while (node != null) 
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies the entire LinkedList(Of T) to a compatible one-dimensional array, starting at the specified index of the target array
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from LinkedList(Of T). The Array must have zero-based indexing</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node<T> node = root.Next;
            int i=0;
            while (node != null)
            {
                array[arrayIndex + i] = node.Value;
                node = node.Next;
                i++;
            }
        }

        /// <summary>
        /// Gets the number of elements actually contained in the LinkedList(Of T).
        /// </summary>
        public int Count
        {
            get 
            {
                Node<T> node = root.Next;
                int index = 0;
                while (node != null)
                {
                    node = node.Next;
                    index++;
                }
                return index;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the linkedList(Of T).
        /// </summary>
        /// <param name="item">The object to remove from the LinkedList(Of T). The value can be Nothing for reference types</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the LinkedList(Of T).</returns>
        public bool Remove(T item)
        {
            Node<T> node = root;
            while (node.Next != null)
            {
                if (node.Next.Value.Equals(item))
                {
                    node.Next = node.Next.Next;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the LinkedList(Of T).
        /// </summary>
        /// <returns>A LinkedList(Of T).Enumerator for the LinkedList(Of T).</returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = root.Next;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            return (IsCompatibleObject(value) && Contains((T)value));
        }

        public int IndexOf(object value)
        {
            if (IsCompatibleObject(value))
            {
                return IndexOf((T)value);
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if (IsCompatibleObject(value))
            {
                Insert(index, (T)value);
            }
            else
            {
                throw new ArgumentException("Wrong argument type");
            }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public void Remove(object value)
        {
            if (IsCompatibleObject(value))
            {
                Remove((T)value);
            }
        }

        object IList.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Array array, int index)
        {
            CopyTo(array, index);
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }

    internal class Node<T>
    {
        public virtual T Value { get; set; }
        public Node<T> Next { get; set; }
    }

}
