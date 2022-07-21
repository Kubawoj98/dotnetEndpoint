using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class MathController : Controller 
    {
        [Route("max")]
        public string Max()
        {
            string test = "";
             test+= Math.Max(10, 150);
            Utilities.RevDeBugCaller.RecordSnapshot("max");
            return test;
        }
        [Route("min")]
        public string Min()
        {
            string test = "";
            test += Math.Min(10, 150);
            Utilities.RevDeBugCaller.RecordSnapshot("min");
            return test;
        }
        [Route("sqrt")]
        public string Sqrt()
        {
            string test = "";
            test += Math.Sqrt(9);
            Utilities.RevDeBugCaller.RecordSnapshot("sqrt");
            return test;
        }
        [Route("abs")]
        public string Abs()
        {
            string test = "";
            test += Math.Abs(-142.24);
            Utilities.RevDeBugCaller.RecordSnapshot("abs");
            return test;
        }
        [Route("round")]
        public string Round()
        {
            string test = "";
            test += Math.Round(-142.24);
            Utilities.RevDeBugCaller.RecordSnapshot("round");
            return test;
        }
        [Route("asin_nan")]
        public string AsinNan()
        {
            string test = "";
            test += Math.Asin(2.45);
            Utilities.RevDeBugCaller.RecordSnapshot("asin_nan");
            return test;
        }
        [Route("asin")]
        public string Asin()
        {
            string test = "";
            test += Math.Asin(0.45);
            Utilities.RevDeBugCaller.RecordSnapshot("asin");
            return test;
        }
        [Route("log")]
        public string Log()
        {
            string test = "";
            test += Math.Log(10);
            Utilities.RevDeBugCaller.RecordSnapshot("log");
            return test;
        }
        [Route("sin")]
        public string Sin()
        {
            string test = "";
            test += Math.Sin(10);
            Utilities.RevDeBugCaller.RecordSnapshot("sin");
            return test;
        }
        [Route("cos")]
        public string Cos()
        {
            string test = "";
            test += Math.Cos(10);
            Utilities.RevDeBugCaller.RecordSnapshot("cos");
            return test;
        }
        [Route("tan")]
        public string Tan()
        {
            string test = "";
            test += Math.Tan(10);
            Utilities.RevDeBugCaller.RecordSnapshot("tan");
            return test;
        }
        [Route("ceiling")]
        public string Ceiling()
        {
            string test = "";
            test += Math.Ceiling(10.42113);
            Utilities.RevDeBugCaller.RecordSnapshot("ceiling");
            return test;
        }
        [Route("exp")]
        public string Exp()
        {
            string test = "";
            test += Math.Exp(12);
            Utilities.RevDeBugCaller.RecordSnapshot("exp");
            return test;
        }
        [Route("pow")]
        public string Pow()
        {
            string test = "";
            test += Math.Pow(12,12);
            Utilities.RevDeBugCaller.RecordSnapshot("pow");
            return test;
        }
        [Route("copy_sign")]
        public string copySign()
        {
            string test = "";
            test += Math.CopySign(12, -4);
            Utilities.RevDeBugCaller.RecordSnapshot("copy_sign");
            return test;
        }
        [Route("exp_to_string")]
        public string ExpToString()
        {
            string test = "";
            test += Math.Exp(12).ToString();
            Utilities.RevDeBugCaller.RecordSnapshot("exp_to_string");
            return test;
        }

    }
}
