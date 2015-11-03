using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class CommandsStack
    {
        public Stack<Command> DoneCommands
        {
            get;
            set;
        }
    
        public void undo()
        {
            throw new System.NotImplementedException();
        }
    }
}
