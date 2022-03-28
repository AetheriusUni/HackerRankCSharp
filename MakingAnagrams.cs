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
     * Complete the 'makeAnagram' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING a
     *  2. STRING b
     */

    public static int makeAnagram(string a, string b)
    {
        // we want the smaller string to be string 'a' as a small optimization        
        if(a.Length>b.Length)
        {
            string temp = a;
            a = b;
            b = temp;
        }
        
        // convert the strings to char lists
        List<char> aList = a.ToList();
        //List<char> bList = b.ToList();

        // make a copy of those lists that can be edited
        List<char> aHold = aList;
        //List<char> bHold = bList;
        List<char> bHold = b.ToList();
        
        // for each char in aList, have to put ToList() for some reason or there's an error
        // the error was something about collection being modified
        // adding ToList() makes a copy of the list, whie prevents the original collection being modified
        // ??? I don't understand
        foreach(char ele in aList.ToList())
        {
            // if there's a common element in aHold and bHold
            // remove it from both           
            if(bHold.Contains(ele))
            {
                aHold.Remove(ele);
                bHold.Remove(ele);
            }
        }
        // return the sum of aHold and bHold, representing all the non-common chars
        return aHold.Count + bHold.Count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = Result.makeAnagram(a, b);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
