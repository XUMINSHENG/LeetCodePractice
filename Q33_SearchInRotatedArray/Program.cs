using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q33_SearchInRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //int i = p.Search(new int[] { 1,3,5 }, 5);
            int i = p.FindMin(new int[] { 3, 1, 3, 3});
        }


        public int Search(int[] nums, int target)
        {
            // rotated povit
            int idxMin = __FindMin(nums);

            int start = 0, end = nums.Length - 1, mid;
            
            while (true)
            {
                mid = (start + end) / 2;

                int rotatedStart = (start + idxMin) % nums.Length;
                int rotatedEnd = (end + idxMin) % nums.Length;
                int rotatedMid = (mid + idxMin) % nums.Length;

                if (mid == start)
                {
                    if (nums[rotatedStart] == target) return rotatedStart;
                    else if (nums[rotatedEnd] == target) return rotatedEnd; 
                    else return -1;
                }

                if (target == nums[rotatedMid]) return rotatedMid;
                else if (target < nums[rotatedMid])
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }

            }

        }


        private int __FindMin(int[] nums)
        {
            int start = 0, end = nums.Length - 1, mid;
            
            while(start<end){
                mid = (start + end) / 2;
                if (mid == start)
                {
                    if (nums[start] < nums[end]) return start;
                    else return end;
                }
                if (nums[mid] < nums[start])
                {
                    end = mid;
                }
                else if (nums[mid] > nums[end])
                {
                    start = mid;
                }
                else return start;

            }

            return start;
        }

        // Q154
        public int FindMin(int[] nums)
        {
            return __FindMin(nums,0,nums.Length - 1);
        }

        private int __FindMin(int[] nums, int start, int end)
        {
            int mid = (start + end) / 2;
            // base case
            // less than two elements in this round
            if (mid == start)
            {
                if (nums[start] < nums[end]) return nums[start];
                else return nums[end];
            }

            if (nums[mid] < nums[start])
            {
                // search in left half
                return __FindMin(nums, start, mid);
            }
            else if (nums[mid] > nums[end])
            {
                // search in right half
                return __FindMin(nums, mid, end);
            }
            else if (nums[mid] == nums[start] && nums[mid] == nums[end])
            {
                // 7777227 or 7227777
                return Math.Min(__FindMin(nums, start, mid), __FindMin(nums, mid, end));
            }
            else 
            {
                // left < mid < right, no rotate
                return nums[start];
            }
            
        }

    }
}
