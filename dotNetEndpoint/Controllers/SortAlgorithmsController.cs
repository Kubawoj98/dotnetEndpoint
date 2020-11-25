using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class SortAlgorithmsController : Controller 
    {
        [Route("quick_sort")]
        public string QuickSort()
        {
            string arrayValue = "Original Array: ";
            //initialize a numeric array, intArray
            int[] intArray= { 4, -1, 5, -3 };
            int n = intArray.Length;
            for(int i=0;i<n;i++)
            {
                arrayValue += intArray[i] + ", ";
            }
            //call quick_sort routine using QuickSort object+ 
            arrayValue += "\n" +"Sorted Array";
            SortingAlgorithms.QuickSortAlgorithm(intArray, 0, n - 1);
            for (int i = 0; i < n; i++)
            {
                arrayValue += intArray[i] +", ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("quick_sort");
            return arrayValue;
        }
        [Route("bubble_sort")]
        public string BubbleSort()
        {
            String arrayValue = "Original array: ";
            int[] numbers = { 14, 8, 5, 1, 5678 };
            for (int i = 0; i < numbers.Length; i++)
            {
                arrayValue += numbers[i] + " ";
            }
            arrayValue += "\n";
            int tempVar;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        tempVar = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = tempVar;
                    }
                }
            }
            arrayValue += "Sorted array: ";
            for (int i = 0; i < numbers.Length; i++)
            {
                arrayValue += numbers[i] + " ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("quick_sort");
            return arrayValue;
        }
        [Route("merge_sort")]
        public string MergeSort()
        {
            int[] array = { 12, 1, 10, 50, 5, 15, 45 };
            String arrayValue = "Unsorted array: ";
            for (int i = 0; i < array.Length; i++)
            {
                arrayValue += array[i] + " ";
            }
            arrayValue += "\n Sorted array: ";
            SortingAlgorithms.MergeSort(array, array.Length);
            for (int i = 0; i < array.Length; ++i)
            {
                arrayValue += array[i] + " ";
            };
            RevDeBugAPI.Snapshot.RecordSnapshot("merge_sort");
            return arrayValue;
        }
    }
}
