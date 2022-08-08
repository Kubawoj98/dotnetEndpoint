using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    [Route("func_int_bool_implicity")]
    public string funcIntBool()
    {
        string test = "";
        var isOdd = (int n) => n % 2 == 1;
        bool result= isOdd(5);
        test += result;
        Console.WriteLine(string.Join(" ", result));
        RevDeBugAPI.Snapshot.RecordSnapshot("func_int_bool_implicity");
        return test;
    }

    [Route("func_string_int_implicity")]
    public string funcStringIntImplicity()
    {
        string test = "";
        var parse = (string s) => int.Parse(s);
        int result = parse("53");
        test += result;
        Console.WriteLine(string.Join(" ", result));
        RevDeBugAPI.Snapshot.RecordSnapshot("func_string_int_implicity");
        return test;
    }
    [Route("array_lambda")]
    public string arrayLambda()
    {
        string test = "";
        var numbersArray = () => new[] { 1, 2, 3 };
        Console.WriteLine(numbersArray);
        test += numbersArray;
        RevDeBugAPI.Snapshot.RecordSnapshot("array_lambda");
        return test;
    }

    [Route("array_lambda_inferred_type")]
    public string arrayLambdaInferredType()
    {
        string test = "";
        var numbersList = IList<int> () => new[] { 1, 2, 3 };
        Console.WriteLine(numbersList);
        test += numbersList;
        RevDeBugAPI.Snapshot.RecordSnapshot("array_lambda_inferred_type");
        return test;
    }

    [Route("func_int_bool_pure")]
    public string funcIntBoolPure()
    {
        string test = "";
        Func<int, bool> isEven = [Pure] (n) => n % 2 == 0;
        bool result = isEven(5);
        test += result;
        Console.WriteLine(string.Join(" ", result));
        RevDeBugAPI.Snapshot.RecordSnapshot("func_int_bool_pure");
        return test;
    }
}
