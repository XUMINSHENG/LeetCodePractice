using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q78_Subset
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            p.Subsets(new int[]{4,0,1,2,3});

            Console.WriteLine();
            Console.ReadKey();
        }


        public IList<IList<int>> Subsets(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();

            // empty set always be there
            List<int> element = new List<int>();
            res.Add(element);

            for (int pickTotal = 1; pickTotal <= nums.Length; pickTotal++)
            {
                // pick represent the idx of the No that will be included in element
                int[] pick = new int[pickTotal];
                for (int i = 0; i < pickTotal;i++ )
                {
                    pick[i] = i;
                }

                // pick pickTotal from nums.Length 
                // for example pick 3 from 5, exit criteria is 345, first No becomes 3
                while (pick[0] != nums.Length - pickTotal + 1)
                {

                    element = new List<int>();
                    for (int i = 0; i < pick.Length; i++)
                    {
                        element.Add(nums[pick[i]]);
                    }
                    res.Add(element);

                    // move cursor 123 -> 124 -> 125 -> 134 -> 135 -> 145 -> 234
                    pick[pick.Length - 1]++;

                    // check overflow
                    int lowestIdx = int.MaxValue;
                    for (int i = 0; i < pick.Length - 1; i++)
                    {
                        if (pick[pick.Length - i - 1] > nums.Length - i - 1)
                        {
                            pick[pick.Length - i - 1 - 1]++;
                            lowestIdx = pick.Length - i - 1 - 1;
                        }
                        else break;
                    }

                    for (int i = lowestIdx; i < pick.Length-1; i++)
                    {
                        pick[i+1] = pick[i] + 1;
                    }
                    
                }                  
            }

            return res;
        }
    }
}
