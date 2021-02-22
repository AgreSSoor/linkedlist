using System.Collections;
using System.Collections.Generic;
namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> first; // first element of list
        private Node<T> last; // last element of list
        private int count; // quantity of elements

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