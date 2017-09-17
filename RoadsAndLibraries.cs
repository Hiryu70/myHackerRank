// https://www.hackerrank.com/challenges/torque-and-development/problem

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            long x = Convert.ToInt64(tokens_n[2]);
            long y = Convert.ToInt64(tokens_n[3]);
            for(int a1 = 0; a1 < m; a1++){
                string[] tokens_city_1 = Console.ReadLine().Split(' ');
                int city_1 = Convert.ToInt32(tokens_city_1[0]);
                int city_2 = Convert.ToInt32(tokens_city_1[1]);
            }
        }
    }
}
