using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Exceptions
{
    public class BadPositionException : Exception
    {
        private string p;

        public BadPositionException()
            : base("Position out of bounds !")
        {

        }

        public BadPositionException(string p)
            : base(p)
        {
        }
    }
}
