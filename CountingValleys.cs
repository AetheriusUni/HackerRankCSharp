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
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    // valleys - when you return to zero height from a negative height
    public static int countingValleys(int steps, string path)
    {
        int height = 0;
        char[] arr = path.ToCharArray();
        int numValleys = 0;
        // for each step taken
        for(int i = 0; i < arr.Length; i++)
        {
            // if you went up, add 1 to height
            if(arr[i]=='U')
            {
                height++;
                // if we went from a negative height to 0, we exited a valley
                if(height==0)
                {
                    numValleys++;
                }
            }
            // if you went down, subtract 1 from height
            else
            {
                height--;
            }
        }
        return numValleys;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
