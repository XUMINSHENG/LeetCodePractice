using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q215FindKthLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            int[] nums =
                {199,7,50,30,20,40,1,2,3,4,5};
                //{ -1,2,0};

            Console.WriteLine(p.FindKthLargest(nums, 7));
            Console.ReadKey();
        }

        
        public int FindKthLargest(int[] nums, int k) {
            int result;
            result = FindByQuickSelect(nums, k);
            return result;
        }

        // 200 ms
        // quick select 
        private int FindByQuickSelect(int[] nums, int k)
        {

            Quick.SortK(nums, k, 0, nums.Length -1);
            return nums[k-1];
        }


        // 188 ms
        // insert sort for first K elements first, then compare
        private int FindBySortMix(int[] nums, int k)
        {
            int j, tmp;
            int i = 1;
            // start from 1, sort first k elements
            for (; i < k; i++)
            {
                tmp = nums[i];
                j = i - 1;
                while (j >= 0 && tmp > nums[j])
                {
                    nums[j + 1] = nums[j--];
                }

                nums[j + 1] = tmp;
            }

            for (; i < nums.Length; i++)
            {
                if(nums[i]<nums[k - 1])continue;
                else{
                    nums[k - 1] = nums[i];
                }
                tmp = nums[k - 1];
                j = k - 2;
                while (j >= 0 && tmp > nums[j])
                {
                    nums[j + 1] = nums[j--];
                }

                nums[j + 1] = tmp;
            }


            return nums[k - 1];
        }

        // 274 ms
        // insert sort all
        private int FindBySortAll(int[] nums, int k)
        {
            int j,tmp;
            // start from 1
            for (int i = 1; i < nums.Length;i++)
            {
                tmp = nums[i];
                j=i-1;
                while(j>=0&&tmp > nums[j]){
                    nums[j+1] = nums[j--];
                }

                nums[j+1] = tmp;
            }

            return nums[k-1];
        }

        // 204 ms
        // select sort for K th largest
        private int FindBySortK(int[] nums, int k)
        {
            
            for (int i = 0; i < k; i++)
            {
                int ind = i;
                int max = int.MinValue;
                for(int j =i;j<nums.Length;j++){
                    if (nums[j] > max)
                    {
                        ind = j;
                        max = nums[j];
                    }
                }
                nums[ind] = nums[i];
                nums[i] = max;
                
            }

            return nums[k-1];
        }

    }
}
