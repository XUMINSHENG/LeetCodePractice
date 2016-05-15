using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q334_IncreasingTriSubSeq
{
    class Program
    {
        static void Main(string[] args)
        {

            Program p = new Program();
            bool res = p.IncreasingTriplet(
                new int[] 
                    { 2, 5, 5, 3, 1, 4 }
                    //{5, 1, 5, 5, 2, 5, 4}
                );
            Console.WriteLine(res);
            Console.ReadKey();
        }

        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3) return false;
            int i, j, k;
            i = 0;
            
            // find min from the beginning
            while(nums[i] >= nums[i + 1]){
                i++;
                if (i >= nums.Length - 1) return false;
            }

            // fix max from the end
            k = nums.Length-1;
            while (nums[k] <= nums[k - 1])
            {
                k--;
                if (k <= 1) return false;
            }

            if (k - i <= 1) return false;

            j = i + 1;

            while (j<k)
            {
                if (nums[i] < nums[j] && nums[j] < nums[k])
                    return true;
                     
                j++;
            }

            return false;
        }

        // this solution does not meet the O(n) time complexity req
        public bool IncreasingTriplet_BruteForce(int[] nums)
        {
            int idx = 0;
            for (; idx < nums.Length - 2;idx++ )
            {
                if (nums[idx] < nums[idx + 1]) break;
            }
            
            int i, j, k;
            i = idx;
            j = i + 1;
            k = j + 1;
            

            while (i < nums.Length-2)
            {
                j = i + 1;
                while (j < nums.Length - 1)
                {
                    k = j + 1;
                    while (k < nums.Length)
                    {
                        if(nums[i]<nums[j]&&nums[j]<nums[k])
                            return true;
                        k++;
                    }

                    j++;
                }

                i++;
            }

            return false;
        }
    }
}
