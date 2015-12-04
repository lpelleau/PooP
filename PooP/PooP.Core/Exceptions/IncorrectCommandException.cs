using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Exceptions
{
    class IncorrectCommandException : Exception
    {
        public IncorrectCommandException() : base("An incorrect command has been launched !") { }
    }
}
