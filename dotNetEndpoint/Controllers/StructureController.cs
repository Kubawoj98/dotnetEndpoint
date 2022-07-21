using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class Structure : Controller
    {
        [Route("get_coordinate")]
        public string GetCoordinate()
        {
            Coordinate coordinate1 = new Coordinate(5,12);
            string test = coordinate1+"";

            Utilities.RevDeBugCaller.RecordSnapshot("get_coordinate");
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

            Utilities.RevDeBugCaller.RecordSnapshot("set_origin");
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

            Utilities.RevDeBugCaller.RecordSnapshot("get_origin");
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

            Utilities.RevDeBugCaller.RecordSnapshot("conversion_request");
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
            test += customRef.Outputs.ToString()+ " ";
            Utilities.RevDeBugCaller.RecordSnapshot("custom_ref");
            return test;
        }
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

        public CustomRef(bool isValid,Span<int>  Inputs, Span<int> Outputs)
        {
            IsValid= isValid;
            this.Inputs= Inputs;
            this.Outputs= Outputs; 
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
}