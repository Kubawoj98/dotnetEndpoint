using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ArraysController : Controller
    {
        [Route("one_dimensional_array")]
        public string OneDimensionalArray()
        {
            string test = "";
            string[] cars = { "Volvo ", "BMW ", "Ford ", "Mazda " };
            int[] myNum = { 2, 4, 5, 4 };

            for (int i = 0; i < myNum[1]; i++)
            {
                test += cars[i];
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("one_dimensional_array");
            return test;
        }

        [Route("one_dimensional_array_bounds_exception")]
        public string OneDimensionalArrayBoundsException()
        {
            string test = "";
            try
            {
                string[] cars = { "Volvo ", "BMW ", "Ford ", "Mazda " };
                int[] myNum = { 2, 4, 5, 4 };

                for (int i = 0; i < 100; i++)
                {
                    test += cars[i];
                }
            }
            catch (Exception e)
            {
                RevDeBugAPI.Snapshot.RecordException(e);
                test += e;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("one_dimensional_array_bounds_exception");
            return test;

        }
        [Route("one_dimensional_array_reference")]
        public string OneDimensionalArrayReference()
        {
            string test = "";
            string[] cars = { "Volvo ", "BMW ", "Ford ", "Mazda " };
            string[] carsCopyReference = cars;
            carsCopyReference[0] = "Fiat 126p";
            test = cars[0];
            RevDeBugAPI.Snapshot.RecordSnapshot("one_dimensional_array_reference");
            return test;
        }
        [Route("one_dimensional_copy_array")]
        public string OneDimensionalArrayCopy()
        {
            string test = "";
            string[] cars = { "Volvo ", "BMW ", "Ford ", "Mazda " };
            string[] carsCopy = new string[cars.Length];
            cars.CopyTo(carsCopy, 0);
            foreach (var item in carsCopy)
            {
                test += " " + item;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("one_dimensional_copy_array");
            return test;
        }
        [Route("one_dimensional_array_sort")]
        public string OneDimensionalArraySort()
        {
            String test = "";
            int[] number = { 32, 33, 45, 1, 4 };
            Array.Sort(number);
            foreach (var item in number)
            {
                test += " " + item;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("one_dimensional_array_sort");
            return test;
        }
        [Route("multidimensional_array")]
        public string MultiDimensionalArray()
        {
            String test = "";
            int[,] number = new int[3, 4] {
                {0,1,2,3 },
                 {4,5,6,6 },
                 {8,9,10,11 }
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                   test+= string.Format("a[{0}, {1}] = {2}", i, j, number[i, j]);
                }
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("multidimensional_array");
            return test;
        }
        [Route("arrays_filtered")]
        public string ArraysFiltered()
        {
            string test = "Original Array: ";
            int[] arr = { 40, 42, 12, 83, 75, 40, 95 };
            foreach (int a in arr)
            {
                test += a + ", ";
            }
            test += "\n Filtered array: ";
            IEnumerable<int> myQuery = arr.AsQueryable().Where((a, index) => a >= 50);
            foreach (int res in myQuery)
            {
                test += res + ", ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("arrays_filtered");
            return test;
        }
        [Route("jagged_array")]
        public string JaggedArray()
        {
            string test = "First Array: ";
            int[][] scores = new int[2][] { new int[] { 71, 72, 73 }, new int[] { 32, 33, 34, 35 } };
            // Wypisanie wszystkich elementów w konsoli
            for (int i = 0; i < scores[0].Length; i++)
            {
                test += scores[0][i] +" ";
            }
            test += "\nSecond Array: ";
            for (int i = 0; i < scores[1].Length; i++)
            {
                test += scores[1][i] + " ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("jagged_array");
            return test;
        }
        [Route("array_as_parameter")]
        public string ArrayAsParameter()
        {
            string test = "";
                int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            test = sum(numbers)+"";
            RevDeBugAPI.Snapshot.RecordSnapshot("jagged_array");
            return test;
        }
        public double sum(int[] arrayOfNumbers)
        {
            double result = 0;
            foreach (var item in arrayOfNumbers)
            {
                result += item;
            }

            return result;
        }
    }
}
