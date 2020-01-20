using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace FabricMethod
{
    interface ITransport
    {
        void Move();
    }

    interface IDeriver
    {
        ITransport FabricMethod();
    }

    class Car : ITransport
    {
        public void Move()
        {
            Console.WriteLine("Car is moving!");
        }
    }

    class Boat : ITransport
    {
        public void Move()
        {
            Console.WriteLine("Boat is moving!");
        }
    }

    class CarDeriver : IDeriver
    {
        public ITransport FabricMethod()
        {
            return new Car();
        }
    }
    class BoatDeriver : IDeriver
    {
        public ITransport FabricMethod()
        {
            return new Boat();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var derivers = new List<IDeriver> { new CarDeriver(), new BoatDeriver() };
            foreach(var deriver in derivers)
            {
                var transport = deriver.FabricMethod();
                transport.Move();
            }
        }
    }
}
