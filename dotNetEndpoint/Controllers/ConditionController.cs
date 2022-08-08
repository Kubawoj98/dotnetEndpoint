using dotNetEndpointApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dotNetEndpoint.Controllers;

[Route("[controller]")]
public class ConditionController : Controller
{
    [Route("switch")]
    public string Switch()
    {
        string test = "";
        Random rand = new Random();
        int randomNumber = rand.Next(3);
        switch (randomNumber)
        {
            case 0:
                test = "Case 0";
                break;
            case 1:
                test = "Case 1";
                break;
            case 2:
                test = "Case 2";
                break;
            default:
                test = "Default value";
                break;
        }
        RevDeBugAPI.Snapshot.RecordSnapshot("switch");
        return test;
    }
    [Route("single_if")]
    public string SingleIf()
    {
        string test = "";
        Random rand = new Random();
        int randomNumber = rand.Next(10);
        if (randomNumber > 4)
        {
            test = "more";
        }
        else
        {
            test = "less";
        }
        RevDeBugAPI.Snapshot.RecordSnapshot("single_if");
        return test;
    }
    [Route("nested_if")]
    public string NestedIf()
    {
        string test = "";
        Person person = new Person("Jan", "Kowalski");
        if (person.GetFirstName() == "Jan")
        {
            if (person.GetLastName() == "Kowalski")
            {
                test = "User is Jan Kowalski";
            }
        }
        else
        {
            test = "User is not Jan Kowalski";
        }
        RevDeBugAPI.Snapshot.RecordSnapshot("nested_if");
        return test;
    }
}
