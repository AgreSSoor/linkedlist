using System;
using System.Collections;
using System.Collections.Generic;
namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> first; // first element of list
        private Node<T> last; // last element of list
        private int count; // quantity of elements

        /// <summary>
        /// Method to Add elements in List
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (first == null) // If there is no first element of list, then adds element as first
            {
                first = node;
            }
            else // Adds element to the tail of list
            {
                last.Next = node;
            }
            last = node;
            count++;
        }
        
        /// <summary>
        /// Method to Remove elements in List
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            var current = first;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    
                    //If Node is located not in the beginning
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        
                        //If current.Next is null, then change last variable
                        if (current.Next == null)
                        {
                            last = previous;
                        }
                    }
                    else
                    {
                        //If removing elem is first
                        first = first.Next;
                        
                        //If after removing list is cleared, clear tail of list
                        if (first == null)
                        {
                            last = null;
                        }
                    }

                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }
        
        /// <summary>
        /// Quantity of elements in List
        /// </summary>
        public int Count
        {
            get { return count; }
        }
        
        /// <summary>
        /// Checker if List is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        
        /// <summary>
        /// Method to clear List
        /// </summary>
        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }
        
        /// <summary>
        /// Method to check if List containts an last
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            var current = first;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;    
                }

                current = current.Next;
            }

            return false;
        }
        
        /// <summary>
        /// Method to Add last as first
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(T data)
        {
            var node = new Node<T>(data);
            node.Next = first;
            first = node;
            if (count == 0)
            {
                last = first;
            }

            count++;
        }
        
        /// <summary>
        /// Method to reverse elements of list
        /// </summary>
        /// <param name="data"></param>
        public void Reverse()
        {
            Node<T> current = first;
            Node<T> previous = null;
            Node<T> next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            first = previous;
        }
        
        /// <summary>
        /// Method to print elements of List
        /// </summary>
        public void Print()
        {
            Node<T> current = first;
            while (current != null) {
                Console.WriteLine(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Method to duplicate a list
        /// </summary>
        /// <returns></returns>
        public LinkedList<T> Duplicate()
        {
            LinkedList<T> duplicate = new LinkedList<T>();
            var current = first;
            while (current != null)
            {
                duplicate.Add(current.Data);
                current = current.Next;
            }

            return duplicate;
        }
        
        /// <summary>
        /// Copies reversed List
        /// </summary>
        /// <returns></returns>
        public LinkedList<T> CopyReverse()
        {
            LinkedList<T> duplicate = new LinkedList<T>();
            var current = first;
            while (current != null)
            {
                duplicate.AddFirst(current.Data);
                current = current.Next;
            }

            return duplicate;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}