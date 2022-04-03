using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeLinkedList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();

            list1.CreateList();
            list2.CreateList();

            list1.BubbleSortExData();
            list2.BubbleSortExData();

            Console.WriteLine("List 1 Data is:");
            list1.DisplayList();

            Console.WriteLine("List 2 Data is:");
            list2.DisplayList();

            LinkedList list3;

        }
    }
}
