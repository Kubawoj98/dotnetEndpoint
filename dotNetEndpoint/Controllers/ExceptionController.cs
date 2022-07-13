using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ExceptionController : Controller
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

         [Route("string_index_out_of_bound")]
        public string StringIndexOutOfBound()
        {
            string test = " ";
            try
            {
                String a = "Payday2"; // length is 7
                char c = a[9]; // accessing 9 th element
                Console.WriteLine(c);
            }
            catch
            {
                test = "You ask for string out of bound";
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("string_index_out_of_bound");
            return test;
        }

        [Route("number_format")]
        public string numberFormat()
        {
            string test = " ";
            try
            {
                // "Kebab" is not a number
                int num = Int32.Parse("Kebab");

                Console.WriteLine(num);
            }
            catch
            {
                test = "Number format exception";
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("number_format");
            return test;
        }

        [Route("array_index_out_of_bound")]
        public string arrayIndexOutOfBound()
        {
            string test = " ";
            try
            {
                // "Kebab" is not a number
                int num = Int32.Parse("Kebab");

                Console.WriteLine(num);
            }
            catch
            {
                test = "You asked for  out of bound array index who";
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("array_index_out_of_bound");
            return test;
        }

        [Route("try_catch_finally")]
        public string tryCatchFinally()
        {
            string test = " ";
            try
            {
                // "Kebab" is not a number
                int num = Int32.Parse("Kebab");

                Console.WriteLine(num);
            }
            catch
            {
                test = "Info from catch -> You asked for out of bound array index who";
            }
            finally
            {
                test = "Info from finally -> You asked for out of bound array index who";
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("try_catch_finally");
            return test;
        }

        [Route("try_in_try")]
        public string tryInTry()
        {
            string test = " ";
            int zero = 0;
            try
            {
                try
                {
                    zero = 100 / zero;
                }
                catch
                {
                    test = "Inner catch -> You can't divide by zero! ";
                }
            }
            catch
            {
                test = "Outer catch -> You can't divide by zero! ";
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("try_in_try");
            return test;
        }

        [Route("try_catch_if")]
        public string tryCatchIf()
        {
            string test = " ";
            int zero = 0;
            bool passed = true;
            try
            {
                zero = 100 / zero;
            }
            catch
            {
                passed = false;
            }
            if (passed==false)
            {
                test = "Info from if -> You can't divide by zero! ";
            }

            RevDeBugAPI.Snapshot.RecordSnapshot("try_catch_if");
            return test;
        }
    }
}
