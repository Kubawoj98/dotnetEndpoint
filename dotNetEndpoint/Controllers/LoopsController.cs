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
                    test = test + "secondLoop ";
                }
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("nested_for");

            return test;
        }

    }
}
