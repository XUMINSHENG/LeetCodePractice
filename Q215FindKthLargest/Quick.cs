using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q215FindKthLargest
{
    class Quick
    {
        public static int Median3(int[] input, int left, int right)
        {
            int center = (left + right) / 2;

            // left >= center >= right
            if (input[left] < input[center])
            {
                Swap(input, left, center);   
            }
            if (input[left] < input[right])
            {
                Swap(input, left, right);
            }
            if (input[center] < input[right])
            {
                Swap(input, center, right);
            }

            // hide pivot
            Swap(input, center, right - 1);

            return input[right - 1];
        }


        public static void Swap(int[] input, int left, int right)
        {
            int tmp = input[left];
            input[left] = input[right];
            input[right] = tmp;
        }


        public static void SortK(int[] input, int k, int left, int right)
        {
            int CUTOFF = 10;
            int i,j;
            int pivot;
            if(left + CUTOFF <= right){
                pivot = Median3(input, left, right);
                i = left; j = right - 1;

                for (; ; )
                {
                    while (input[++i] > pivot) ;
                    while (input[--j] < pivot) ;
                    if(i<j){
                        Swap(input, i, j);
                    }
                    else
                    {
                        break;
                    }
                }

                //restore pivot
                Swap(input, i, right - 1);

                if(k<i){
                    SortK(input, k , left, i-1);
                }else if(k>i){
                    SortK(input, k, i+1, right);
                }


            }else{
                // insert sort a left, right
                InsertSort(input, left, right);
            }

        }

        // 274 ms
        // insert sort all
        private static void InsertSort(int[] nums, int left, int right)
        {
            int j, tmp;
            // start from 1
            for (int i = 1; i < nums.Length; i++)
            {
                tmp = nums[i];
                j = i - 1;
                while (j >= 0 && tmp > nums[j])
                {
                    nums[j + 1] = nums[j--];
                }

                nums[j + 1] = tmp;
            }

        }

    }
}
