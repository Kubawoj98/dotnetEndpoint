using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetEndpointApp.Models
{
    public abstract class Animal
    {
        public abstract void AnimalSound();
        public void Sleep()
        {
            Console.WriteLine("Zzz");
        }
    }
}