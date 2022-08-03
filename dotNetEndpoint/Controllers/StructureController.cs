using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.InteropServices;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class Structure : Controller
    {
        [Route("get_coordinate")]
        public string GetCoordinate()
        {
            Coordinate coordinate1 = new Coordinate(5, 12);
            string test = coordinate1 + "";

            RevDeBugAPI.Snapshot.RecordSnapshot("get_coordinate");
            return test;
        }

        [Route("set_origin")]
        public string CoordinateSetOrigin()
        {
            string test = "";
            Coordinate coordinate1;
            coordinate1.x = 5;
            coordinate1.y = 10;
            test += coordinate1.SetOriginX();
            test += coordinate1.SetOriginY();

            RevDeBugAPI.Snapshot.RecordSnapshot("set_origin");
            return test;
        }

        [Route("get_origin")]
        public string getOrigin()
        {
            string test = "";
            Coordinate coordinate1;
            coordinate1.x = 5;
            coordinate1.y = 10;
            test += coordinate1.SetOriginX();
            test += coordinate1.SetOriginY();

            RevDeBugAPI.Snapshot.RecordSnapshot("get_origin");
            return test;
        }
        [Route("conversion_request")]
        public string structConversionRequest()
        {
            string test = "Conversion request";

            var byteArray = new byte[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            var byteArray2 = new byte[] { 1, 0, 1, 0, 0, 1, 1, 1 };
            Span<byte> byteSpan = byteArray;
            Span<int> intSpan = MemoryMarshal.Cast<byte, int>(byteSpan);

            Span<byte> byteSpan2 = byteArray2;
            Span<int> intSpan2 = MemoryMarshal.Cast<byte, int>(byteSpan2);

            ConversionRequest conversion = new ConversionRequest(intSpan, intSpan2);
            test += conversion.Rate.ToString();
            test += conversion.Values.ToString();

            RevDeBugAPI.Snapshot.RecordSnapshot("conversion_request");
            return test;
        }

        [Route("custom_ref")]
        public string customRef()
        {
            string test = "";
            int number1 = 42;
            int number2 = 43;

            byte[] numberBytes = BitConverter.GetBytes(number1);
            byte[] numberBytes2 = BitConverter.GetBytes(number2);

            Span<byte> asBytes = numberBytes;
            Span<byte> asBytes2 = numberBytes2;

            int i = MemoryMarshal.Read<int>(asBytes);
            int i2 = MemoryMarshal.Read<int>(asBytes2);

            Span<int> asInts = MemoryMarshal.Cast<byte, int>(asBytes);
            Span<int> asInts2 = MemoryMarshal.Cast<byte, int>(asBytes2);



            CustomRef customRef = new CustomRef(true, asInts, asInts2);
            test += customRef.IsValid + " ";
            test += customRef.Inputs.ToString() + " ";
            test += customRef.Outputs.ToString() + " ";
            RevDeBugAPI.Snapshot.RecordSnapshot("custom_ref");
            return test;
        }
        [Route("structure_improvement")]
        public string structImprovement()
        {
            string test = "improvement of structs added in c# 10";
            // Struct improvement
            var m1 = new Measurement();
            Console.WriteLine(m1);  // output: NaN (Undefined)

            var m2 = default(Measurement);
            Console.WriteLine(m2);  // output: 0 ()

            var ms = new Measurement[2];
            Console.WriteLine(string.Join(", ", ms));  // output: 0 (), 0 ()

            RevDeBugAPI.Snapshot.RecordSnapshot("structure_improvement");
            return test;
        }
        [Route("record_struct")]
        public void recordStruct()
        {
            // record structs
            foreach (var item in data)
                Console.WriteLine(item);

            var heatingDegreeDays = new HeatingDegreeDays(65, data);
            Console.WriteLine(heatingDegreeDays);

            var coolingDegreeDays = new CoolingDegreeDays(65, data);
            Console.WriteLine(coolingDegreeDays);
            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            const int FieldWidthRightAligned = 20;
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");
            RevDeBugAPI.Snapshot.RecordSnapshot("record_struct");
        }
        private static DailyTemperature[] data = new DailyTemperature[]
    {
new DailyTemperature(HighTemp: 57, LowTemp: 30),
new DailyTemperature(60, 35),
new DailyTemperature(63, 33),
new DailyTemperature(68, 29),
new DailyTemperature(72, 47),
new DailyTemperature(75, 55),
new DailyTemperature(77, 55),
new DailyTemperature(72, 58),
new DailyTemperature(70, 47),
new DailyTemperature(77, 59),
new DailyTemperature(85, 65),
new DailyTemperature(87, 65),
new DailyTemperature(85, 72),
new DailyTemperature(83, 68),
new DailyTemperature(77, 65),
new DailyTemperature(72, 58),
new DailyTemperature(77, 55),
new DailyTemperature(76, 53),
new DailyTemperature(80, 60),
new DailyTemperature(85, 66)
    };


    }
    struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int SetOriginX()
        {
            return x = 0;
        }
        public int SetOriginY()
        {
            return y = 0;
        }
        public static Coordinate GetOrigin()
        {
            return new Coordinate();
        }
    }
    public ref struct CustomRef
    {
        public bool IsValid;
        public Span<int> Inputs;
        public Span<int> Outputs;

        public CustomRef(bool isValid, Span<int> Inputs, Span<int> Outputs)
        {
            IsValid = isValid;
            this.Inputs = Inputs;
            this.Outputs = Outputs;
        }
    }
    public readonly ref struct ConversionRequest
    {

        public ConversionRequest(Span<int> rate, Span<int> values)
        {
            Rate = rate;
            Values = values;
        }

        public Span<int> Rate { get; }
        public Span<int> Values { get; }
    }
    public readonly struct Measurement
    {
        public Measurement()
        {
            Value = double.NaN;
            Description = "Undefined";
        }

        public Measurement(double value, string description)
        {
            Value = value;
            Description = description;
        }

        public double Value { get; init; }
        public string Description { get; init; }

        public override string ToString() => $"{Value} ({Description})";
    }
}