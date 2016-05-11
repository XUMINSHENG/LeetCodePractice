using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q92ReverseLinkedListII
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
            ListNode head = new ListNode(1);
            ListNode n1 = new ListNode(1);
            //ListNode n2 = new ListNode(3);
            head.next = n1;
            //n1.next = n2;

            Program p = new Program();
            //Program.print(head);
            ListNode nh = p.InsertionSortList(head);
            Program.print(nh);
            Console.ReadKey();

            Stack<int> s;
        }

        static ListNode newHead, newTail, leftNode, bfCut;
        // static int cnt;
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            //if (head == null || head.next == null) return head;
            if (head == null || head.next == null || m == n) return head;
            else
            {
                ListNode node = head, bfCut = head ;
                for (int i = 1; i < m; i++)
                {
                    bfCut = node;
                    node = node.next;
                }
                newTail = node;


                Reverse(node, n - m + 1);

                if (newTail != null)
                {
                    newTail.next = leftNode;
                }


                

                if (m == 1)
                    return newHead;
                else
                {
                    bfCut.next = newHead;
                    return head;
                }
                    
            }
        }


        private ListNode Reverse(ListNode node, int cnt)
        {
            // ptr point to the last element after reverse
            ListNode ptr;

            //base case
            if (cnt == 1)
            {
                newHead = node;
                leftNode = (node == null) ? null : node.next;
            }
            else
            {
                ptr = Reverse(node.next, cnt - 1);
                ptr.next = node;
                node.next = null;
            }

            return node;
        }

        public ListNode InsertionSortList(ListNode head) {
            if(head==null||head.next==null)return head;
        
            ListNode fakeHead = new ListNode(-1);
            fakeHead.next = head;
        
            ListNode ptrSort,unsorted = head.next;

            // set the tail of sorted list
            head.next = null;

            while(unsorted!=null){
                ListNode ptr = unsorted;
                unsorted = unsorted.next;
            
                // find node to insert
                ptrSort = fakeHead;
                while(ptrSort.next!=null&&ptrSort.next.val<ptr.val){
                    ptrSort = ptrSort.next;
                }
            
                //insert ptr into sorted list
                ptr.next = ptrSort.next;
                ptrSort.next = ptr;
            
            
            }
        
        
        
            return fakeHead.next;
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
