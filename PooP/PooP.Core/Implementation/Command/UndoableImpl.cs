﻿using System;
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
    
        public void undo()
        {
            throw new System.NotImplementedException();
        }

        public void redo()
        {
            throw new System.NotImplementedException();
        }
    }
}