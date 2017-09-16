// https://www.hackerrank.com/challenges/birthday-cake-candles/problem
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static int birthdayCakeCandles(int n, int[] ar) {
        int max = ar.Max();
        int counter = 0;
        for (int i = 0; i < ar.Length; i++)
        {
            if (ar[i] == max)
            {
                counter++;
            }
        }
        return counter;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] ar_temp = Console.ReadLine().Split(' ');
        int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
        int result = birthdayCakeCandles(n, ar);
        Console.WriteLine(result);
    }
}
