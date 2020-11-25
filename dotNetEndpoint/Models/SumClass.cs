using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    public class SumClass
    {
        public static int Sum(int k)
        {
            if (k > 0)
            {
                return k + Sum(k - 1);
            }
            else
            {
                return 0;
            }
        }
    }
}
