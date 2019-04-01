using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class Amazon
    {
        /// <summary>
        /// Output the first N closet delivery destination  (2019 Singapore site)
        /// </summary>
        int[,] arr1 = new int[,] { { 1, 1 }, { 1, -3 }, { 1, 2 }, { 3, 4 }, { 0, 0 }, { 9, 9 }, { 10, 10 }, { 11, 11 } };
        
        public List<List<int>> ClosestXdestinations(int numDestinations,
                                            int[,] allLocations,
                                            int numDeliveries)
        {

            double[,] numDistance = new double[numDestinations, 2];
            for (int i = 0; i <= allLocations.GetUpperBound(0); i++)
            {
                numDistance[i, 0] = i;
                numDistance[i, 1] = Math.Sqrt(Math.Pow(Math.Abs(allLocations[i, 0]), 2) + Math.Pow(Math.Abs(allLocations[i, 1]), 2));
            }

            // Selection Sort
            int totalComparison = numDeliveries;
            for (int j = 0; j <= totalComparison; j++)
                for (int k = j + 1; k <= numDistance.GetUpperBound(0); k++)
                {
                  if (numDistance[j, 1] > numDistance[k, 1])
                      {
                        double x = numDistance[j,0];
                        double y = numDistance[j, 1];
                        numDistance[j, 0] = numDistance[k,0];
                        numDistance[j, 1] = numDistance[k, 1];
                        numDistance[k, 0] = x;
                        numDistance[k, 1] = y;
                      }
                }

            List<List<int>> retList = new List<List<int>>();
            for (int i = 0; i < numDeliveries; i++)
            {

                retList.Add(new List<int>() { allLocations[Convert.ToInt32(numDistance[i, 0]), 0], allLocations[(int)numDistance[i, 0], 1] });
            }
            return retList;
        }

        private List<List<int>> SortArray()
            {
                List<List<int>> total = new List<List<int>>();

                List<int> a = new List<int>() {1, 2};
                total.Add(a);

                List<int> b = new List<int>() { 5, 4 };
                total.Add(b);

                List<int> c = new List<int>() { -1,-2};
                total.Add(c);

                foreach(List<int> e in total)
                {
                    e.Add(e.Sum());
                }

                total.Sort((x, y) => { return (x[2].CompareTo(y[2])); });

            return total;
            }

        private int[,] Swap2D()
        {
            int[,] arr = new int[,] { { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 } };

            var x = arr[0,0];
            var y = arr[0, 1];
            arr[0, 0] = arr[1, 0];
            arr[0, 1] = arr[1, 1];
            arr[1, 0] = x;
            arr[1, 1] = y;
            return arr;
        }

    }
    
}
