using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int maximumToys(int[] prices, int k) {
        // Complete this function
        Array.Sort(prices);
        int maxToys = 0;
        while ((k > 0) && (maxToys <= prices.Length - 1))
        {
            k = k - prices[maxToys];
            maxToys++;
        }
        return (k < 0) ? --maxToys : maxToys; 
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
