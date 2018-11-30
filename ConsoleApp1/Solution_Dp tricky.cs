using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Solution
    {
        //Say you have an array for which the ith element is the price of a given stock on day i.

        //    Design an algorithm to find the maximum profit.You may complete at most two transactions.

        //    Note:
        //You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
        //Input : [1 2 1 2]
        //Output : 2

        //Explanation : 
        //Day 1 : Buy
        //    Day 2 : Sell
        //    Day 3 : Buy
        //    Day 4 : Sell
        public int maxProfit_BestBuyAndSellIII(List<int> A)
        {

            var prices = A.ToArray();
            if (prices == null || prices.Length < 2)
            {
                return 0;
            }

            int[] left = new int[prices.Length];
            int[] right = new int[prices.Length];


            left[0] = 0;
            int min = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                left[i] = Math.Max(left[i - 1], prices[i] - min);
            }

            right[prices.Length - 1] = 0;
            int max = prices[prices.Length - 1];

            for (int i = prices.Length - 2; i >= 0; i--)
            {
                max = Math.Max(max, prices[i]);
                right[i] = Math.Max(right[i + 1], max - prices[i]);
            }

            int profit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                profit = Math.Max(profit, left[i] + right[i]);
            }

            return profit;
        }
    }
}





