using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Implementation.Commands;
using PooP.Core.Ressource;
using PooP.Core.Interfaces;

namespace PooP.Test
{
    [TestClass]
    public class AttackCommandTest
    {
        /// <summary>
        /// Initializes the environment
        /// </summary>
        /// <see cref="tester1.flav"/>
        [TestInitialize]
        public void init()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");
        }

        /// <summary>
        /// A unit cannot move if it has not enough points
        /// </summary>
        /// <seealso cref="MoveTest"/>/>
        [TestMethod]
        public void CannotAttackIfTooFar()
        {
            // Since the tile is too far, the orc can't move to it
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], new Position(4, 2)).canDo());
        }

        /// <summary>
        /// A unit cannot attack if the target isn't occupied
        /// </summary>
        [TestMethod]
        public void CannotAttackIfNotOccupied()
        {
            // Since the tile is not occupied, the unit can't attack it
            Assert.IsFalse(new AttackCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], new Position(4, 6)).canDo());

            // Test when the enemy unit is on the way
            Assert.IsFalse(new AttackCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], new Position(2, 5)).canDo());
        }

        /// <summary>
        /// Attacks and must win
        /// </summary>
        [TestMethod]
        public void WinsAttack()
        {
            // Attack with a defender at only 1 HP
            Position AttackedPos = new Position(4, 7);
            Unit Attacker = GameBuilder.CURRENTGAME.Players[0].Race.Units[1];
            int HPAttacker = Attacker.LifePoints;
            Unit BestDefender = GameBuilder.CURRENTGAME.Map.getBestDefenderAt(AttackedPos);
            int HPDefender = BestDefender.LifePoints;

            new MoveCommand(Attacker, new Position(4, 6)).execute();
            AttackCommand atk = new AttackCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], AttackedPos);

            atk.execute();

            Assert.AreNotEqual(HPDefender, BestDefender.LifePoints);
            Assert.IsTrue(0 >= BestDefender.LifePoints);
            Assert.AreEqual(HPAttacker, Attacker.LifePoints);
        }

        /// <summary>
        /// Attacks and must win because the defender is too far away
        /// </summary>
        [TestMethod]
        public void WinsAttack2()
        {
            // End the turn so that the elves can play
            new EndTurn().execute();

            // Attack with a defender that cannot defend itself
            Position AttackedPos = new Position(4, 5);
            Unit Attacker = GameBuilder.CURRENTGAME.Players[1].Race.Units[2];
            int HPAttacker = Attacker.LifePoints;
            Unit BestDefender = GameBuilder.CURRENTGAME.Map.getBestDefenderAt(AttackedPos);
            int HPDefender = BestDefender.LifePoints;

            AttackCommand atk = new AttackCommand(Attacker, AttackedPos);

            atk.execute();

            Assert.AreNotEqual(HPDefender, BestDefender.LifePoints);
            Assert.AreEqual(HPAttacker, Attacker.LifePoints);
        }

        /// <summary>
        /// Tests the undoing of a move command
        /// </summary>
        [TestMethod]
        public void UndoAttack()
        {
            Position WhereToAttack = new Position(4, 6);
            Unit Attacker = GameBuilder.CURRENTGAME.Players[0].Race.Units[1];
            Unit Defenser = GameBuilder.CURRENTGAME.Players[1].Race.Units[3];
            double MovedPoints = Attacker.MovePoints;
            int LifeAtk = Attacker.LifePoints;
            int LifeDef = Defenser.LifePoints;

            // Attack the unit
            AttackCommand atkc = new AttackCommand(Attacker, Defenser.Position);
            atkc.execute();

            // Undo the attack
            atkc.undo();
            Assert.IsTrue(Attacker.MovePoints.Equals(MovedPoints));
            Assert.IsTrue(Attacker.LifePoints.Equals(LifeAtk));
            Assert.IsTrue(Defenser.LifePoints.Equals(LifeDef));
        }
        
        /// <summary>
        /// Tests the redoing of a move
        /// </summary>
        [TestMethod]
        public void RedoAttack()
        {
            Position WhereToAttack = new Position(4, 6);
            Unit Attacker = GameBuilder.CURRENTGAME.Players[0].Race.Units[1];
            Unit Defenser = GameBuilder.CURRENTGAME.Players[1].Race.Units[3];
            double MovedPoints = Attacker.MovePoints;
            int LifeAtk = Attacker.LifePoints;
            int LifeDef = Defenser.LifePoints;

            // Attack the unit
            AttackCommand atkc = new AttackCommand(Attacker, Defenser.Position);
            atkc.execute();
            double MovedPointsAfter = Attacker.MovePoints;
            int LifeAtkAfter = Attacker.LifePoints;
            int LifeDefAfter = Defenser.LifePoints;

            // Undo the attack
            atkc.undo();
            Assert.IsTrue(Attacker.MovePoints.Equals(MovedPoints));
            Assert.IsTrue(Attacker.LifePoints.Equals(LifeAtk));
            Assert.IsTrue(Defenser.LifePoints.Equals(LifeDef));

            // Redo the attack
            atkc.redo();
            Assert.IsTrue(Attacker.MovePoints.Equals(MovedPointsAfter));
            Assert.IsTrue(Attacker.LifePoints.Equals(LifeAtkAfter));
            Assert.IsTrue(Defenser.LifePoints.Equals(LifeDefAfter));
        }
    }
}
