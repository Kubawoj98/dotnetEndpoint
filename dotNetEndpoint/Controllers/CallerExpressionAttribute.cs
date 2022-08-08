using System;
using System.Runtime.CompilerServices;


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
