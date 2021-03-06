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
     * Complete the 'luckBalance' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. 2D_INTEGER_ARRAY contests
     */

    // k = max number of important contests that can be lost
    public static int luckBalance(int k, List<List<int>> contests)
    {
        int luck = 0;
        /* 
        contests[0] = L[0], T[0]
        contests[0][0] = L[0]
        contests[0][1] = T[0]
        */
        List<int> importantContests = new List<int>();
        
        // mark important contests
        for(int i = 0; i < contests.Count; i++)
        {
            // important contests are stored and luck isn't updated YET
            if(contests[i][1] == 1)
            {
                importantContests.Add(contests[i][0]);
            }
            else
            {
                luck+= contests[i][0];
            }
        }
        
        // sort important contests from high to low values
        importantContests.Sort();
        importantContests.Reverse();
        
        // decide which contests to win or lose
        for(int i = 0; i < importantContests.Count; i++)
        {
            // lose the contests with higher values
            if(i < k)
            {
                luck+= importantContests[i];
            }
            // win the contests with lower values
            else
            {
                luck-= importantContests[i];
            }
        }
        return luck;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> contests = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            contests.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(contestsTemp => Convert.ToInt32(contestsTemp)).ToList());
        }

        int result = Result.luckBalance(k, contests);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
