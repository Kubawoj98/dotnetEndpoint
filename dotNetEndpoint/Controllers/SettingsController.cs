using Microsoft.AspNetCore.Mvc;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class SettingsController : Controller
    {
        [Route("get_version")]
        public string Version()
        {
            using (System.IO.StreamReader r = new System.IO.StreamReader("dotNetEndpoint.deps.json"))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }
    }
}
