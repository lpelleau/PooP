using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    /// <summary>
    /// Exception thrown whenever a bad tile type is used
    /// </summary>
    public class TileTypeException : Exception
    {
        /// <summary>
        /// Creates an exception for an incorrect tile type
        /// </summary>
        /// <param name="message">Problematic tile type</param>
        public TileTypeException(string message) : base(message + " is not a possible tile type !")
        {
        }
    }
}
