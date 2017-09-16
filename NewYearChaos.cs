// https://www.hackerrank.com/challenges/new-year-chaos/problem

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void minimumBribes(int[] q)
    {
        bool showSubResult = false;
        int bribe = 0;
        if (showSubResult) { Console.WriteLine("---------------New Queque!--------------"); }
        for (int i = 0; i < q.Length; i++)
        {
            if (showSubResult) { Console.WriteLine(); }
            if (showSubResult) { Console.Write("{0} {1} = {2}", i + 1, q[i], q[i] - i - 1); }
            if (q[i] == i + 2)
            {
                if (showSubResult) { Console.Write(" bribe+1"); }
                bribe++;
            }
            else if (q[i] == i + 3)
            {
                if (showSubResult) { Console.Write(" bribe+2"); }
                bribe++;
                bribe++;
            }
            else if (q[i] > i + 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }
            else
            {
                for (int b = 1; b < 50; b++)
                {
                    if (i < q.Length - b)
                    {
                        if (q[i] > q[i + b])
                        {
                            if (showSubResult) { Console.Write(" bribe+1"); }
                            bribe++;
                        }
                    }
                }
            }
        }
        Console.WriteLine(bribe);
    }

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] q_temp = Console.ReadLine().Split(' ');
            int[] q = Array.ConvertAll(q_temp, Int32.Parse);
            minimumBribes(q);
        }
    }
}
