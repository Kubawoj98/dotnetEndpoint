using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetEndpointApp.Models
{
    public class Employee : Person
    {
        private double salary;
        private double bonus;
        public void SetSalary(double salary)
        {
            this.salary = salary;
        }
        public void SetBonus(double bonus)
        {
            this.bonus = bonus;
        }
        public double GetSalary()
        {
            return this.salary;
        }
        public double GetBonus()
        {
            return this.bonus;
        }
    }
}