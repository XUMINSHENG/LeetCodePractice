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

            // the point is, for a num, three possibility
            // 1. smaller than min
            // 2. between min and secMin
            // 3. larger than secMin
            // 1 and 2 will lower the boundary, 3 is the exit criteria to return true
            // at the end, the min may not be the exact num that composed the triplet, 
            // but it does not affect the correctness
            int min = int.MaxValue, secMin = int.MaxValue;

            for (int i = 0; i < nums.Length;i++ )
            {
                if(nums[i]<=min){
                    min = nums[i];
                }
                else if(nums[i]<=secMin)
                {
                    secMin = nums[i];
                }
                else
                {
                    return true;
                }

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
