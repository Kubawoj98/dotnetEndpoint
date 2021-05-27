using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetEndpointApp.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(Person person)
        {
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
        }
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public Person()
        {

        }
        public string GetFirstName()
        {
            return this.FirstName;
        }
        public string GetLastName()
        {
            return this.LastName;
        }
        public void SetFirstName(string firstName)
        {
            this.FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            this.LastName = lastName;
        }
        public string GetUserData()
        {
            string test = GetFirstName() + " " + GetLastName();
            return test;
        }
    }

}