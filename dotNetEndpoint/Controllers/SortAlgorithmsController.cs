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
        public string quickSort()
        {
            string arrayValue = "Original Array: ";
            //initialize a numeric array, intArray
            SortingAlgorithms sortingAlgorithms = new SortingAlgorithms();
            int[] intArray= { 4, -1, 5, -3 };
            int n = intArray.Length;
            for(int i=0;i<n;i++)
            {
                arrayValue += intArray[i] + ", ";
            }
            //call quick_sort routine using QuickSort object+ 
            arrayValue += "\n" +"Sorted Array";
            SortingAlgorithms.quickSortAlgorithm(intArray, 0, n - 1);
            for (int i = 0; i < n; i++)
            {
                arrayValue += intArray[i] +", ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("quick_sort");
            return arrayValue;
        }

    }
}
