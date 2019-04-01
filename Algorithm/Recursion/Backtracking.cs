using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
   public class Backtracking
   {
        /// <summary>
        /// A simple example backtracking algorithem
        /// Give you the nubmer from 1,2,3... to 30.  
        /// List all the combination the nubmer sum equals to 50
        /// For example:  30, 20
        ///               30, 19,1
        ///               ...
        ///               
        /// </summary>
        
        static bool[] selected = new bool[100];  //hard code arry to track the number selected for sum, set to true if selected, other false.
        static int totalNum = 0;
        
        // find sum(sequence number) equals to a target number
        public static string ListAll(int endNum, int targetSum, int curSum)
        {

            for (int i = endNum; i >= 1; i--)
            {
                totalNum = totalNum + 1;
                selected[i] = true;
                int sum = curSum + i;

                if (sum < targetSum)
                {
                    ListAll(i - 1, targetSum, sum);
                    selected[i] = false;
                }
                else if (sum == targetSum)
                {
                    for (int j = 30; j >= 1; j--)
                    {
                        if (selected[j] == true)
                            Console.Write(j + " ");
                    }
                    selected[i] = false;
                    //Console.Read();
                    Console.WriteLine();
                }
                else if (sum > targetSum)
                {
                    selected[i] = false;
                    //break;
                }
            }

            return "Done";
        }


        /// <summary>
        /// find sum(n elements in the ary) equals to a target number 
        /// BackTracking
        /// </summary>
        /// <param name="ary">array input</param>
        /// <param name="target">target sum int</param>
        /// <param name="start">from which index to add</param>
        /// <param name="sum">current sum</param>
        /// Test code:
        /// int[] arry = new int[] { 1, 2, 5, 3, 10, 8, 7, 5, 12 };
        /// int target = 10;
        /// FindCombination(arry, target, 0, 0);
        /// Console.Read();
        /// return;
        /// Expected results: 1,2,7
        ///                   2,5,3
        ///                   2,3,5
        static List<int> lstTrack = new List<int>();
        public static void FindCombination(int[] ary, int target, int start, int sum)
        {
            for (int i = start; i < ary.Length; i++)
            {
                if (lstTrack.Count > 3) break;

                lstTrack.Add(i);
                if ((sum + ary[i]) == target)
                {
                    if (lstTrack.Count == 3)
                    {
                        foreach (int temp in lstTrack)
                        {
                            Console.Write(ary[temp] + " ");
                        }
                        Console.WriteLine();
                    }
                    lstTrack.Remove(i);
                }
                else
                {
                    FindCombination(ary, target, i + 1, sum + ary[i]);
                    lstTrack.Remove(i);
                }
            }
        }
    }
}
