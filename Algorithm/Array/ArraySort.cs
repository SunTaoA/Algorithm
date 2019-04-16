using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class ArraySort
    {
        //Selection
        public int[] SelectSort(int [] arr)
        {
            for(int i=0; i < arr.Length; i++)
                for(int j= i+1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }

            return arr;
        }

        //Bubble sort
        public int[] BubbleSort(int [] arr)
        {
            for(int i=0; i < arr.Length; i++)
                for( int j = 0; j < arr.Length - i-1; j++ )
                {
                    if (arr[j] < arr[j+1])
                    {
                        int tmp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = tmp;
                    }
                }
            return arr;
        }


        //Quick sort
        public int[] QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int index = Partition(arr, low, high);

                QuickSort(arr, low, index - 1);
                QuickSort(arr, index + 1, high);
            }

            return arr;
        }

        public int Partition(int[] arr, int low, int high)
        {
            int j = low - 1;
            for (int i = low; i < high; i++)
            {
                if (arr[i] < arr[high])
                {
                    j++;
                    if (i != j)
                    {
                        Swap(arr, j, i);
                    }
                }
            }

            Swap(arr, j + 1, high);
            return j + 1;
        }

        private void Swap(int[] arr, int small, int big)
        {
            int tmp = arr[big];
            arr[big] = arr[small];
            arr[small] = tmp;
        }

        //Merge sort
        //input array is random numbers
        //first seperate the array in middle till to 1-1 (recursive)
        //then merge two sorted array into one till into one sorted array as returned.
        public int[] MergeSort(int[] aryInput)
        {
            int[] aryRet = new int[aryInput.Length];

            int left = 0;
            int end = aryInput.Length - 1;
           
            sort(aryInput, left, end, aryRet);

            return aryRet;
        }

        private void sort(int[] aryInput, int left, int end, int[] aryRet)
        {
            if(left < end)
            { 
              int middle = (left + end) / 2;

              sort(aryInput, left, middle, aryRet);
              sort(aryInput, middle + 1, end, aryRet);
              merge(aryInput,left, middle, end, aryRet);
            }
        }

        private void merge(int[] firstAry, int left, int middle, int end, int[]secAry)
        {
            
            int i=left, k=middle+1;
            int start = left;

            while (i <= middle && k <= end)
            {
                    if (firstAry[i] > firstAry[k])
                    {
                        secAry[start++] = firstAry[k++];
                    }
                    else
                        secAry[start++] = firstAry[i++];
            }

            if (i <= middle)
            {
                for (int m = i; m <= middle; m++)
                    secAry[start++] = firstAry[m];
            }
            
            if (k <= end)
            {
                for (int m = k; m <= end; m++)
                    secAry[start++] = firstAry[m];
            }

            Array.Copy(secAry, left, firstAry, left, end - left + 1);
        }
    }
}
