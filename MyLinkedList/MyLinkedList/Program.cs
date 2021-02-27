using System;
using System.Collections.Generic;

namespace MyLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            LinkedList<string> reversedLinkedList = new LinkedList<string>();
            LinkedList<int> number = new LinkedList<int>();
            number.Add(10);
            number.Add(20);
            number.Add(30);
            number.Add(15);
            number.Add(40);
            number.Add(7);
            number.SortLinkedList();
            number.Print();
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