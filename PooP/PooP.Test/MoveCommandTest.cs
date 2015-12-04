using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Implementation.Commands;
using PooP.Core.Ressource;
using PooP.Core.Interfaces;

namespace PooP.Test
{
    [TestClass]
    public class MoveCommandTest
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
        public void CannotDoIfTooFar()
        {
            // Since the tile is too far, the orc can't move to it
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], new Position(4, 2)).canDo());
        }

        /// <summary>
        /// A unit cannot move if the target is occupied
        /// </summary>
        [TestMethod]
        public void CannotDoIfOccupied()
        {
            // Since the tile is occupied, the unit can't move to it
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], new Position(4, 7)).canDo());

            // Test when the enemy unit is on the way
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], new Position(2, 5)).canDo());
        }

        /// <summary>
        /// Tries to walk on water with different races
        /// </summary>
        [TestMethod]
        public void WalkOnWater()
        {
            // An orc can't walk on water
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], (new Position(5, 5))).canDo());

            // Let the elves play
            new EndTurn().execute();

            // An elf can't walk on water
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[1].Race.Units[1], (new Position(8, 6))).canDo());

            GameSave.INSTANCE.load("../../Test_files/tester2");
            // A human can walk on water
            Assert.IsTrue(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], (new Position(5, 5))).canDo());
        }

        /// <summary>
        /// Moves a unit and checks the new position
        /// </summary>
        [TestMethod]
        public void MovesTheUnit()
        {
            Position WhereToGo = new Position(4, 6);
            Unit UnitToMove = GameBuilder.CURRENTGAME.Players[0].Race.Units[1];
            // The Unit is on (4;5) and moves to (4;6)
            new MoveCommand(UnitToMove, WhereToGo).execute();

            Assert.IsTrue(UnitToMove.Position.Equals(WhereToGo));
        }

        /// <summary>
        /// Checks that the command decreases the move points
        /// </summary>
        [TestMethod]
        public void DecreasesMovePoints()
        {
            Position WhereToGo = new Position(4, 6);
            Unit UnitToMove = GameBuilder.CURRENTGAME.Players[0].Race.Units[1];
            double PointsBeforeMove = UnitToMove.MovePoints;
            double PointsNeeded = UnitToMove.getMoveCost(WhereToGo);
            // The Unit is on (4;5) and moves to (4;6)
            new MoveCommand(UnitToMove, WhereToGo).execute();

            Assert.AreEqual(PointsBeforeMove - PointsNeeded, UnitToMove.MovePoints);
        }

        /// <summary>
        /// Tests the undoing of a move command
        /// </summary>
        [TestMethod]
        public void UndoMove()
        {
            Position WhereToGo = new Position(4, 6);
            Unit UnitToMove = GameBuilder.CURRENTGAME.Players[0].Race.Units[1];
            Position BeforeGoing = UnitToMove.Position;
            double PointsBeforeMove = UnitToMove.MovePoints;
            double PointsNeeded = UnitToMove.getMoveCost(WhereToGo);

            // Move the unit
            MoveCommand mvc = new MoveCommand(UnitToMove, WhereToGo);
            mvc.execute();

            Assert.IsFalse(UnitToMove.Position.Equals(BeforeGoing));
            Assert.AreNotEqual(PointsBeforeMove, UnitToMove.MovePoints);
            Assert.IsTrue(UnitToMove.Position.Equals(WhereToGo));
            Assert.AreEqual(PointsBeforeMove - PointsNeeded, UnitToMove.MovePoints);
            
            // Undo the move
            mvc.undo();

            Assert.IsTrue(UnitToMove.Position.Equals(BeforeGoing));
            Assert.AreEqual(PointsBeforeMove, UnitToMove.MovePoints);
            Assert.IsFalse(UnitToMove.Position.Equals(WhereToGo));
            Assert.AreNotEqual(PointsBeforeMove - PointsNeeded, UnitToMove.MovePoints);
        }

        /// <summary>
        /// Tests the redoing of a move
        /// </summary>
        [TestMethod]
        public void RedoMove()
        {

            Position WhereToGo = new Position(4, 6);
            Unit UnitToMove = GameBuilder.CURRENTGAME.Players[0].Race.Units[1];
            Position BeforeGoing = UnitToMove.Position;
            double PointsBeforeMove = UnitToMove.MovePoints;
            double PointsNeeded = UnitToMove.getMoveCost(WhereToGo);

            // Move the unit
            MoveCommand mvc = new MoveCommand(UnitToMove, WhereToGo);
            mvc.execute();

            Assert.IsFalse(UnitToMove.Position.Equals(BeforeGoing));
            Assert.AreNotEqual(PointsBeforeMove, UnitToMove.MovePoints);
            Assert.IsTrue(UnitToMove.Position.Equals(WhereToGo));
            Assert.AreEqual(PointsBeforeMove - PointsNeeded, UnitToMove.MovePoints);

            // Undo the move
            mvc.undo();

            Assert.IsTrue(UnitToMove.Position.Equals(BeforeGoing));
            Assert.AreEqual(PointsBeforeMove, UnitToMove.MovePoints);
            Assert.IsFalse(UnitToMove.Position.Equals(WhereToGo));
            Assert.AreNotEqual(PointsBeforeMove - PointsNeeded, UnitToMove.MovePoints);

            // Redo the move
            mvc.redo();

            Assert.IsFalse(UnitToMove.Position.Equals(BeforeGoing));
            Assert.AreNotEqual(PointsBeforeMove, UnitToMove.MovePoints);
            Assert.IsTrue(UnitToMove.Position.Equals(WhereToGo));
            Assert.AreEqual(PointsBeforeMove - PointsNeeded, UnitToMove.MovePoints);
        }
    }
}
