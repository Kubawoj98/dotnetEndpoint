using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetEndpointApp.Models
{
    public class President : Employee
    {
        private int amountOfBranches;
        public void SetAmountOfBranches(int amount)
        {
            this.amountOfBranches = amount;
        }
        public int GetAmountOfBranches()
        {
            return this.amountOfBranches;
        }
    }
}