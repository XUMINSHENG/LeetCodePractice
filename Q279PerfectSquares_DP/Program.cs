using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q279PerfectSquares_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine(p.NumSquares(13));
            Console.ReadKey();

        }

        public int NumSquares(int n)
        {
            // valid Squares
            int maxSq =  (int)Math.Sqrt(n);
            int[] sqList = new int[maxSq];
            for (int i = 0; i < maxSq;i++ )
            {
                sqList[i] = (int)Math.Pow((i + 1), 2);
            }

            int[] arr = Enumerable.Repeat(-1, n + 1).ToArray();
            arr[0] = 0;

            // i represent each amount need to make change
            for (int i = 1; i <= n;i++ )
            {
                foreach (int sq in sqList)
                {
                    if (i<sq) break;

                    arr[i] = arr[i] != -1 ? Math.Min(arr[i], arr[i - sq] + 1) : arr[i - sq] + 1;

                }
            }


            return arr[n];
        }

    }
}
