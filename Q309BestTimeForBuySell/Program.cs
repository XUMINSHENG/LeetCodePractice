using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    // stack overflow
    class Program
    {
        static void Main(string[] args)
        {

            //int[] input = { 1, 2, 3, 0, 2 };
            int[] input = { 1, 2, 4 };
            //int[] input = { 2, 1, 4 };
            // 

            //Q309Rec q = new Q309Rec();
            Q309DP q = new Q309DP();
            Console.WriteLine(q.MaxProfit(input));
            Console.ReadKey();

        }
    }
}
