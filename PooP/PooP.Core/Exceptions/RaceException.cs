using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    public class RaceException : Exception
    {
        public RaceException(string race)
            : base("The race \"" + race + "\" does not exist or has already been choosen !")
        {

        }
    }
}
