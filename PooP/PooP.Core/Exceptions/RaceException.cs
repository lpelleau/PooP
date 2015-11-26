using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    /// <summary>
    /// Exception thrown whenever a bad race is used
    /// A race can only be used once and only certain races exist
    /// </summary>
    public class RaceException : Exception
    {
        /// <summary>
        /// Creates the exception with a given race
        /// </summary>
        /// <param name="race">The problematic race</param>
        public RaceException(string race)
            : base("The race \"" + race + "\" does not exist or has already been choosen !")
        {

        }
    }
}
