using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    public class NotExistingRaceException : Exception
    {
        public NotExistingRaceException(string race)
            : base("The race \"" + race + "\" does not exist !")
        {

        }
    }
}
