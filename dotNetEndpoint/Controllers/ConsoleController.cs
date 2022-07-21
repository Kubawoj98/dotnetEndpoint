﻿using dotNetEndpointApp.Models;
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
            Utilities.RevDeBugCaller.RecordSnapshot("console_writeline");
            return test;
        }
        [Route("console_writeline_formatted")]
        public string ConsoleWriteLineFormatted()
        {
            string test = "Console Write Formatted";
            Console.WriteLine("Hello %s!%n", "World");
            Console.WriteLine("Home%nCar%nDog");
            Utilities.RevDeBugCaller.RecordSnapshot("console_writeline_formatted");
            return test;
        }
        [Route("max_string_length")]
        public string MaxStringLength()
        {
            string a1 = "000000000100000000010000000001000000000100000000010000000001000000000100000000010000000001000000000A000000000100000000010000000001000000000100000000010000000001000000000100000000010000000001000000000B000000000100000000010000000001000000000100000000010000000001000000000100000000010000000001000000000C";
            string test;
            test = "ccc" + a1;
            Console.WriteLine(test);
            Utilities.RevDeBugCaller.RecordSnapshot("max_string_length");
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
            Utilities.RevDeBugCaller.RecordSnapshot("single_quotes");
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
            Utilities.RevDeBugCaller.RecordSnapshot("double_quotes");
            return test;
        }
    }
}
