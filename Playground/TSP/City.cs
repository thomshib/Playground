using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.TSP
{
   class City
    {
        private static Random rand = new Random();

        public double X { get; private set; }
        public double Y { get; private set; }

        public int CityName { get; private set; }

        public City(int name)
        {
            CityName = name;
            X = rand.NextDouble() * 100;
            Y = rand.NextDouble() * 100;
        }
    }
}
