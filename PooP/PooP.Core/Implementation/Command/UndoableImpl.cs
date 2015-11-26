using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Commands;

namespace PooP.Core.Implementation.Command
{
    /// <summary>
    /// Impelements an undoable list of actions
    /// </summary>
    public class UndoableImpl : Undoable
    {
        // List of done actions
        public Stack<PooP.Core.Interfaces.Commands.Command> DoneCommands
        {
            get;
            set;
        }

        // List of undone commands
        public Stack<PooP.Core.Interfaces.Commands.Command> UndoneCommands
        {
            get;
            set;
        }
    
        /// <summary>
        /// Undoes the last done command and puts it in the undone commands
        /// </summary>
        public void undo()
        {
            if (!(DoneCommands.Count == 0))
            {
                PooP.Core.Interfaces.Commands.Command LastCommand = DoneCommands.Pop();
                LastCommand.undo();
                UndoneCommands.Push(LastCommand);
            }
        }

        /// <summary>
        /// Redoes the last undone command and puts it in the done commands
        /// </summary>
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
