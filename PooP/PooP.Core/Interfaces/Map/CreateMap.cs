﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Implementation.Maps;

namespace PooP.Core.Interfaces.Maps
{
    public interface CreateMap
    {
        TileFactory create();
    }
}
