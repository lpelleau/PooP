using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class MoveCommand : Command
    {
        private Unit MovedUnit;
        private Position OldPosition;

        public bool canDo()
        {
            throw new System.NotImplementedException();
        }

        public void execute()
        {
            throw new System.NotImplementedException();
        }

        public void undo()
        {
            throw new System.NotImplementedException();
        }
    }
}
