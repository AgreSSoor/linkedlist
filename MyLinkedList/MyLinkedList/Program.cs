using System;
using System.Collections.Generic;

namespace MyLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> linkedList = LinkedList<int>.FromArray(new int[] {20,19,18,17});
            LinkedList<int> reversedLinkedList = LinkedList<int>.FromArray(new int[] {1,2,3,4,5});
            LinkedList<int> number = new LinkedList<int>();
            linkedList.AppendOrdered(reversedLinkedList);
            linkedList.Print();
            
            /*linkedList.Add("Ann");
            linkedList.Add("Oleksandr");
            linkedList.Add("Edik");
            linkedList.Add("Polina");
            linkedList.Print();
            reversedLinkedList = linkedList.CopyReverse();
            reversedLinkedList.Print();
            Console.WriteLine(linkedList.AreEqual(reversedLinkedList));
            */

            /*linkedList.Remove("Edik");
            bool isEmpty = linkedList.IsEmpty;
            int elemsCount = linkedList.Count;
            bool cont = linkedList.Contains("Edik");
            Console.WriteLine($"IsEmpty: {isEmpty} Quantity: {elemsCount} Contains(Edik): {cont}");
            linkedList.Clear();
            if (linkedList.IsEmpty)
                Console.WriteLine("List is empty");
                */
        }
    }
}