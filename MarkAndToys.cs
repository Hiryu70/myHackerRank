using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int maximumToys(int[] prices, int k) {
        // Complete this function
        Array.Sort(prices);
        int maxToys = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            k = k - prices[i];
            maxToys++;
            if (k < 0)
            {
                return maxToys;
            }
        }
        return maxToys;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] prices_temp = Console.ReadLine().Split(' ');
        int[] prices = Array.ConvertAll(prices_temp,Int32.Parse);
        int result = Solution.maximumToys(prices, k);
        Console.WriteLine(result);
    }
}