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
            try
            {
                throw new Exception();
            }
            catch(Exception e)
            {
                test += e;
            }
            
            return test;
        }

        [Route("error_snap")]
        public string err_snap()
        {
            string test = "";
            try
            {
                throw new Exception();
            }
            catch(Exception e)
            {
                test+=e;
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("error_snap");
            return test;
        }

        [Route("error_snap2")]
        public string err_snap2()
        {
            RevDeBugAPI.Snapshot.RecordSnapshot("error_snap");
            string test = "";
            try
            {
                throw new Exception();
            }
            catch(Exception e)
            {
                test += e;
            }
            
            return test;
        }

        [Route("err_array")]
        public string err_array()  
        {
            string test = "";
            char[] alfa = { 'd', 'f' };
            try
            {
                test += alfa[12];
            }
            catch(Exception e)
            {
                test += e;
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
                    try
                    {
                        throw new AggregateException();
                    }
                    catch(AggregateException e)
                    {
                        test += e;
                    }
                    
                }
            }
            return test;
        }

        [Route("err_array_snap")]
        public string err_array_snap()
        {
            string test = "";
            char[] alfa = { 'd', 'f' };
            try
            {
                Console.WriteLine(alfa[12]);
            }
            catch(Exception e)
            {
                test += e;
            }
            
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
                    try
                    {
                        throw new AggregateException();
                    }
                    catch(Exception e)
                    {
                        test += e;
                    }
                }
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("err_loop_for_1000_snap");
            return test;
        }
    }
}