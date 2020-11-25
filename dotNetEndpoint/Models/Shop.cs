using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Models
{
    public class Shop : IShop
    {
        public string workers()
        {
            return "12 default employees";
        }
        public string decoration(String furniture)
        {
            return "Shop with: " + furniture;
        }
        public String getType()
        {
            return "Sport shop";
        }
        public string ShopType;
        public Shop()
        {
            ShopType = type("sport");
        }
        public string type(string type)
        {
            return type + " shop";
        }

    }
}
