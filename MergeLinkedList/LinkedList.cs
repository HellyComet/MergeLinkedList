using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeLinkedList
{
    public class LinkedList
    {
        private Node start;

        public LinkedList()
        {
            start = null;
        }

        public void DisplayList()
        {
            Node p = start;

            if (start == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            while (p != null)
            {
                Console.WriteLine(p.info + " ");
                p = p.link;
            }
            Console.WriteLine();
        }

        public bool SearchList(int x)
        {
            int position = 1;

            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                    break;
                position++;
                p = p.link;
            }

            if (p == null)
            {
                Console.WriteLine(x + "not found in list");
                return false;
            }
            else
            {
                Console.WriteLine(x + "is at position" + position);
                return true;
            }
        }

        public void CountNodes()
        {
            Node p = start;
            int count = 1;

            while (p != null)
            {
                count++;
                p = p.link;
            }

            Console.WriteLine("Count of list" + count);
        }

        public bool Search(int x)
        {
            int position = 1;
            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                    break;
                position++;
                p = p.link;
            }
            if (p == null)
            {
                Console.WriteLine(x + " not found in list");
                return false;
            }
            else
            {
                Console.WriteLine(x + " is at position " + position);
                return true;
            }
        }

        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.link = start;
            start = temp;
        }

        public void InsertAtEnd(int data)
        {
            Node p;
            Node temp = new Node(data);

            if (start == null)
            {
                start = temp;
                return;
            }

            p = start;
            while (p.link != null)
                p = p.link;

            p.link = temp;
        }

        public void CreateList()
        {
            int i, n, data;

            Console.Write("Enter the number of nodes : ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;
            for (i = 1; i <= n; i++)
            {
                Console.Write("Enter the element to be inserted : ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }

        public void InsertAfter(int data, int x)
        {
            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                    break;
                p = p.link;
            }

            if (p == null)
                Console.WriteLine(x + " not present in the list");
            else
            {
                Node temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void InsertBefore(int data, int x)
        {
            Node temp;

            /*If list is empty*/
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            /*x is in first node,new node is to be inserted before first node*/
            if (x == start.info)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }

            /*Find reference to predecessor of node containing x*/
            Node p = start;
            while (p.link != null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }

            if (p.link == null)
                Console.WriteLine(x + " not present in the list");
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void InsertAtPosition(int data, int k)
        {
            Node temp;
            int i;

            if (k == 1)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }

            Node p = start;
            for (i = 1; i < k - 1 && p != null; i++) /*find a reference to k-1 node*/
                p = p.link;

            if (p == null)
                Console.WriteLine("You can insert only upto " + i + "th position");
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void DeleteFirstNode()
        {
            if (start == null)
                return;
            start = start.link;
        }

        public void DeleteLastNode()
        {
            if (start == null)
                return;

            if (start.link == null)
            {
                start = null;
                return;
            }

            Node p = start;
            while (p.link.link != null)
                p = p.link;
            p.link = null;
        }

        public void DeleteNode(int x)
        {
            if (start == null)
            {
                Console.WriteLine("List is empty\n");
                return;
            }
            /*Deletion of first node*/
            if (start.info == x)
            {
                start = start.link;
                return;
            }
            /*Deletion in between or at the end*/
            Node p = start;
            while (p.link != null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }

            if (p.link == null)
                Console.WriteLine("Element " + x + " not in list");
            else
                p.link = p.link.link;
        }


        public void BubbleSortExData()
        {
            Node end, p, q;

            for (end = null; end != start.link; end = p)
            {
                for (p = start; p.link != end; p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        int temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    }
                }
            }
        }

        public LinkedList Merge1(LinkedList list)
        {
            LinkedList mergeList = new LinkedList();
            mergeList.start = Merge1(start, list.start);
            return mergeList;
        }
        
        private Node Merge1(Node p1, Node p2)
        {
            Node startM;

            if(p1.info <= p2.info)
            {
                startM = new Node(p1.info);
                p1 = p1.link;
            }

            else
            {
                startM = p2.link;
                p2 = p2.link;
            }

            Node pM = startM;

            while( p1!= null  && p2 !=null)
            {
                if(p1.info <= p2.info)
                {
                    pM.link = new Node(p1.info);
                    p1 = p1.link;
                }
                else
                {
                    pM.link = new Node(p2.info);
                    p2 = p2.link;
                }
                pM = pM.link;
            }

            while( p1!= null)
            {
                pM.link = new Node(p1.info);
                p1 = p1.link;
                pM = pM.link;
            }

            while(p2!= null)
            {
                pM.link = new Node(p2.info);
                p2 = p2.link;
                pM = pM.link;
            }
            return startM;
        }
    }
}
