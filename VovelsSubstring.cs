using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Security.Policy;


class Result
{

    /*
     * Complete the 'findSubstring' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */
    private static char[] _vovels =
    {
	    'a', 'e', 'i', 'o', 'u'
    };

    public static int VowelCount(string substring)
    {
	    int count = 0;
	    foreach (char c in substring)
	    {
		    if (_vovels.Contains(c))
		    {
			    count++;
		    }
	    }

	    return count;
    }


    public static string findSubstring(string s, int k)
    {
	    int maxVowels = 0;
	    string substring = "Not found!";

	    var currentSubstring = s.Substring(0, k);
	    var vovelCount = VowelCount(currentSubstring);

	    if (vovelCount > maxVowels)
	    {
		    maxVowels = vovelCount;
		    substring = currentSubstring;
	    }

        for (int i = 0; i < s.Length - k; i++)
        {
	        var a = s[i];

			if (_vovels.Contains(a))
		    {
			    vovelCount--;
		    }

			var b = s[i + k];

			if (_vovels.Contains(b))
		    {
			    vovelCount++;
		    }

		    if (vovelCount > maxVowels)
		    {
			    currentSubstring = s.Substring(i+1, k);
				maxVowels = vovelCount;
			    substring = currentSubstring;
			}
	    }

	    return substring;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //string s = Console.ReadLine();

        //int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.findSubstring("caberqiiterfg", 5);
        Console.WriteLine(result);
        Console.ReadLine();
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
