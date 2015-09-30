using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public abstract class Command
    {
        public abstract void execute();

        public abstract bool canDo();

        public abstract void undo();
    }
}
