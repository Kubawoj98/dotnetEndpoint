using dotNetEndpoint.Models;
using dotNetEndpointApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ConsoleController : Controller
    {
        [Route("console_writeline")]
        public string ConsoleWriteLine()
        {
            string test = "Console Write";
            Console.WriteLine(1);
            Console.WriteLine(true);
            Console.WriteLine('a');
            Console.WriteLine("HoMe");
            Person person = new Person("Steven","Tyler");
            Console.WriteLine(person);
            Console.WriteLine(2L);
            Console.WriteLine(1);
            Console.WriteLine(141414452412341);
            RevDeBugAPI.Snapshot.RecordSnapshot("console_writeline");
            return test;
        }
        [Route("console_writeline_formatted")]
        public string ConsoleWriteLineFormatted()
        {
            string test = "Console Write Formatted";
            Console.WriteLine("Hello %s!%n", "World");
            Console.WriteLine("Home%nCar%nDog");
            RevDeBugAPI.Snapshot.RecordSnapshot("console_writeline_formatted");
            return test;
        }
        [Route("max_string_length")]
        public string MaxStringLength()
        {
            string a1 = "000000000100000000010000000001000000000100000000010000000001000000000100000000010000000001000000000A000000000100000000010000000001000000000100000000010000000001000000000100000000010000000001000000000B000000000100000000010000000001000000000100000000010000000001000000000100000000010000000001000000000C";
            string test;
            test = "ccc" + a1;
            Console.WriteLine(test);
            RevDeBugAPI.Snapshot.RecordSnapshot("max_string_length");
            return test;
        }
        [Route("single_quotes")]
        public string SingleQuotes()
        {
            string a1 = "''";
            string a2 = "'";
            string a3 = "\'";
            string test;
            test = "justRegularString" + a1 + a2 + a3;
            Console.WriteLine(test);
            RevDeBugAPI.Snapshot.RecordSnapshot("single_quotes");
            return test;
        }
        [Route("double_quotes")]
        public string DoubleQuotes()
        {
            string a1 = "\"\"";
            string a2 = "\"";
            string test;
            test = "justRegularString" + a1 + a2;
            Console.WriteLine(test);
            RevDeBugAPI.Snapshot.RecordSnapshot("double_quotes");
            return test;
        }
        [Route("interpolated_string_handler")]
        public void InterpolatedStringHandler()
        {
            var logger = new Logger() { EnabledLevel = LogLevel.Warning };
            var time = DateTime.Now;

            logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. This is an error. It will be printed.");
            logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time}. This won't be printed.");
            logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");
            RevDeBugAPI.Snapshot.RecordSnapshot("interpolated_string_handler");
        }
        [Route("const_interpolated_string")]
        public string ConstInretpolatedString()
        {
            string test = "";
            test += InterpolatedStrings.scheme + " ";
            test += InterpolatedStrings.HomeUri + " ";
            test += InterpolatedStrings.LoginUri + " ";
            test += InterpolatedStrings.dev + " ";
            test += InterpolatedStrings.LoginUriDev + " ";
            test += InterpolatedStrings.HomeUriDev;
            RevDeBugAPI.Snapshot.RecordSnapshot("const_interpolated_string");
            return test;
        }
    }
}
