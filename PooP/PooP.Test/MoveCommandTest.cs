using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Implementation.Commands;
using PooP.Core.Ressource;

namespace PooP.Test
{
    [TestClass]
    public class MoveCommandTest
    {
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
        }

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

        [TestMethod]
        public void MovesTheUnit()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DecreasesMovePoints()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void UndoMove()
        {
            throw new NotImplementedException();
        }


        [TestMethod]
        public void RedoMove()
        {
            throw new NotImplementedException();
        }
    }
}
