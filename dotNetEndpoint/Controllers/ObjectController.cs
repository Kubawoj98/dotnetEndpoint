using dotNetEndpointApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ObjectController : Controller
    {
        List<Person> people = new List<Person>();
        public ObjectController()
        {
            people.Add(new Person { FirstName = "Mike", LastName = "Tyson" });
            people.Add(new Person { FirstName = "Conor", LastName = "McGregor" });
        }
        Person person = new Person { FirstName = "John", LastName = "Doe" };
        [Route("object_definition")]
        public string Get()
        {
            Utilities.RevDeBugCaller.RecordSnapshot("object_definition");
            return person.FirstName + " "+ person.LastName;
            
        }
        [Route("copy_constructor")]
        public string GetCopyConstructor()
        {
            person = new Person(people[1]);
            Utilities.RevDeBugCaller.RecordSnapshot("copy_constructor");
            return person.FirstName + " " + person.LastName;
        }
        [Route("copy_constructor_set_value")]
        public string GetCopyConstructorSetValue()
        {
            person = new Person(people[1]);
            person.SetFirstName("Harry");
            person.SetLastName("Potter");
            Utilities.RevDeBugCaller.RecordSnapshot("copy_constructor_set_value");
            return person.FirstName + " " + person.LastName;
        }
        [Route("inheritance")]
        public string GetInheritance()
        {
            Employee manager = new Employee();
            manager.SetFirstName("James");
            manager.SetLastName("Smith");
            manager.SetSalary(4000);
            manager.SetBonus(1000);
            Utilities.RevDeBugCaller.RecordSnapshot("inheritance");
            return manager.FirstName + " " + manager.LastName + " " + manager.GetSalary() + " " + manager.GetBonus();
        }
        [Route("multi_level_inheritance")]
        public string GetMultiLevelInheritance()
        {
            President president = new President();
            president.SetFirstName("Rocky");
            president.SetLastName("Marciano");
            president.SetSalary(10000);
            president.SetBonus(2000);
            president.SetAmountOfBranches(17);
            Utilities.RevDeBugCaller.RecordSnapshot("multi_level_inheritance");
            return president.FirstName + " " + president.LastName + " Salary:" + president.GetSalary() + " Bonus:" + president.GetBonus() + " " + president.GetAmountOfBranches() + " branches";
        }
        [Route("inner_class")]
        public string GetInnerClass()
        {
            string test = " ";
            OuterClass myOuter = new OuterClass();
            OuterClass.InnerClass myInner = new OuterClass.InnerClass();
            test = "" + myOuter.ToString();
            Utilities.RevDeBugCaller.RecordSnapshot("inner_class");
            return test;
        }

        [Route("abstract_class")]
        public string GetAbstractClass()
        {
            string test = "Pig says: wee";
            Pig myPig = new Pig();
            myPig.AnimalSound();
            myPig.Sleep();
            Utilities.RevDeBugCaller.RecordSnapshot("abstract_class");
            return test;
        }
        [Route("check_objects_to_string")]
        public string CheckObjectToString()
        {
            person = new Person(people[1]);
            string test = person.ToString();

            Utilities.RevDeBugCaller.RecordSnapshot("check_objects_to_string");
            return test;
        }
        [Route("methods_inside_method")]
        public string methodsInsideMethod()
        {
            string test = "";
            Person person = new Person("Tyson", "Fury");
            test += person.GetUserData();

            Utilities.RevDeBugCaller.RecordSnapshot("methods_inside_method");
            return test;
        }
    }
}
