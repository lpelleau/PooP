using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Commands;

namespace PooP.Core.Implementation.Command
{
    public class UndoableImpl : Undoable
    {
        public Stack<PooP.Core.Interfaces.Commands.Command> DoneCommands
        {
            get;
            set;
        }

        public Stack<PooP.Core.Interfaces.Commands.Command> UndoneCommands
        {
            get;
            set;
        }
    
        public void undo()
        {
            if (!(DoneCommands.Count == 0))
            {
                PooP.Core.Interfaces.Commands.Command LastCommand = DoneCommands.Pop();
                LastCommand.undo();
                UndoneCommands.Push(LastCommand);
            }
        }

        public void redo()
        {
            if (!(UndoneCommands.Count == 0))
            {
                PooP.Core.Interfaces.Commands.Command LastCommand = UndoneCommands.Pop();
                LastCommand.redo();
                DoneCommands.Push(LastCommand);
            }
        }
    }
}
