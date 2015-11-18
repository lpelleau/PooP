using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Implementation.Commands
{
    public class EndTurn : PooP.Core.Interfaces.Commands.Command
    {
        public bool canDo()
        {
            return true;
        }

        public void execute()
        {
            
            throw new System.NotImplementedException();
        }

        public void undo()
        {
            // Undo is not possible
        }

        public void redo()
        {
            // Redo is not possible
        }
    }
}
