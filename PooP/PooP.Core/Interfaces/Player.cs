using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP
{
    public interface Player
    {
        Race Race
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
    }
}
