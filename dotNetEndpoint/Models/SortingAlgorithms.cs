using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    public class SortingAlgorithms
    {
        public static void quickSortAlgorithm(int []intArray,int low, int high)
        {
            
        }
        public int partition(int[] intArray, int low, int high)
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
    }
}
