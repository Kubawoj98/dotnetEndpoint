using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    public class SortingAlgorithms
    {
        public static void QuickSortAlgorithm(int[] intArray, int low, int high)
        {
            if (low < high)
            {
                //partition the array around pi=>partitioning index and return pi
                int pi = Partition(intArray, low, high);

                // sort each partition recursively 
                QuickSortAlgorithm(intArray, low, pi - 1);
                QuickSortAlgorithm(intArray, pi + 1, high);
            }
            
        }
        public static int Partition(int[] intArray, int low, int high)
        {
            int pi = intArray[high];
            int i = (low - 1); // smaller element index
            for (int j = low; j < high; j++)
            {
                // check if current element is less than or equal to pi 
                if (intArray[j] <= pi)
                {
                    i++;
                    // swap intArray[i] and intArray[j] 
                    int temporary = intArray[i];
                    intArray[i] = intArray[j];
                    intArray[j] = temporary;
                }
            }

            // swap intArray[i+1] and intArray[high] (or pi) 
            int temp = intArray[i + 1];
            intArray[i + 1] = intArray[high];
            intArray[high] = temp;

            return i + 1;
        }
        public static void Merge(int[] left_arr, int[] right_arr, int[] arr, int left_size, int right_size)
        {

            int i = 0, l = 0, r = 0;
            //The while loops check the conditions for merging
            while (l < left_size && r < right_size)
            {

                if (left_arr[l] < right_arr[r])
                {
                    arr[i++] = left_arr[l++];
                }
                else
                {
                    arr[i++] = right_arr[r++];
                }
            }
            while (l < left_size)
            {
                arr[i++] = left_arr[l++];
            }
            while (r < right_size)
            {
                arr[i++] = right_arr[r++];
            }
        }
        public static void MergeSort(int[] arr, int len)
        {
            if (len < 2)
            {
                return;
            }

            int mid = len / 2;
            int[] left_arr = new int[mid];
            int[] right_arr = new int[len - mid];

            //Dividing array into two and copying into two separate arrays
            int k = 0;
            for (int i = 0; i < len; ++i)
            {
                if (i < mid)
                {
                    left_arr[i] = arr[i];
                }
                else
                {
                    right_arr[k] = arr[i];
                    k += + 1;
                }
            }
            // Recursively calling the function to divide the subarrays further
            MergeSort(left_arr, mid);
            MergeSort(right_arr, len - mid);
            // Calling the merge method on each subdivision
            Merge(left_arr, right_arr, arr, mid, len - mid);
        }
    }
}
