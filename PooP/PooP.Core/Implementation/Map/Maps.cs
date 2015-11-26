using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Wrapper;

namespace PooP.Core.Implementation.Maps
{
    public class SmallMap : CreateMap
    {
        private static int SIZE = 42;
        public void create()
        {
            foreach (var tile in new Algo().CreateMap(SIZE).Tiles)
            {
                //Console.WriteLine(tile);
            }
        }
    }

    public class StandardMap : CreateMap
    {
        private static int SIZE = 42;
        public void create()
        {
            foreach (var tile in new Algo().CreateMap(SIZE).Tiles)
            {
                //Console.WriteLine(tile);
            }
        }
    }

    public class DemoMap : CreateMap
    {
        private static int SIZE = 42;
        public void create()
        {
            foreach (var tile in new Algo().CreateMap(SIZE).Tiles)
            {
                //Console.WriteLine(tile);
            }
        }
    }
}
