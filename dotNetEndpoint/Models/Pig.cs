using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetEndpointApp.Models
{
    public class Pig : Animal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }
    }
}