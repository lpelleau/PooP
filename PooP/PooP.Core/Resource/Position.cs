using PooP.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Ressource
{
    /// <summary>
    /// Represents an {x;y} position
    /// </summary>
    [Serializable]
    public class Position
    {
        private int x, y;

        /// <summary>
        /// Creates an empty position
        /// </summary>
        public Position()
        {
            XPosition = 0;
            YPosition = 0;
        }

        /// <summary>
        /// Creates a position with x;y
        /// </summary>
        /// <param name="xPosition">x-axis position</param>
        /// <param name="yPosition">y-axis position</param>
        public Position(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        /// <summary>
        /// The x-axis position
        /// You can't have a negative x
        /// </summary>
        public int XPosition
        {
            get { return x; }
            set {
                if (value >= 0) x = value;
                else throw new BadPositionException("x=" + value);
            }
        }

        /// <summary>
        /// The y-axis position
        /// You can't have a negative y
        /// </summary>
        public int YPosition
        {
            get { return y; }
            set
            {
                if (value >= 0) y = value;
                else throw new BadPositionException("y=" + value);
            }
        }
    
        public override bool Equals(Object o)
        {
            if (!o.GetType().Name.Equals("Position"))
                return false;
            return ((Position)o).x == x && ((Position)o).y == y;
        }
    }
}
