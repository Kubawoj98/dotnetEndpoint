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
            try
            {
                string test = "";
                int a = 0, b = 3, c;
                c = b / a;
                string[] cars = { "Volvo ", "BMW ", "Ford ", "Mazda " };
                int[] myNum = { 2, 4, 5, 4 };

                for (int i = 0; i < myNum[1]; i++)
                {
                    test += cars[i];
                }
                //return test;
            }
            catch(Exception e)
            {
                RevDeBugAPI.Snapshot.RecordException(e);
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("one_dimensional_array_bounds_exception");
            return " ";

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
            int[] number = { 32, 33, 45, 1, 4 };
            Array.Sort(number);
            foreach (var item in number)
            {
                test += " " + item;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("multidimensional_array");
            return test;
        }

    }
}
