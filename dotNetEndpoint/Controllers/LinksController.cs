using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class LinksController : Controller
    {
        // for accessing conventional routes...
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public LinksController(
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public IActionResult Index()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ActionDescriptor ad in _actionDescriptorCollectionProvider.ActionDescriptors.Items)
            {
                var action = Url.Action(new UrlActionContext()
                {
                    Action = ad.RouteValues["action"],
                    Controller = ad.RouteValues["controller"],
                    Values = ad.RouteValues
                });

                sb.Append(Environment.GetEnvironmentVariable("REVDEBUG_dotNetEndpoint")).Append(action).AppendLine().AppendLine();
                
            }

            return Ok(sb.ToString());
        }
        [Route("env")]
        public string GetEnv()

        { string test= Environment.GetEnvironmentVariable("REVDEBUG_dotNetEndpoint");

            return test;
        }
    }
}