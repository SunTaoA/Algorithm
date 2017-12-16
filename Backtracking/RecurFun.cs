using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backtracking
{
   public class RecurFun
   {
       //binary 
      public int FibNum(int n)
       {
           if (n < 1)
               return -1;
           if (1 == n || 2 == n)
               return 1;

           //Console.WriteLine("FibNum(" + (n-1) + "), FibNum("+ (n-2) + ")");
           // think this as
           // int addVal = FibNum( n - 1);
           // addVal += FibNum(n - 2);
           // return addVal;
           var x = FibNum(n - 1);
           var y = FibNum(n - 2);
           Console.WriteLine("FibNum(" + (n - 1) + ")=" + x + "  FibNum(" + (n - 2) + ")=" + y);  
          return (x + y);
          //return FibNum(n - 1) + FibNum(n - 2);
       }

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


     
   }
}
