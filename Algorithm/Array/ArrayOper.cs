using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
   public class ArrayOper
   {
         // Judge if popv array is a possible population of stack
         // for example:  pushV is  1,2,3,4,5   popv 4,5,3,2,1 is a possible population array
         // but 4,5,3,1,2 is not the possible array
        public static bool IsPopOrder(int[] pushV, int[] popV)
        {
            List<int> push = pushV.ToList();
            List<int> pop = popV.ToList();

            if (push.Count != pop.Count || push.Any(x => !pop.Contains(x)))
                return false;

            // use first popV element to separate pushV, left array should be existing in popV strictly in sequence;
            // for right part, continue the recursive judge.
            int index = push.IndexOf(pop[0]);  

            List<int> left = push.Take(index).ToList();
            left.Reverse();

            if (left.Count > 0 && !AIncludeB(pop,left))
                return false;

            List<int> right = push.Except(left).ToList();
            pop = pop.Except(left).ToList();

            if (right.Count > 0)
            {
                right.RemoveAt(0);
                if (right.Count > 0)
                {
                    pop.RemoveAt(0);
                    return IsPopOrder(right.ToArray(), pop.ToArray()); //recursive judge left branch sequence
                }
            }

            return true;
        }

        private static bool AIncludeB(List<int> a, List<int> b)
        {
            string strA =string.Empty, strB =string.Empty;
            a.ForEach(x => strA = strA + x.ToString() + ",");
            b.ForEach(x => strB = strB + x.ToString() + ",");

            if (strA.Contains(strB))
                return true;
            else
                return false;
        }


        public static int MoreThanHalfNum(int[] numbers)
        {
            int length = numbers.Length;
            double halfLength = Math.Round(length / 2.0) +1;
            
            foreach(var e in numbers)
            {
                int cal = 0;
                for(int i=0; i< numbers.Length; i++)
                {
                    if (e == numbers[i])
                        cal = cal + 1;

                    if (cal >= halfLength)
                        return e;
                }
            }
          
            return 0; // write code here
        }

        // input an positive int array, output the minimum of the combination
        // for example:  [5,4,3,2,1]   output is 12345;
        //input [321, 12,123]    output is 12123321;
        public static string strCombination = string.Empty;
        public static string PrintMinNumber(int[] numbers)
        {
            string sum = string.Empty;
            MinNumber(numbers.ToList(), sum);
            return strCombination;
        }

        private static void MinNumber(List<int> lst, string sum)
        {
            if (lst.Count == 0)
            {
                if (string.IsNullOrEmpty(strCombination))
                    strCombination = sum;
                else if (string.Compare(strCombination, sum) == 1)
                    strCombination = sum;
            }
            else
            {
                foreach (var e in lst)
                {
                    string onePossible = sum + e.ToString();
                    List<int> newList = new List<int>(lst);
                    newList.Remove(e);
                    MinNumber(newList, onePossible);
                }
            }
        }

        //get N-th ugly number which only has 2,3,5 factors.
        // take 1 as the first ugly number, 6 25 are ugly nubmer  
        // while 14 is not ugly number as it has 7 factor
        public static int GetUglyNumber(int index)
        {
            if (index == 0) return 0;
            if (index == 1) return 1;

            int[] results = new int[index];
            int curIndex = 0;
            results[curIndex] = 1;

            int twoRet = 0, threeRet = 0, fiveRet = 0, nextNum = 0;
            while (curIndex + 1 != index)
            {
                for (int i = 0; i < results.Length; i++)
                {
                    if (results[i] * 2 > results[curIndex])
                    {
                        twoRet = results[i] * 2;
                        break;
                    }
                }

                for (int i = 0; i < results.Length; i++)
                {
                    if (results[i] * 3 > results[curIndex])
                    {
                        threeRet = results[i] * 3;
                        break;
                    }
                }

                for (int i = 0; i < results.Length; i++)
                {
                    if (results[i] * 5 > results[curIndex])
                    {
                        fiveRet = results[i] * 5;
                        break;
                    }
                }

                nextNum = Math.Min(twoRet, Math.Min(threeRet, fiveRet));
                curIndex++;
                results[curIndex] = nextNum;
            }

            return nextNum;
        }

        //input a string, length > 1 and length < 10000
        //return the first not repeadely char 
        public static int FirstNotRepeatingChar(string str)
        {
            int location = -1;
            char[] charTable = new char[52];
            for (int k = 0; k < charTable.Length; k++)
            {
                charTable[k] = '1';
            }

            for (int i = 0; i < str.Length; i++)
            {
                bool bStopThis = false;
                for (int k = 0; k < charTable.Length; k++)
                {
                    if (charTable[k] == str[i])
                    {
                        bStopThis = true;
                        break;
                    }
                    if (charTable[k] == '1')
                    { 
                        charTable[k] = str[i];
                        break;
                    }
                }

                if (bStopThis) continue;

                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[j] == str[i])
                        break;

                    if (j == str.Length - 1)
                    {
                        location = i;
                        return location;
                    }
                }

            }
            return location;
        }

        public static int InversePairs(int[] data)
        {
            int totalPairs = 0;
            for(int i=0; i < data.Length; i++)
            {
                for(int j= i+1; j< data.Length; j++)
                {
                    if (data[i] > data[j])
                        totalPairs = totalPairs + 1;
                }
            }
            return (totalPairs);
            //return (totalPairs % 1000000007);
        }
    }
}
