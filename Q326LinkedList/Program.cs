using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q326LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            ListNode head = new ListNode(1);
            ListNode ptr = head; 
            for (int i = 2; i < 9; i++)
            {
                ptr.next = new ListNode(i);
                ptr = ptr.next;
            }

            p.Print(ptr = head);

            Console.WriteLine();

            p.Print(p.OddEvenList(head));
            Console.WriteLine();
            Console.ReadKey();
        }

        public ListNode OddEvenList(ListNode head) 
        {
            if (head == null) return head;
            ListNode oddHead, oddPtr, evenHead, evenPtr, ptr;

            oddHead = head;
            oddPtr = head;
            evenHead = new ListNode(-1);
            evenHead.next = head.next;
            evenPtr = evenHead;
            
            // start from 2
            ptr = head.next;

            bool isOdd = false;
            while (ptr != null)
            {
                if (isOdd)
                {
                    oddPtr.next = ptr;
                    oddPtr = ptr;
                    isOdd = false;
                }
                else
                {
                    evenPtr.next = ptr;
                    evenPtr = ptr;
                    isOdd = true;
                }

                ptr = ptr.next;
            }
            evenPtr.next = null;
            oddPtr.next = evenHead.next;
            return oddHead;
        }

        private void Print(ListNode node)
        {
            ListNode ptr = node;
            while (ptr != null)
            {
                Console.Write(ptr.val);
                ptr = ptr.next;
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }


}
