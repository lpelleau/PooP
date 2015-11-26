using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    /// <summary>
    /// Exception thrown whenever an unexisting difficulty is used
    /// </summary>
    class NotExistingDifficultyException : Exception
    {
        /// <summary>
        /// Creates the exception
        /// </summary>
        /// <param name="diff">The difficulty that is used</param>
        public NotExistingDifficultyException(string diff) : base(diff + " is not a valid difficulty") { }
    }
}
