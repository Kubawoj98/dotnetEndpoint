using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ExceptionsController : Controller
    {
        [Route("try_catch")]
        public string TryCatch()
        {
            string test = " ";
            int zero = 0;
            try
            {
                zero = 100 / zero;
            }
            catch(ArithmeticException e)
            {
                test = "You can't divide by zero! ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("try_catch");
            return test;
        }
        [Route("try_catch_appropriate_exception")]
        public string TryCatchAppropriateException()
        {
            string test = " ";
            int zero = 0;
            try
            {
                zero = 100 / zero;
            }
            catch (NullReferenceException e)
            {
                test = "Null reference ";
            }
            catch (ArithmeticException e)
            {
                test = "You can't divide by zero! ";
            }
            RevDeBugAPI.Snapshot.RecordSnapshot("try_catch_appropriate_exception");
            return test;
        }
        [Route("new_exception_class")]
        public string newExceptionsClass()
        {
            string test = " ";
            int zero = 0;
            try
            {
                throw new TestException("Error: ");
            }
            catch(TestException e)
            {
                test += e.Message;
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("new_exception_class");
            return test;
        }
    }
}
