using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    interface IShop
    {
        public string decoration(string furniture)
        {
            return furniture;
        }
        public static string workers()
        {
            return " default employees";
        }
        public static string getPrice(String productName)
        {
            string price = productName.Length * 10 + "";
            return price;
        }
    }
}
