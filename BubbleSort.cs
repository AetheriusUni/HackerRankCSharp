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
     * Complete the 'countSwaps' function below.
     *
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static void countSwaps(List<int> a)
    {
        int temp = 0;
        int numSwaps = 0;
        // for each elemnt in list a
        for(int i = 0; i < a.Count; i++)
        {
            // make sure all elements before it are less than it
            // and all elements after it are greater than it
            for(int j = 0; j < a.Count-1; j++)
            {
                //swap(a[j], a[j+1]);
                // swap function, also adds 1 to the numSwaps variable
                if (a[j] > a[j+1])
                {
                    temp = a[j];
                    a[j] = a[j+1];
                    a[j+1] = temp;
                    numSwaps++;
                }
            }
        }
        Console.WriteLine("Array is sorted in {0} swaps.", numSwaps);
        Console.WriteLine("First Element: {0}", a[0]);
        Console.WriteLine("Last Element: {0}", a[a.Count-1]);
    }
    

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        Result.countSwaps(a);
    }
}
