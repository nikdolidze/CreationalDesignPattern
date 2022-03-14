using System;
using System.Collections.Generic;
using System.Text;
/*
The intent of the builder pattern is to separate the construction of a complex object from its representation.So the same construction process can create different
representations.
*/
namespace Builder
{
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string part in _parts)
            {
                sb.Append($"Car of type {_carType} has part {part}. ");
            }

            return sb.ToString();
        }
    }
    public abstract class CarBuilder
    {
        public Car Car { get; private set; }

        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }
    public class BMWBuilder : CarBuilder
    {
        // Invoke base class constructor
        public BMWBuilder()
            : base("BMW")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'a fancy V8 engine'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'5-door with metallic finish'");
        }
    }
    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder()
            : base("Mini")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'not a V8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'3-door with stripes'");
        }
    }
    public class Garage
    {
        private CarBuilder _builder;

        public Garage()
        {
        }

        public void Construct(CarBuilder builder)
        {
            _builder = builder;

            _builder.BuildEngine();
            _builder.BuildFrame();
        }

        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }

    }
}
