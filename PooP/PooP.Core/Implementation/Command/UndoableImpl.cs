using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class UndoableImpl : Undoable
    {
        public Stack<Command> DoneCommands
        {
            get;
            set;
        }

        public Stack<Command> UndoneCommands
        {
            get;
            set;
        }
    
        public void undo()
        {
            if (!(DoneCommands.Count == 0))
            {
                Command LastCommand = DoneCommands.Pop();
                LastCommand.undo();
                UndoneCommands.Push(LastCommand);
            }
        }

        public void redo()
        {
            if (!(UndoneCommands.Count == 0))
            {
                Command LastCommand = UndoneCommands.Pop();
                LastCommand.redo();
                DoneCommands.Push(LastCommand);
            }
        }
    }
}
