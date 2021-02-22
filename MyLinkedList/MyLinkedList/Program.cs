using System;

namespace MyLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            LinkedList<string> reversedLinkedList = new LinkedList<string>();
            linkedList.Add("Ann");
            linkedList.Add("Oleksandr");
            linkedList.Add("Edik");
            linkedList.Add("Polina");
            linkedList.Print();
            reversedLinkedList = linkedList.CopyReverse();
            reversedLinkedList.Print();
            Console.WriteLine(linkedList.AreEqual(reversedLinkedList));
            
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