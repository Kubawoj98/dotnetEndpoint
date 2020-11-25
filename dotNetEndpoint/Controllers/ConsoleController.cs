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
    }
}
