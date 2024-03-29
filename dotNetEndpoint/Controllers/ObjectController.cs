﻿using dotNetEndpoint.Models;
using dotNetEndpointApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace dotNetEndpoint.Controllers;

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
        RevDeBugAPI.Snapshot.RecordSnapshot("object_definition");
        return person.FirstName + " " + person.LastName;

    }
    [Route("copy_constructor")]
    public string GetCopyConstructor()
    {
        person = new Person(people[1]);
        RevDeBugAPI.Snapshot.RecordSnapshot("copy_constructor");
        return person.FirstName + " " + person.LastName;
    }
    [Route("copy_constructor_set_value")]
    public string GetCopyConstructorSetValue()
    {
        person = new Person(people[1]);
        person.SetFirstName("Harry");
        person.SetLastName("Potter");
        RevDeBugAPI.Snapshot.RecordSnapshot("copy_constructor_set_value");
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
        RevDeBugAPI.Snapshot.RecordSnapshot("inheritance");
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
        RevDeBugAPI.Snapshot.RecordSnapshot("multi_level_inheritance");
        return president.FirstName + " " + president.LastName + " Salary:" + president.GetSalary() + " Bonus:" + president.GetBonus() + " " + president.GetAmountOfBranches() + " branches";
    }
    [Route("inner_class")]
    public string GetInnerClass()
    {
        string test = " ";
        OuterClass myOuter = new OuterClass();
        OuterClass.InnerClass myInner = new OuterClass.InnerClass();
        test = "" + myOuter.ToString();
        RevDeBugAPI.Snapshot.RecordSnapshot("inner_class");
        return test;
    }

    [Route("abstract_class")]
    public string GetAbstractClass()
    {
        string test = "Pig says: wee";
        Pig myPig = new Pig();
        myPig.AnimalSound();
        myPig.Sleep();
        RevDeBugAPI.Snapshot.RecordSnapshot("abstract_class");
        return test;
    }
    [Route("check_objects_to_string")]
    public string CheckObjectToString()
    {
        person = new Person(people[1]);
        string test = person.ToString();

        RevDeBugAPI.Snapshot.RecordSnapshot("check_objects_to_string");
        return test;
    }
    [Route("methods_inside_method")]
    public string methodsInsideMethod()
    {
        string test = "";
        Person person = new Person("Tyson", "Fury");
        test += person.GetUserData();

        RevDeBugAPI.Snapshot.RecordSnapshot("methods_inside_method");
        return test;
    }

    [Route("refer_to_model")]
    public string referToModel()
    {
        string test = "";

        // Reference to person model
        PersonModel person = new();

        if (person is { FirstName: { Length: > 3 } })
            Console.WriteLine("Thats a long name");
        else
        {
            Console.WriteLine("name is not that long");
        }
        RevDeBugAPI.Snapshot.RecordSnapshot("refer_to_model");
        return test;
    }
    [Route("log_expression")]
    public string logExpression()
    {
        string test = person.FirstName;
        CallerExpressionAttribute.LogExpression(person.FirstName);
        RevDeBugAPI.Snapshot.RecordSnapshot("log_expression");
        return test;
    }
}
