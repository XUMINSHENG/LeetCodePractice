using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q53_MaximunSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            
            int res = p.MaxSubArray(
                new int[] //{ -2, 1, -3, 4, -1, 2, 1, -5, 4 }
                { 1, 2 }
                );
            Console.WriteLine(res);
            Console.ReadKey();
        }

        int max;
        public int MaxSubArray(int[] nums)
        {
            max = nums[0];
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (max < sum)
                {
                    max = sum;
                }

                if (sum < 0)
                {
                    sum = 0;
                }
            }

            return max;
        }
    }
}
