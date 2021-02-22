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