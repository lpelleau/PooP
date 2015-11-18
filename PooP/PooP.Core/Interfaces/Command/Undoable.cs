using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public interface Undoable
    {
        void undo();

        void redo();
    }
}
