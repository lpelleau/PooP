using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    /// <summary>
    /// Exception thrown whenever a bad position is used
    /// </summary>
    public class BadPositionException : Exception
    {
        /// <summary>
        /// Creates an exception
        /// </summary>
        public BadPositionException()
            : base("Position out of bounds !")
        {

        }

        /// <summary>
        /// Creates an exception with a given message
        /// </summary>
        /// <param name="p">Message to display</param>
        public BadPositionException(string p)
            : base(p)
        {
        }
    }
}
