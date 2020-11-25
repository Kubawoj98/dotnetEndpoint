using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class InterfacesController : Controller
    {
        [Route("interface_implementation")]
        public string InterfaceImplementation()
        {
            string test = "";
            Shop sportShop = new Shop();
            test = sportShop.decoration("Holiday");
            RevDeBugAPI.Snapshot.RecordSnapshot("interface_implementation");
            return test;
        }
        [Route("interface_static_methods")]
        public string interfaceStaticMethods()
        {
            string test = "";
            test = IShop.getPrice("dybel") + " $";
            RevDeBugAPI.Snapshot.RecordSnapshot("interface_static_methods");
            return test;
        }
            [Route("interface_default_methods")]
            public string interfaceDefaultMethods()
            {
            String test = "";
            Shop shop = new Shop();
            test = shop.decoration("big yellow cash desk");
            test += shop.workers();
            RevDeBugAPI.Snapshot.RecordSnapshot("interface_default_methods");
            return test;
        }
        }
}
