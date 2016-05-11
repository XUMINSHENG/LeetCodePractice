using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Q309DP
    {
        

        public int MaxProfit(int[] prices)
        {
            int end = prices.Length;

            // array represents the max profit under given conditions, before that day's movement
            int[] hold = new int[end + 1];
            int[] nholdncd = new int[end + 1];
            int[] nholdcd = new int[end + 1];

            hold[end] = 0;
            nholdncd[end] = 0;
            nholdcd[end] = 0;

            for (int i = end - 1; i >= 0; i--)
            {
                // sell or do nothing
                hold[i] = Math.Max(nholdcd[i + 1] + prices[i], hold[i + 1]);
                // do nothing or buy
                nholdncd[i] = Math.Max(nholdncd[i + 1], hold[i + 1] - prices[i]);
                // do nothing
                nholdcd[i] = nholdncd[i + 1];

            }
            return nholdncd[0];
        }
    }
    



}
