using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    internal class InterpolatedStrings
    {
        public const string scheme = "https";
        public const string HomeUri = "home";
        public const string LoginUri = "login:";

        public const string dev = $"{scheme}://localhost:5001";

        public const string LoginUriDev = $"{dev}/{LoginUri}";
        public const string HomeUriDev = $"{dev}/myaccount/{HomeUri}";

    }
}
