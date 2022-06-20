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
     * Complete the 'checkMagazine' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY magazine
     *  2. STRING_ARRAY note
     */

    public static void checkMagazine(List<string> magazine, List<string> note)
    {
        IDictionary<string, int> magDict = new Dictionary<string, int>();
        //IDictionary<char, int> noteDict = new Dictionary<char, int>();
        for(int i = 0; i < magazine.Count; i++)
        {
            if(magDict.ContainsKey(magazine[i]))
            {
                magDict.Add(magazine[i], magDict[magazine[i]]+1);
            }
            else
            {
                magDict.Add(magazine[i], 1);
            }
        }
        for(int i = 0; i < note.Count; i++)
        {
            // if the dictionary has the string
            if(magDict.ContainsKey(note[i]) && magDict[note[i]]>0)
            {
                magDict[note[i]]--;
            }
            // if the dictionary doesn't have the string
            else
            {
                Console.WriteLine("No");
                return;
            }
        }
        Console.WriteLine("Yes");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        List<string> magazine = Console.ReadLine().TrimEnd().Split(' ').ToList();

        List<string> note = Console.ReadLine().TrimEnd().Split(' ').ToList();

        Result.checkMagazine(magazine, note);
    }
}
