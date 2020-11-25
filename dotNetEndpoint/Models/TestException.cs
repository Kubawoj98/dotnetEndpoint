using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    public class TestException : Exception
    {
        public TestException()
        {

        }
        public TestException(string message) : base(message +"Test Exception has been throwed")
        {
            
        }
    }
}
