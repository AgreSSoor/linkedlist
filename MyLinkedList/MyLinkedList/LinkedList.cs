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