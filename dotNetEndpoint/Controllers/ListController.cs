using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ListController : Controller
    {
        [Route("list_size")]
        public string ListSize()
        {
            string test = "";
            List<string> list = new List<string>();
            list.Add("init");
            for (int i = 0; i < 5; i++)
            {
                list.Add(" Number" + i);
            }
            test = list.Count().ToString();
            RevDeBugAPI.Snapshot.RecordSnapshot("list_size");
            return test;
        }
        [Route("add_element")]
        public string AddElement()
        {
            string test = "";
            List<string> list = new List<string>();
            list.Add("Leonardo");
            list.Add("Donatello");
            list.Add("Michelangelo");
            list.Add("Raphael");
            test = list[list.Count - 1];

            RevDeBugAPI.Snapshot.RecordSnapshot("add_element");
            return test;
        }
        [Route("remove_element")]
        public string RemoveElement()
        {
            string test = "";
            List<string> list = new List<string>();
            list.Add("Leonardo");
            list.Add("Donatello");
            list.Add("Michelangelo");
            list.Add("Raphael");
            list.Remove("Donatello");
            test = list[1];

            RevDeBugAPI.Snapshot.RecordSnapshot("remove_element");
            return test;
        }
    }
}
