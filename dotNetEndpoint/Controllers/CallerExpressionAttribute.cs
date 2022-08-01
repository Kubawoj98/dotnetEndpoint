using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace dotNetEndpoint.Controllers
{
    public class CallerExpressionAttribute 
    {
        public static void LogExpression<T>(T value, [CallerArgumentExpression("value")] string expression = null)
        {
            Console.WriteLine($"{expression}:{value}");
        }
        public static void Validate(bool condition, [CallerArgumentExpression("condition")] string? message = null)
        {
            if (!condition)
            {
                throw new InvalidOperationException($"Argument failed validation: <{message}>");
            }
        }
    }
}
