using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [Route("error")]
        public string err()
        {
            string test = "";
            throw new Exception();
            return test;
        }

        [Route("error_snap")]
        public string err_snap()
        {
            string test = "";
            throw new Exception();
            RevDeBugAPI.Snapshot.RecordSnapshot("error_snap");
            return test;
        }

        [Route("error_snap2")]
        public string err_snap2()
        {
            RevDeBugAPI.Snapshot.RecordSnapshot("error_snap");
            string test = "";
            throw new Exception();
            return test;
        }

        [Route("err_array")]
        public string err_array()
        {
            string test = "";
            char[] alfa = { 'd', 'f' };
            Console.WriteLine(alfa[12]);
            return test;
        }

        [Route("err_loop_inf")]
        public string err_loop()
        {
            string test = "";
            int i = 0;
            while (true)
            {
                Console.WriteLine(i);
                i++;
            }
            return test;
        }

        [Route("err_loop_for_1000")]
        public string err_loop_for_1000()
        {

            string test = "";
            for (int i = 0; i < 1000; i++)
            {
                if (i == 999)
                {
                    throw new AggregateException();
                }
            }
            return test;
        }

        [Route("err_array_snap")]
        public string err_array_snap()
        {
            string test = "";
            char[] alfa = { 'd', 'f' };
            Console.WriteLine(alfa[12]);
            RevDeBugAPI.Snapshot.RecordSnapshot("err_array_snap");
            return test;
        }

        [Route("err_loop_for_1000_snap")]
        public string err_loop_for_1000_snap()
        {
            string test = "";
            for (int i = 0; i < 1000; i++)
            {
                if (i == 999)
                {
                    throw new AggregateException();
                }
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("err_loop_for_1000_snap");
            return test;
        }
    }
}