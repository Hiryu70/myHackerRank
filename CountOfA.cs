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

class Solution
{

	// Complete the repeatedString function below.
	static long repeatedString(string s, long n)
	{
		if (s.Length >= n)
		{
			return aInString(s.Substring(0, (int)n));
		}

		var partsCount = n / s.Length;
		var substringReminder = n % s.Length;

		var onePartCount = aInString(s);
		var reminderCount = aInString(s.Substring(0, (int) substringReminder));

		return partsCount * onePartCount + reminderCount;
	}

	static int aInString(string s)
	{
		return s.ToCharArray().Count(c => c == 'a');
	}

	static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string s = Console.ReadLine();

		long n = Convert.ToInt64(Console.ReadLine());

		long result = repeatedString(s, n);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
