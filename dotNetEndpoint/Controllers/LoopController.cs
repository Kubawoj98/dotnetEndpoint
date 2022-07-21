using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class LoopController : Controller
    {
        [Route("single_for")]
        public string SingleFor()
        {
            string test = "";
            for (int i = 0; i < 10; i++)
            {
                test += "test ";
            }
            Utilities.RevDeBugCaller.RecordSnapshot("single_for");
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
            Utilities.RevDeBugCaller.RecordSnapshot("nested_for");

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
            Utilities.RevDeBugCaller.RecordSnapshot("single_while");

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
            Utilities.RevDeBugCaller.RecordSnapshot("nested_while");

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

            Utilities.RevDeBugCaller.RecordSnapshot("do_while");

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
            Utilities.RevDeBugCaller.RecordSnapshot("foreach");

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
            Utilities.RevDeBugCaller.RecordSnapshot("break");

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
            Utilities.RevDeBugCaller.RecordSnapshot("continue");

            return test;
        }
        [Route("recursion")]
        public string Recursion()
        {
            String test = "";
            int result = SumClass.Sum(5);
            test += result;
            Utilities.RevDeBugCaller.RecordSnapshot("recursion");

            return test;
        }
    }
}
