using System;
using System.Collections.Generic;

namespace MyLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> linkedList = LinkedList<int>.FromArray(20,19,18,17);
            LinkedList<int> reversedLinkedList = LinkedList<int>.FromArray(1,2,3,4,5);
            LinkedList<int> number = new LinkedList<int>();
            Console.WriteLine(linkedList.Count);
            //Console.Write(linkedList.Find(20));
        }
    }
}