using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Q309Mem
    {
        const int C_CD = 0;
        const int C_NOT_CD = 1;
        const int C_HOLD = 1;
        const int C_NOT_HOLD = 0;
        
        //static int[,] arr;

        static Hashtable tab;

        public int MaxProfit(int[] prices)
        {
            //arr = new int[3, prices.Length + 1];
            tab = new Hashtable(3 * prices.Length);
            return move(prices, 0, C_NOT_HOLD, 0, C_NOT_CD); ;
        }

        //recursion
        private int move(int[] prices, int day, int isHold, int profit, int isCD, int buyPrice = 0)
        {
            // day - buyPrice - isHold - isCD
            string key = day + "-" + buyPrice + "-" + isHold + "-" + isCD;
            // base case - the end day
            if (day == prices.Length)
            {
                return profit;
            }

            //int max = arr[isHold + isCD, day];
            
            if (tab.ContainsKey(key))
            {
                return Int32.Parse(tab[key].ToString());
            }
            int max = 0;
            // buy
            if (isHold == C_NOT_HOLD && isCD == C_NOT_CD)
            {
                int profitBuy = move(prices, day + 1, C_HOLD, profit - prices[day], C_NOT_CD, prices[day]);
                max = profitBuy > max ? profitBuy : max;
            }

            // sell
            if (isHold == C_HOLD)
            {
                int profitSell = move(prices, day + 1, C_NOT_HOLD, profit + prices[day], C_CD);
                max = profitSell > max ? profitSell : max;
            }

            int profitCD = move(prices, day + 1, isHold, profit, C_NOT_CD);
            max = profitCD > max ? profitCD : max;
            tab.Add(key, max);
            //arr[isHold + isCD, day] = max;
            return max;
        }

    }
    



}
