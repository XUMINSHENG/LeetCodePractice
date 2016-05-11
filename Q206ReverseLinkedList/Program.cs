using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q206ReverseLinkedList
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            ListNode head = new ListNode(0);
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            head.next = n1;
            n1.next = n2;

            Program p = new Program();
            ListNode newHead = p.ReverseListRecursion(head);
            Program.print(newHead);
            Console.ReadKey();
        }

        //168 ms
        static ListNode newHead;
        public ListNode ReverseListRecursion(ListNode head)
        {
            if (head == null) return null;
            else
            {
                Reverse(head);
                return newHead;
            }
        }

        private ListNode Reverse(ListNode node)
        {
            // ptr point to the last element after reverse
            ListNode ptr;

            //base case
            if (node.next == null)
            {
                newHead = node;
            }
            else
            {
                ptr = Reverse(node.next);
                ptr.next = node;
                node.next = null;
            }

            return node;
        }


        // 148ms
        public ListNode ReverseListWithStack(ListNode head)
        {

            ListNode newHead = head, ptr = head;
            Stack<ListNode> s = new Stack<ListNode>();
            while (ptr != null)
            {
                s.Push(ptr);
                ptr = ptr.next;
            }

            int cnt = s.Count;
            if (cnt > 0)
            {
                newHead = s.Pop();
                ptr = newHead;

                for (int i = 1; i < cnt; i++)
                {
                    ptr.next = s.Pop();
                    ptr = ptr.next;
                }
                ptr.next = null;

            }
            return newHead;
        }




        public static void print(ListNode head)
        {
            ListNode ptr = head;

            while (ptr != null)
            {
                Console.Write(ptr.val);
                ptr = ptr.next;
            }
        }
    }
}
