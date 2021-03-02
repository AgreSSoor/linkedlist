using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>, IComparer<T>
    {
        private Node<T> _first;
        private Node<T> _last;

        /// <summary>
        /// Method to Add elements in List
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (_first == null)
            {
                _first = node;
            }
            else
            {
                _last.Next = node;
            }

            _last = node;
            Count++;
        }

        /// <summary>
        /// Sorted adding of elements
        /// </summary>
        /// <param name="data"></param>
        public void SortedAdd(T data)
                 {
                     var node = new Node<T>(data);
                     Node<T> current = null;
                     if (_first == null || Comparer.Default.Compare(_first.Data, node.Data) > 0 )
                     {
                         node.Next = _first;
                         _first = node;
                     }
                     else
                     {
                         current = _first;
                         while (current.Next != null && Comparer.Default.Compare(current.Next.Data, node.Data) < 0)
                         {
                             current = current.Next;
                         }
         
                         node.Next = current.Next;
                         current.Next = node;
                     }
                 }
        
        /// <summary>
        /// Method to Remove elements in List
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            var current = _first;
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
                            _last = previous;
                        }
                    }
                    else
                    {
                        //If removing elem is first
                        _first = _first.Next;

                        //If after removing list is cleared, clear tail of list
                        if (_first == null)
                        {
                            _last = null;
                        }
                    }

                    Count--;
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
        public int Count { get; private set; }

        /// <summary>
        /// Checker if List is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        /// <summary>
        /// Method to clear List
        /// </summary>
        public void Clear()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        /// <summary>
        /// Method to check if List containts an last
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            var current = _first;
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
        /// Method to search elements
        /// </summary>
        /// <param name="data"></param>
        public Node<T> Find(T data)
        {
            var current = _first;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }

                current = current.Next;
            }

            return default;
        }
        
        public void AddFirst(T data)
        {
            var node = new Node<T>(data);
            node.Next = _first;
            _first = node;
            if (Count == 0)
            {
                _last = _first;
            }

            Count++;
        }

        /// <summary>
        /// Method to reverse elements of list
        /// </summary>
        /// <param name="data"></param>
        public void Reverse()
        {
            Node<T> current = _first;
            Node<T> previous = null;
            Node<T> next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _first = previous;
        }

        /// <summary>
        /// Method to print elements of List
        /// </summary>
        public void Print()
        {
            Node<T> current = _first;
            while (current != null)
            {
                Console.Write($"{current.Data} ");
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
            var current = _first;
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
            var current = _first;
            while (current != null)
            {
                duplicate.AddFirst(current.Data);
                current = current.Next;
            }

            return duplicate;
        }

        /// <summary>
        /// Checks if Lists are equal
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AreEqual(LinkedList<T> list)
        {
            if (Count != list.Count)
            {
                return false;
            }

            var current = _first;
            var comparable = list._first;

            while (current != comparable)
            {
                if (current != comparable)
                {
                    return false;
                }

                comparable = comparable.Next;
                current = current.Next;
            }

            return true;
        }

        /// <summary>
        /// Sorts list
        /// </summary>
        public void SortLinkedList()
        {
            Node<T> temp = _first;
            Node<T> firstval = null;
            T val = default(T);
            while (temp != null)
            {
                firstval = temp.Next;
                while (firstval != null)
                {
                    if (Comparer.Default.Compare(temp.Data, firstval.Data) > 0)
                    {
                        val = firstval.Data;
                        firstval.Data = temp.Data;
                        temp.Data = val;
                    }

                    firstval = firstval.Next;
                }

                temp = temp.Next;
            }
        }
        
        public int Compare(T x, T y)
        {
            return (Comparer.Default.Compare(x, y));
        }

        /// <summary>
        /// Returns new list with elements from an array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static LinkedList<T> FromArray(params T[] data)
        {
            LinkedList<T> newList = new LinkedList<T>();
            foreach (var el in data)
            {
                newList.Add(el);
            }
            return newList;
        }

        /// <summary>
        /// Adds elements from array
        /// </summary>
        /// <param name="data"></param>
        public void InsertArray(params T[] data)
        {
            foreach (var el in data)
            {
                Add(el);
            }
        }
        
        /// <summary>
        /// Merges 2 lists without sort
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LinkedList<T> Merge(LinkedList<T> list, LinkedList<T> list2)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list2 == null) throw new ArgumentNullException(nameof(list2));
            
            LinkedList<T> newList = list;
            newList.InsertArray(list2.ToArray());
            newList.SortLinkedList();
            return newList;
        }

        /// <summary>
        /// Appends sorted linked list L2 of integer items at the end of list L1 of the same type (class);
        /// So the result is in L1;
        ///	Rearranges the content of L1 to make it sorted again.
        /// </summary>
        /// <param name="list"></param>
        public void SortMerge(LinkedList<T> list)
        {
            InsertArray(list.ToArray());
            SortLinkedList();
        }
        
        /// <summary>
        /// Removes duplicates from list
        /// </summary>
        /// <returns></returns>
        public LinkedList<T> RemoveDuplicates()
        {
            LinkedList<T> newList = new LinkedList<T>();
            Node<T> current = _first;
            while (current != null)
            {
                if (!newList.Contains(current.Data))
                {
                    newList.SortedAdd(current.Data);
                }
                current = current.Next;
            }
            
            return newList;
        }
        
        /// <summary>
        /// Appends sorted linked list L2 of integer items at the end of list L1 of the same type (class); So the result is in L1;
        ///	Remove the node with the third-largest data item from L1. Return the removed data item.
        /// </summary>
        /// <returns></returns>
        public T AppendSelect(LinkedList<T> list)
        {
            InsertArray(list.ToArray());
            return RemoveDuplicates().OrderByDescending(x => x).ToArray()[2];
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}