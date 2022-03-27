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
     * Complete the 'jumpingOnClouds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY c as parameter.
     */

    public static int jumpingOnClouds(List<int> c)
    {
        int jCount = 0;
        bool weDone = true;
        int maxJump = 0;
        
        for(int i = 0; i < c.Count-1; i++)
        {
            // check for if the maxJump would go past the last cloud
            // if it would, we add 1 to jCount since we only need to make a 1 space jump
            maxJump = i+2;
            if(maxJump == c.Count)
            {
                jCount++;
                break;
            }
            // if a 2 space jump can be made we make that jump by skipping the next value of i
            if(c.ElementAt(maxJump)==0)
            {
                i++;
            }
            // add 1 to the number of jumps we've made since we can always jump
            jCount++;
        }
        return jCount;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

        int result = Result.jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
