using PooP.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Ressource
{
    [Serializable]
    public class Position
    {
        private int x, y;
        public Position(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public int XPosition
        {
            get { return x; }
            set {
                if (value > 0) x = value;
                else throw new BadPositionException();
            }
        }

        public int YPosition
        {
            get { return y; }
            set
            {
                if (value > 0) y = value;
                else throw new BadPositionException();
            }
        }
    }
}
