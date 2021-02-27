using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>, IComparer<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int count;

        /// <summary>
        /// Method to Add elements in List
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (first == null)
            {
                first = node;
            }
            else
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

        /// <summary>
        /// Checks if Lists are equal
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AreEqual(LinkedList<T> list)
        {
            if (count != list.count)
            {
                return false;
            }

            var current = first;
            var comparable = list.first;

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
            Node<T> temp = first;
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
        public static LinkedList<T> FromArray(T[] data)
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
        public void InsertArray(T[] data)
        {
            foreach (var el in data)
            {
                Add(el);
            }
        }
        
        /// <summary>
        /// Merges 2 lists and return sorted new list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public LinkedList<T> Merge(LinkedList<T> list)
        {
            LinkedList<T> newList = Duplicate();
            newList.InsertArray(list.ToArray());
            newList.SortLinkedList();
            return newList;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
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