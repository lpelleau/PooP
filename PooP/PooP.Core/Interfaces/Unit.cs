using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Ressource;
using PooP.Core.Interfaces.Races;
using PooP.Core.Data;

namespace PooP.Core.Interfaces
{
    /// <summary>
    /// Represents a unit
    /// </summary>
    public interface Unit
    {
        /// <summary>
        /// Unit's life points
        /// </summary>
        int LifePoints
        {
            get;
            set;
        }

        /// <summary>
        /// Unit's race
        /// </summary>
        Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// Unit's position
        /// </summary>
        Position Position
        {
            get;
            set;
        }

        /// <summary>
        /// Unit's move points
        /// </summary>
        double MovePoints
        {
            get;
            set;
        }

        /// <summary>
        /// Tests if a unit can attack a tile
        /// </summary>
        /// <param name="Tile">Position to attack</param>
        /// <returns>tru eif the tile can be attacked</returns>
        bool canAttack(Position Tile);

        /// <summary>
        /// Computes the victory points given by the unit
        /// </summary>
        /// <returns>A number of victory points, from 0 to 3</returns>
        int getVictoryPoints();

        /// <summary>
        /// Computes the number of move points needed to move to a tile
        /// </summary>
        /// <param name="Tile">Tile to reach</param>
        /// <returns>The number of needed points</returns>
        double getMoveCost(Position Tile);

        /// <summary>
        /// Tests if the unit can move to a given position
        /// </summary>
        /// <param name="Target">Tile to reach</param>
        /// <returns>true if the unit can go to this tile</returns>
        bool canMoveTo(Position Target);

        /// <summary>
        /// Tests if the unit can defend itself
        /// </summary>
        /// <param name="Attackers">Attackers' position</param>
        /// <returns>true if it is possible</returns>
        bool canDefendAgainst(Position Attackers);

        /// <summary>
        /// Transforms the unit into datas
        /// </summary>
        /// <returns>The data object representing the unit</returns>
        UnitData ToData();
    }
}
