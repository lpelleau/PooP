using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    class NotExistingDifficultyException : Exception
    {
        public NotExistingDifficultyException(string diff) : base(diff + " is not a valid difficulty") { }
    }
}
