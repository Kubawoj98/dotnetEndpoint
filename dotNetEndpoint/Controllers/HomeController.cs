using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotNetEndpoint.Controllers
{
    public class HomeController : Controller
    {
public int Data(int id)
        {
            return id + 100;
        }
    }
}
