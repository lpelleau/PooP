using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Wrapper;

namespace PooP.Core.Implementation.Maps
{
    /// <summary>
    /// Implements a small game map
    /// </summary>
    /// <see cref="CreateMap"/>
    public class SmallMap : CreateMap
    {
        /// <summary>
        /// A small map is 10x10 tiles large
        /// </summary>
        private static int SIZE = 10;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public void create()
        {
            foreach (var tile in new Algo().CreateMap(SIZE).Tiles)
            {
                //Console.WriteLine(tile);
            }
        }
    }

    /// <summary>
    /// Implements a standard map
    /// </summary>
    /// <see cref="CreateMap"/>
    public class StandardMap : CreateMap
    {
        /// <summary>
        /// A standard map is 14x14 tiles large
        /// </summary>
        private static int SIZE = 14;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public void create()
        {
            foreach (var tile in new Algo().CreateMap(SIZE).Tiles)
            {
                //Console.WriteLine(tile);
            }
        }
    }

    /// <summary>
    /// Implements a demo map
    /// </summary>
    /// <see cref="CreateMap"/>
    public class DemoMap : CreateMap
    {
        /// <summary>
        /// A demo map is 6x6 tiles large
        /// </summary>
        private static int SIZE = 6;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public void create()
        {
            foreach (var tile in new Algo().CreateMap(SIZE).Tiles)
            {
                //Console.WriteLine(tile);
            }
        }
    }
}
