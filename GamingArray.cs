// https://www.hackerrank.com/challenges/an-interesting-game-1/problem

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution 
{
    static void Main(String[] args)
    {
        int g = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < g; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arrTemp = Console.ReadLine().Split(' ');
            int[] arr = new int[n];
            arr = Array.ConvertAll(arrTemp, Int32.Parse);

            // Right, but too slow
            //int turnCnt = 0;
            //int maxIndex = n;
            //do
            //{
            //    int maxValue = arr.Take(maxIndex).Max();
            //    maxIndex = arr.ToList().IndexOf(maxValue);
            //    turnCnt++;
            //} while (maxIndex != 0);

            int currentMax = 0;
            int turnCnt = 0;
            for (int i = 0; i < n; i++)
            {
                if(arr[i]>currentMax)
                {
                    currentMax = arr[i];
                    turnCnt++;
                }
            }

            if (turnCnt % 2 == 0)
            {
                Console.WriteLine("ANDY");
            }
            else
            {
                Console.WriteLine("BOB");
            }
        }
    }
}
