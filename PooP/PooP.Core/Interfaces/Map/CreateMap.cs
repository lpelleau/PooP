using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Implementation.Maps;

namespace PooP.Core.Interfaces.Maps
{
    /// <summary>
    /// Creates a map
    /// </summary>
    public interface CreateMap
    {
        /// <summary>
        /// Creates the map
        /// </summary>
        Map create();
    }
}
