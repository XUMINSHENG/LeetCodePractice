using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Program p = new Program();
            //int[] input = { 3, 30, 34, 5, 9 };
            //int[] input = {4704,6306,9385,7536,3462,4798,5422,5529,8070,6241,9094,7846,663,6221,216,6758,8353,3650,3836,8183,3516,5909,6744,1548,5712,2281,3664,7100,6698,7321,4980,8937,3163,5784,3298,9890,1090,7605,1380,1147,1495,3699,9448,5208,9456,3846,3567,6856,2000,3575,7205,2697,5972,7471,1763,1143,1417,6038,2313,6554,9026,8107,9827,7982,9685,3905,8939,1048,282,7423,6327,2970,4453,5460,3399,9533,914,3932,192,3084,6806,273,4283,2060,5682,2,2362,4812,7032,810,2465,6511,213,2362,3021,2745,3636,6265,1518,8398};
            //int[] input = {9051,5526,2264,5041,1630,5906,6787,8382,4662,4532,6804,4710,4542,2116,7219,8701,8308,957,8775,4822,396,8995,8597,2304,8902,830,8591,5828,9642,7100,3976,5565,5490,1613,5731,8052,8985,2623,6325,3723,5224,8274,4787,6310,3393,78,3288,7584,7440,5752,351,4555,7265,9959,3866,9854,2709,5817,7272,43,1014,7527,3946,4289,1272,5213,710,1603,2436,8823,5228,2581,771,3700,2109,5638,3402,3910,871,5441,6861,9556,1089,4088,2788,9632,6822,6145,5137,236,683,2869,9525,8161,8374,2439,6028,7813,6406,7519};
            int[] input = {999999998,999999997,999999999};
            Console.WriteLine(p.LargestNumber(input));
            Console.ReadKey();


        }

        const int CUTOFF = 10;
        public string LargestNumber(int[] nums)
        {
            
            CompareObj[] objs = new CompareObj[nums.Length];
            for(int i=0; i< nums.Length;i++){
                objs[i] = new CompareObj(nums[i]);
            }

            objs = QuickSort(objs);
            StringBuilder sb = new StringBuilder();

            foreach (CompareObj co in objs)
            {
                sb.Append(co.chars);
            }
            string result = sb.ToString();
            return result.StartsWith("0")?"0":result;
        }

        private CompareObj[] InsertSort(CompareObj[] objs)
        {
            CompareObj tmp;
            for (int i = 1; i < objs.Length; i++)
            {
                tmp = objs[i];

                // find index
                int j = i - 1;
                for (; j >= 0; j--)
                {
                    if (tmp.Compare(objs[j])<0)
                    {
                        break;
                    }
                    else
                    {
                        objs[j + 1] = objs[j];
                    }

                }
                objs[j + 1] = tmp;
            }

            return objs;
        }

        private CompareObj[] QuickSort(CompareObj[] objs)
        {
            CompareObj[] result = q_sort(objs, 0, objs.Length - 1);
            result = InsertSort(result);
            return result;
        }

        private CompareObj[] q_sort(CompareObj[] input, int left, int right)
        {
            CompareObj tmp;
            if( left + CUTOFF <= right){
                CompareObj pivot = median3(input, left, right);
			
			    int i = left;
			    int j = right - 1;
			    for(;;){
				    while(input[++i].Compare(pivot)<0);
				    while(input[--j].Compare(pivot)>0);
				    if(i<j){
					    //swap
                        tmp = input[i];
					    input[i]=input[j];
					    input[j] = tmp;
				    }else{
					    break;
				    }
			    }
			
			    // restore pivot
			    //swap
                tmp = input[i];
			    input[i]=input[right-1];
			    input[right-1] = tmp;
			
			    //recursion
			    q_sort(input,left,i-1);
			    q_sort(input,i+1,right);
		    }
		    return input;
        }

        private CompareObj median3(CompareObj[] input, int left, int right)
        {
            
            CompareObj tmp;
            int center = (left + right) / 2;

            // left <= center <= right
            if (input[left].Compare(input[center])>0)
            {
                //swap without tmp
                tmp = input[left];
                input[left] = input[center];
                input[center] = tmp;
            }
            if (input[left].Compare(input[right])>0)
            {
                tmp = input[left];
                input[left] = input[right];
                input[right] = tmp;
            }
            if (input[center].Compare(input[right])>0)
            {
                tmp = input[center];
                input[center] = input[right];
                input[right] = tmp;
            }

            // hide pivot
            tmp = input[center];
            input[center] = input[right - 1];
            input[right - 1] = tmp;

            return input[right - 1];
        }

        class CompareObj
        {
            
            public int chars { get; set; }
            public CompareObj(int num){
                chars = num;
            }

            public int Compare(CompareObj obj)
            {
                long i1 = ConcatInt2(this.chars, obj.chars);
                long i2 = ConcatInt2(obj.chars, this.chars);
                if (i1 > i2)
                    return 1;
                else if (i1 < i2)
                    return -1;
                else
                    return 0;
                
            }

            private long ConcatInt2(int x, int y)
            {
                return (long)(x * Math.Pow(10, y.ToString().Length)) + y;
            }

        }
    }
}
