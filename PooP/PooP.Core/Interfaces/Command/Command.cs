using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Interfaces.Commands
{
    public interface Command
    {
        bool canDo();
        void execute();
        void undo();
        void redo();
    }
}
