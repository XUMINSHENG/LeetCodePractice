using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Q309Rec
    {

      
        public int MaxProfit(int[] prices)
        {
            
            return move(prices, 0, false, 0, false);;
        }

        //recursion
        private int move(int[] prices, int day, bool isHold, int profit, bool isCD)
        {
            int max = 0;

            // base case - the end day
            if (day == prices.Length)
            {
                return profit;
            }


            // buy
            if (!isHold && !isCD)
            {
                int profitBuy;
                // int profitBuy = profit;
                // profitBuy-=prices[day];
                profitBuy = move(prices, day + 1, true, profit - prices[day], false);
                max = profitBuy > max ? profitBuy : max;
            }

            // sell
            if (isHold)
            {
                int profitSell;
                // profit+=prices[day];
                // isCD = true;
                profitSell = move(prices, day + 1, false, profit + prices[day], true);
                max = profitSell > max ? profitSell : max;
            }


            // cooldown or choice to do nothing
            // if(isCD){
            // isCD = false;
            int profitCD = move(prices, day + 1, isHold, profit, false);
            max = profitCD > max ? profitCD : max;
            // }

            return max;
        }

    }
}
