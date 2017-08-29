// https://www.hackerrank.com/challenges/flipping-the-matrix

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) 
    {
        int q = Convert.ToInt32(Console.ReadLine());
        int n;
        int[][][] arr = new int[q][][];
        
        for (int arr_q = 0; arr_q < q; arr_q++)
        {
            n = Convert.ToInt32(Console.ReadLine());
            for(int arr_i = 0; arr_i < 2 * n; arr_i++)
            {
               string[] arr_temp = Console.ReadLine().Split(' ');
               arr[arr_q][arr_i] = Array.ConvertAll(arr_temp,Int32.Parse);
            }
        }

        for (int arr_q = 0; arr_q < q; arr_q++)
        {
            for(int arr_i = 0; arr_i < 2 * n; arr_i++)
            {
                for (int arr_j = 0; arr_j < 2 * n; arr_j)
                {
                    Console.Write(arr[arr_q][arr_i][arr_j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
