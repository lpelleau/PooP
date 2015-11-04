using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class AttackCommand : Command
    {
        private Unit MovedUnit;
        private Tile OldTile;
        private Tile Target;
        private Unit Defender;
        private double cost;
        private bool AttackSuccess;
        private int Damage;

        public AttackCommand(Unit Attacker, Tile AttackedTile)
        {
            MovedUnit = Attacker;
            OldTile = MovedUnit.Tile;
            Target = AttackedTile;
            Defender = Target.getBestDefender();
            cost = MovedUnit.getMoveCost(Target);
        }
    
        public bool canDo()
        {
            return MovedUnit.canAttack(Target);
        }

        public void execute()
        {
            // Determine who wins the battle
            AttackSuccess = (MovedUnit.Race.Attack * MovedUnit.LifePoints / MovedUnit.Race.Life) > Defender.Race.Defence;

            Random randGenerator = new Random();

            // The attacker wins the battle
            if (AttackSuccess)
            {
                // The damage are (Attack-Defence)+/-50%
                Damage = (MovedUnit.Race.Attack - Defender.Race.Defence) * randGenerator.Next(50,150)/100;
                Defender.LifePoints -= Damage;

                if (Defender.LifePoints < 0)
                {
                    // Kills the defender
                    Defender.Race.Units.Remove(Defender);

                    // Move the attacker to the tile
                    MovedUnit.Tile = Target;
                }
            }
            // The defender wins
            else
            {
                // The damage are (Attack-Defence)+/-50%
                Damage = (Defender.Race.Attack - MovedUnit.Race.Defence) * randGenerator.Next(50, 150) / 100;
                MovedUnit.LifePoints -= Damage;

                if (MovedUnit.LifePoints < 0)
                {
                    // Kills the unit
                    MovedUnit.Race.Units.Remove(MovedUnit);
                }
            }

            MovedUnit.MovePoints -= cost;
        }

        public void undo()
        {
            MovedUnit.MovePoints += cost;

            if (AttackSuccess)
            {
                // The attack had been successful
                if (Defender.LifePoints < 0)
                {
                    // The unit had moved to the target tile
                    MovedUnit.Tile = OldTile;

                    // The defender had been killed : resurect it
                    Defender.Race.Units.Add(Defender);
                }
                // Give back the life points that had been taken
                Defender.LifePoints += Damage;
            }
            else
            {
                // The ttack had failed
                if (MovedUnit.LifePoints < 0)
                {
                    // Put again the unit in its army
                    MovedUnit.Race.Units.Add(MovedUnit);
                }
                // Give back the life points that had been taken
                MovedUnit.LifePoints += Damage;
            }
        }

        public void redo()
        {
            this.execute();
        }
    }
}
