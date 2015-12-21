using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Commands;
using PooP.Core.Implementation.Maps;
using PooP.Core.Ressource;
using PooP.Core.Implementation.Games;
using PooP.Core.Exceptions;

namespace PooP.Core.Implementation.Commands
{
    /// <summary>
    /// Allows a unit to attack a tile
    /// </summary>
    public class AttackCommand : PooP.Core.Interfaces.Commands.Command
    {
        private Unit MovedUnit;
        private Position OldPos;
        private Position Target;
        public Unit Defender;
        private double cost;
        private bool AttackSuccess;
        private int Damage;

        /// <summary>
        /// Creates the command
        /// </summary>
        /// <param name="Attacker">The unit that attacks</param>
        /// <param name="AttackedTilePos">The tile that is under attack</param>
        public AttackCommand(Unit Attacker, Position AttackedTilePos)
        {
            MovedUnit = Attacker;
            Target = AttackedTilePos;
        }
    
        /// <summary>
        /// Tests if the tile can be attacked by the unit
        /// </summary>
        /// <returns>true if the unit can attack the tile</returns>
        public bool canDo()
        {
            return MovedUnit != null && Target != null && MovedUnit.canAttack(Target);
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public void execute()
        {
            if (!this.canDo()) throw new IncorrectCommandException();

            OldPos = MovedUnit.Position;

            cost = MovedUnit.getMoveCost(Target);
            // Choose the defender
            Defender = GameBuilder.CURRENTGAME.Map.getBestDefenderAt(Target);

            // Determine who wins the battle
            AttackSuccess = (MovedUnit.Race.Attack * MovedUnit.LifePoints / MovedUnit.Race.Life) > Defender.Race.Defence
                || (!Defender.canDefendAgainst(OldPos)) ;

            Random randGenerator = new Random();

            // The attacker wins the battle
            if (AttackSuccess)
            {
                // The damage are (Attack-Defence)+/-50%
                Damage = (MovedUnit.Race.Attack - Defender.Race.Defence) * randGenerator.Next(50,150)/100;
                Defender.LifePoints -= Damage;

                if (Defender.LifePoints <= 0)
                {
                    // Move the attacker to the tile
                    MovedUnit.Position = Target;
                }
            }
            // The defender wins
            else
            {
                // The damage are (Attack-Defence)+/-50%
                Damage = (Defender.Race.Attack - MovedUnit.Race.Defence) * randGenerator.Next(50, 150) / 100;
                MovedUnit.LifePoints -= Damage;
            }

            MovedUnit.MovePoints -= cost;

            UndoableImpl.DoneCommands.Push(this);
            UndoableImpl.UndoneCommands.Clear();
        }

        /// <summary>
        /// Undoes the command
        /// </summary>
        public void undo()
        {
            MovedUnit.MovePoints += cost;

            if (AttackSuccess)
            {
                // The attack had been successful
                if (Defender.LifePoints < 0)
                {
                    // The unit had moved to the target tile
                    MovedUnit.Position = OldPos;
                }
                // Give back the life points that had been taken
                Defender.LifePoints += Damage;
            }
            else
            {
                // Give back the life points that had been taken
                MovedUnit.LifePoints += Damage;
            }
        }

        /// <summary>
        /// Redoes the command
        /// </summary>
        public void redo()
        {
            // The attacker wins the battle
            if (AttackSuccess)
            {
                // The damage are (Attack-Defence)+/-50%
                Defender.LifePoints -= Damage;

                if (Defender.LifePoints <= 0)
                {
                    // Move the attacker to the tile
                    MovedUnit.Position = Target;
                }
            }
            // The defender wins
            else
            {
                // The damage are (Attack-Defence)+/-50%
                MovedUnit.LifePoints -= Damage;
            }

            MovedUnit.MovePoints -= cost;

            UndoableImpl.DoneCommands.Push(this);
            UndoableImpl.UndoneCommands.Clear();
        }
    }
}
