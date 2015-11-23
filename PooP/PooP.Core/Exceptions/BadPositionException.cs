using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    public class BadPositionException : Exception
    {
        public BadPositionException() : base("Position out of bounds !")
        {
            
        }
    }
}
