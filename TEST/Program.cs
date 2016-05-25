using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

    }

    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //ListNode head = new ListNode(5);
            //ListNode n1 = new ListNode(3);
            //ListNode n2 = new ListNode(1);
            //ListNode n3 = new ListNode(2);
            //ListNode n4 = new ListNode(4);
            //head.next = n1;
            //n1.next = n2;
            //n2.next = n3;
            //n3.next = n4;

            //TreeNode root = new TreeNode(2);
            //TreeNode n1 = new TreeNode(7);
            //TreeNode n2 = new TreeNode(4);
            
            //TreeNode n3 = new TreeNode(4);
            //TreeNode n4 = new TreeNode(0);
            //TreeNode n5 = new TreeNode(2);
            //TreeNode n6 = new TreeNode(1);
            //TreeNode n7 = new TreeNode(6);
            //root.left = n1;
            //root.right = n2;
            //n1.right = n3;
            //n2.left = n4;

            //n3.right = n5;
            //n5.right = n6;
            
            //for (int i = 0; i < 1000; i++)
            //{
            //    n2 = new TreeNode(1);
            //    n1.left = n2;
            //    n1 = n2;

            //}
            
            Program p = new Program();


            //p.solution(new int[] { 8, 24, 3, 20, 1, 17 });

            //p.solution("ABBCCBAABBA");
            //p.solution("ABBCC");

            p.MySqrt(2147395599);

            Console.WriteLine();
            //Console.ReadKey();
            
        }

        

        public int solution1(int[] A)
        {
            int result = -1;
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int EvenCnt = 0;
            int OddCnt = 0;

            foreach(int i in A){
                // even
                if (i % 2 == 0) EvenCnt++;
                else OddCnt++;
            }

            double EvenSum = EvenCnt * (EvenCnt - 1) / 2;
            double OddSum = OddCnt * (OddCnt - 1) / 2;

            if (EvenSum + OddSum > 1000000000) result = -1;
            else result = (int)(EvenSum + OddSum);
            return result;
        }


        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            // Merge Sort - n * log n
            A = MergeSort(A);

            // find minimun
            int min = A[1] - A[0];
            for (int i = 2; i < A.Length;i++ )
            {
                int tmp = A[i]-A[i-1];
                if (tmp < min) min = tmp;
            }

            return min;
        }

        public int[] MergeSort(int[] input)
        {

            if (input.Length <= 1) return input;

            int mid = input.Length / 2;

            int[] left = new int[mid];
            for (int i = 0; i < mid; i++)
            {
                left[i] = input[i];
            }

            int[] right = new int[input.Length - mid];
            for (int i = mid; i < input.Length; i++)
            {
                right[i - mid] = input[i];
            }

            // recursion
            left = MergeSort(left);
            right = MergeSort(right);

            // merge
            int lCur = 0, rCur = 0, resultCur = 0;
            int[] result = input;
            while (resultCur < input.Length)
            {
                if (lCur == left.Length)
                {
                    result[resultCur++] = right[rCur++];
                }
                else if (rCur == right.Length)
                {
                    result[resultCur++] = left[lCur++];
                }
                else
                {
                    if (right[rCur] < left[lCur])
                    {
                        result[resultCur++] = right[rCur++];
                    }
                    else
                    {
                        result[resultCur++] = left[lCur++];
                    }
                }

            }

            return result;
        }

        public string solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            string res = S;

            bool changed = false;
            do
            {
                changed = false;
                // AB -> AA
                if (res.IndexOf("AB") != -1)
                {
                    res = res.Replace("AB", "A");
                    changed = true;
                }
                    
                // BA -> AA
                if (res.IndexOf("BA") != -1)
                {
                    res = res.Replace("BA", "A");
                    changed = true;
                }
                // CB -> CC
                if (res.IndexOf("CB") != -1)
                {
                    res = res.Replace("CB", "C");
                    changed = true;
                }
                // BC -> CC
                if (res.IndexOf("BC") != -1)
                {
                    res = res.Replace("BC", "C");
                    changed = true;
                }
                // AA -> A
                res = res.Replace("AA", "A");
                if (res.IndexOf("AA") != -1)
                {
                    res = res.Replace("AA", "A");
                    changed = true;
                }
                // CC -> C
                if (res.IndexOf("CC") != -1)
                {
                    res = res.Replace("CC", "C");
                    changed = true;
                }

            } while (changed);
            return res;

        }

        public int MySqrt(int x)
        {

            long start = 0, end = (int)Math.Pow(2, 16);
            long mid = (start + end) / 2;
            while (mid > start)
            {
                
                long tmp = mid * mid;
                if (x < tmp)
                {
                    end = mid;
                }
                else if (x > tmp)
                {
                    start = mid;
                }
                else
                {
                    break;
                }
                mid = (start + end) / 2;
            }

            return (int)mid;
        }


    }
}
