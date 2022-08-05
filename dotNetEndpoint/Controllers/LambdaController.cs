using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace dotNetEndpoint.Controllers;

[Route("[controller]")]

public class LambdaController : Controller
{
    [Route("bool_lambda")]
    public string boolLambda()
    {
        string test = "";
        Func<int, bool> equalsFive = x => x == 5;
        bool result = equalsFive(4);
        Console.WriteLine(result);   // False
        RevDeBugAPI.Snapshot.RecordSnapshot("bool_lambda");
        return test;
    }
    [Route("count_lambda")]
    public string countLambda()
    {
        string test = "";
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        int oddNumbers = numbers.Count(n => n % 2 == 1);
        Console.WriteLine($"There are {oddNumbers} odd numbers in {string.Join(" ", numbers)}");
        RevDeBugAPI.Snapshot.RecordSnapshot("count_lambda");
        return test;
    }
    [Route("first_numbers_less")]
    public string firstNumbersLess()
    {
        string test = "";
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var firstNumbersLessThanSix = numbers.TakeWhile(n => n < 6);
        Console.WriteLine(string.Join(" ", firstNumbersLessThanSix));
        RevDeBugAPI.Snapshot.RecordSnapshot("first_numbers_less");
        return test;
    }
    [Route("first_small_numbers")]
    public string firstSmallNumbers()
    {
        string test = "";
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);
        Console.WriteLine(string.Join(" ", firstSmallNumbers));
        RevDeBugAPI.Snapshot.RecordSnapshot("first_small_numbers");
        return test;
    }
}
