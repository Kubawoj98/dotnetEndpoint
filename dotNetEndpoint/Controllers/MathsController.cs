using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class MathsController : Controller 
    {
        [Route("max")]
        public string Max()
        {
            string test = "";
             test+= Math.Max(10, 150);
            RevDeBugAPI.Snapshot.RecordSnapshot("max");
            return test;
        }
        [Route("min")]
        public string Min()
        {
            string test = "";
            test += Math.Min(10, 150);
            RevDeBugAPI.Snapshot.RecordSnapshot("min");
            return test;
        }
        [Route("sqrt")]
        public string Sqrt()
        {
            string test = "";
            test += Math.Sqrt(9);
            RevDeBugAPI.Snapshot.RecordSnapshot("sqrt");
            return test;
        }
        [Route("abs")]
        public string abs()
        {
            string test = "";
            test += Math.Abs(-142.24);
            RevDeBugAPI.Snapshot.RecordSnapshot("abs");
            return test;
        }
        [Route("round")]
        public string Round()
        {
            string test = "";
            test += Math.Round(-142.24);
            RevDeBugAPI.Snapshot.RecordSnapshot("round");
            return test;
        }
        [Route("asin_nan")]
        public string AsinNan()
        {
            string test = "";
            test += Math.Asin(2.45);
            RevDeBugAPI.Snapshot.RecordSnapshot("asin_nan");
            return test;
        }
        [Route("asin")]
        public string Asin()
        {
            string test = "";
            test += Math.Asin(0.45);
            RevDeBugAPI.Snapshot.RecordSnapshot("asin");
            return test;
        }
        [Route("log")]
        public string Log()
        {
            string test = "";
            test += Math.Log(10);
            RevDeBugAPI.Snapshot.RecordSnapshot("log");
            return test;
        }
    }
}
