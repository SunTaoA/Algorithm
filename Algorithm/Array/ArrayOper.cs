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
    }
}
