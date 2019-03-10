using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
   public class RecurFun
   {
       //Feibolaqi array
       public int FibNum(int n)
       {
           if (n < 1)
               return -1;
           if (1 == n || 2 == n)
               return 1;

           return FibNum(n - 1) + FibNum(n - 2);
        }

        //Feibolaqi array 2
        public int FibNum2(int n, int x, int y)
        {
            if (1 == n)
            {
                return y;
            }
            else
            {
                return FibNum2(n - 1, y, x + y);
            }
        }

        // n!
        public int Fact(int n)
       {
           if (n == 0)
               return 1;
           else
           {
               return (n * Fact(n - 1));
           }
       }

      public int Ackermann(int x, int y)
       {
           // Base or Termination Condition
           if (0 == x)
           {
               return y + 1;
           }
           // Error Handling condition
           if (x < 0 || y < 0)
           {
               return -1;
           }
           // Recursive call by Linear method 
           else if (x > 0 && 0 == y)
           {
               return Ackermann(x - 1, 1);
           }
           // Recursive call by Nested method
           else
           {
                int midVal = Ackermann(x, y-1);
                //return midVal;
                return Ackermann(x-1, midVal);
              // return Ackermann(x - 1, Ackermann(x, y - 1));
           }
       }
   }
}
