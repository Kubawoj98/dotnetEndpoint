using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetEndpointApp.Models
{
    public class OuterClass
    {
        public int x = 10;
        public class InnerClass
        {
            public int y = 5;
        }
    }
}