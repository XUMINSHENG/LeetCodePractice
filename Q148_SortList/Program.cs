using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q148_SortList
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(5);
            ListNode n1 = new ListNode(3);
            ListNode n2 = new ListNode(1);
            ListNode n3 = new ListNode(2);
            ListNode n4 = new ListNode(4);
            head.next = n1;
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;

            Program p = new Program();
            head = p.SortList(head);

        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode result, left, right, ptr;

            // find the one before mid 
            left = head;
            ptr = findMid(head);
            right = ptr.next;

            // break the link
            ptr.next = null;

            // divide and conqure
            left = SortList(left);
            right = SortList(right);

            // merge 
            if(left.val<right.val){
                result = left;
                left = left.next;
            }else{
                result = right;
                right = right.next;
            }
            ptr = result;
            ptr.next = null;
            
            while(left!=null || right !=null){

                if (right == null || (left!=null && left.val < right.val))
                {
                    // pick from left
                    ptr.next = left;
                    left = left.next;
                }
                else
                {
                    // pick from right
                    ptr.next = right;
                    right = right.next;
                }

                ptr = ptr.next;
                ptr.next = null;

            }

            return result;
        }



        private ListNode findMid(ListNode head)
        {
            ListNode ptr1 = head, ptr2 = head;

            while (ptr2.next != null && ptr2.next.next != null)
            {
                ptr2 = ptr2.next.next;
                ptr1 = ptr1.next;
            }

            return ptr1;
        }
    }
}
