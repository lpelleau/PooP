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
        private int cost;
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
            AttackSuccess = (MovedUnit.Race.Attack > Defender.Race.Defence);

            if (AttackSuccess)
            {
                Damage = 0;
                Defender.LifePoints -= Damage;
            }
            else
            {
                Damage = 0;
                MovedUnit.LifePoints -= Damage;
            }
            MovedUnit.MovePoints -= cost;
            throw new System.NotImplementedException();
        }

        public void undo()
        {
            // If Defender died
            // MovedUnit.Tile = OldTile;
            MovedUnit.MovePoints += cost;

            // If Defender still alive

            throw new System.NotImplementedException();
        }
    }
}
