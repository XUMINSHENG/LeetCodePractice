using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q300_LongestIncSubseq
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.LengthOfLIS(new int[] 
                { 5,6,7,8, 10, 9, 2, 5, 3, 7, 101, 18 }
                //{ 10,9,2,5,3,4}
                );



        }

        // O(n^2) due to the need of search the processed items for a num 
        // that bigger than current one meanwhile has the biggest maxLength
        public int LengthOfLIS_ON2(int[] nums)
        {
            if(nums.Length == 0)return 0;
            int maxL = 1;

            int[] maxLength = Enumerable.Repeat(1, nums.Length).ToArray();

            for (int i = nums.Length - 2; i >=0; i--)
            {

                for (int j = i + 1; j < nums.Length;j++ )
                {
                    if(nums[i]<nums[j]){
                        if (maxLength[j] + 1 > maxLength[i])
                        {
                            maxLength[i] = maxLength[j] + 1;

                            if (maxLength[i] > maxL) 
                                maxL = maxLength[i];
                        }
                    }
                }

            }

            return maxL;
        }

        // O(n^2) due to the need of search the processed items for a num 
        // that bigger than current one meanwhile has the biggest maxLength
        // try to improve it by introducing hashtable
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int maxL = 1;

            // record the max num with corresponding length
            // for a num that smaller than that max, it will add the length by 1
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, int.MaxValue);
            dict.Add(1, nums[nums.Length - 1]);

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                // j represent a key
                for (int j = dict.Count-1; j >=0; j--)
                {
                    if (nums[i] < dict[j])
                    {
                        if (!dict.ContainsKey(j + 1))
                        {
                            dict.Add(j + 1, nums[i]);
                        }
                        else
                        {
                            dict[j + 1] = nums[i];
                        }
                        break;
                        
                    }
                }

            }

            return dict.Count-1;
        }
        

    }
}
