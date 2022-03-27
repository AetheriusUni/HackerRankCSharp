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

class Result
{

    /*
     * Complete the 'sockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY ar
     */
    
    // count the number of matching pairs of socks
    public static int sockMerchant(int n, List<int> ar)
    {
        ar.Sort();
        Console.WriteLine(string.Join(", ", ar));
        int count = 0;
        int numPairs = 0;
        int sockType = ar[0];
        
        // for each sock 
        for(int i = 0; i < n; i++)
        {
            // if the sock is the same type as the last sock we add 1 to the number of those socks
            if(ar[i] == sockType)
            {
                count++;
                // if we're on the last type of sock and we're about to exit the loop
                if(i+1 == n)
                {
                    // we add the number of pairs of socks of that type to the numPairs variable
                    numPairs += count/2;
                }
            }
            // if we are looking at a different category of sock
            else
            {
                // add the number of pairs of socks of that type to the numPairs variable
                numPairs += count/2;
                // update the sock type to the current sock type
                sockType = ar[i];
                // set the count of that sock type to 1
                count = 1;
            }
        }
        return numPairs;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
