using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _322CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] coins = { 186, 419, 83, 408 };
            //int amount = 6249;

            //int[] coins = { 1, 2 };
            //int amount = 2;

            int[] coins = { 474, 83, 404, 3 };
            int amount = 264;

            Console.WriteLine((new Program()).CoinChange(coins, amount));
            Console.ReadKey();
        }
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0)
            {
                return 0;
            }
            else
            {
                Array.Sort(coins);
                if (amount < coins[0])
                {
                    return -1;
                }
            }
            
            int[] result = Enumerable.Repeat(-1, amount + 1).ToArray();
            result[0] = 0;
            result[coins[0]] = 1;
            for (int i = coins[0] + 1; i <= amount;i++ )
            {
                //bool isSolved = false;
                foreach(int c in coins){
                    //using coin c can make the required change
                    if((i-c>=0)&&result[i-c]>=0){
                        // find the minimun no of coins, which should not be -1
                        result[i] = result[i]==-1?result[i - c] + 1:Math.Min(result[i], result[i - c] + 1);
                    }
                }
            }

            return result[amount];
        }

    }
}
