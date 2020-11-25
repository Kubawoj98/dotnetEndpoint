using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class LoopsController : Controller
    {
        [Route("single_for")]
        public string SingleFor()
        {
            string test = "";
            for (int i = 0; i < 10; i++)
            {
                test += "test ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("single_for");
            return test;
        }
        [Route("nested_for")]
        public string NestedFor()
        {
            string test = "";
            for (int i = 0; i < 3; i++)
            {
                test += "firstLoop ";
                for (int j = 0; j < 3; j++)
                {
                    test += "secondLoop ";
                }
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("nested_for");

            return test;
        }
        [Route("single_while")]
        public string SingleWhile()
        {
            string test = "";
            int i = 0;
            while (i < 10)
            {
                test = test + "TEST" + i + " ";
                i++;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("single_while");

            return test;
        }
        [Route("nested_while")]
        public string NestedWhile()
        {
            String test = "";
            int i = 0;
            while (i < 3)
            {
                int j = 0;
                while (j < 3)
                {
                    test = test + "test" + i + j + " ";
                    j++;
                }
                i++;
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("nested_while");

            return test;
        }
        [Route("do_while")]
        public string DoWhile()
        {
            String test = "";
            int i = 0;
            do
            {
                test += "test";
                i++;
            } while (i < 10);

            RevDeBugAPI.Snapshot.RecordSnapshot("do_while");

            return test;
        }
        [Route("foreach")]
        public string Foreach()
        {
            String[] test = { "ONE", "TWO", "THREE", "FOUR", "FIVE" };
            String lower = "";
            for (int i=0;i<test.Length;i++)
            {
                lower = test[i].ToLower();
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("foreach");

            return lower;
        }
        [Route("break")]
        public string BreakEndpoint()
        {
            string test = "";
            for (int i = 0; i < 10; i++)
            {
                if (i == 4)
                {
                    break;
                }
                test += i + " ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("break");

            return test;
        }
        [Route("continue")]
        public string ContinueEndpoint()
        {
            string test = "";
            for (int i = 0; i < 10; i++)
            {
                if (i == 4)
                {
                    continue;
                }
                test += i + " ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("continue");

            return test;
        }
        [Route("recursion")]
        public string Recursion()
        {
            String test = "";
            int result = SumClass.Sum(5);
            test += result;
            RevDeBugAPI.Snapshot.RecordSnapshot("recursion");

            return test;
        }
    }
}
