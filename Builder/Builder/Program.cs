using System;
using System.Collections.Generic;

namespace Builder
{
    interface IHouseBuilder
    {
        void BuildWall();

        void BuildRoof();
    }

    class WoodenHouse
    {
        public List<int> Walls { get; set; }

        public string Roof { get; set; }
    }

    class WoodenHouseBuilder : IHouseBuilder
    {
        private WoodenHouse woodenHouse;

        public WoodenHouseBuilder()
        {
            woodenHouse = new WoodenHouse();
        }

        public void BuildWall()
        {
            woodenHouse.Walls.Add(1);
            Console.WriteLine("The wall was built for wooden house!");
        }

        public void BuildRoof()
        {
            woodenHouse.Roof = "Roof"; 
            Console.WriteLine("The roof was built for wooden house!");
        }

        public WoodenHouse GetResultHouse()
        {
            return woodenHouse;
        }
    }

    class StoneHouse
    {
        public int Walls { get; set; }

        public int Roof { get; set; }
    }

    class StoneHouseBuilder : IHouseBuilder
    {
        private StoneHouse stoneHouse;

        public StoneHouseBuilder()
        {
            stoneHouse = new StoneHouse();
        }

        public void BuildRoof()
        {
            stoneHouse.Walls = 5;
            Console.WriteLine("The wall was built for stone house!");
        }

        public void BuildWall()
        {
            stoneHouse.Roof = 1;
            Console.WriteLine("The roof was built for stone house!");
        }
        public StoneHouse GetResultHouse()
        {
            return stoneHouse;
        }
    }

    class Director
    {
        IHouseBuilder houseBuilder; 

        public Director(IHouseBuilder builder)
        {
            houseBuilder = builder;
        }

        public void BuildHouse()
        {
            houseBuilder.BuildWall();
            houseBuilder.BuildRoof();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new WoodenHouseBuilder();
            var director = new Director(builder);

            director.BuildHouse();
            var result = builder.GetResultHouse();
            Console.WriteLine(result.Roof);
        }
    }
}
