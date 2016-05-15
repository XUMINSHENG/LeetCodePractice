using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q34_SearchForRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();


            p.SearchRange(
                new int[] 
                    {1,2,3,3,3,3,4,5,9},
                    3
                );
            //Console.ReadKey();


        }

        int[] res;
        public int[] SearchRange(int[] nums, int target)
        {
            res = new int[] { -1, -1 };
            int start = 0;
            int end = nums.Length - 1;
            int mid = (start + end) / 2;
            // locate first
            while (start<=end)
            {
                
                if (target < nums[mid])
                {
                    end = mid - 1;
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    res[0] = mid;
                    res[1] = mid;
                    break;
                }
                mid = (start + end) / 2;
            }

            if (start < end)
            {
                findStart(nums, target,start, mid);

                findEnd(nums, target, mid, end);
            }

            return res;
        }

        private void findStart(int[] nums, int target, int start, int end)
        {
            
            int midIdx;
            //find range start point from [start,mid-1]
            midIdx = (start + end) / 2;
            while (true) 
            {
                if (target > nums[midIdx])
                {
                    start = midIdx + 1;
                }
                else
                {
                    end = midIdx;
                    res[0] = midIdx;
                }
                if (end - start < 2)
                {
                    if (nums[end] == target) res[0] = end;
                    if (nums[start] == target) res[0] = start;
                    break;
                }
                midIdx = (start + end) / 2;
                
            } 
        }

        private void findEnd(int[] nums, int target, int start, int end)
        {
            int midIdx;
            //find range end point from [mid+1,end]
            midIdx = (start + end) / 2;
            while (true)
            {
                if (target < nums[midIdx])
                {
                    end = midIdx - 1;
                }
                else
                {
                    start = midIdx;
                    res[1] = midIdx;
                }

                if (end - start < 2)
                {
                    if (nums[start] == target) res[1] = start;
                    if (nums[end] == target) res[1] = end;
                    break;
                }

                midIdx = (start + end) / 2;
                
            } 
        }

    }
}
