using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Ressource;
using PooP.Core.Implementation.Commands;

namespace PooP.Test
{
    [TestClass]
    public class MoveTest
    {
        /// <summary>
        /// Tests the move costs for elves
        /// </summary>
        [TestMethod]
        public void ElvesMoveCost()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");

            // An elf must use 2 points to move to a mountain tile
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[1].getMoveCost(new Position(9, 5)) == 2);

            // An elf must use 1 points otherwise
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[1].getMoveCost(new Position(8, 4)) == 1);

            // An elf can't walk on water
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[1].Race.Units[1],(new Position(8, 4))).canDo());
        }

        /// <summary>
        /// Tests the move costs for orcs
        /// </summary>
        [TestMethod]
        public void OrcsMoveCost()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");

            // An orc must use 0.5 points to move to a plain tile
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(3, 5)) == 0.5);

            // An orc must use 1 points otherwise
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(4, 6)) == 1);

            // An orc can't walk on water
            Assert.IsFalse(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], (new Position(5, 5))).canDo());
        }

        /// <summary>
        /// Tests the move costs for humans
        /// </summary>
        [TestMethod]
        public void HumansMoveCost()
        {
            GameSave.INSTANCE.load("../../Test_files/tester2");
            new EndTurn().execute();

            // A human must use 1 points everytime
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(4, 6)) == 1);

            // A human can walk on water
            Assert.IsTrue(new MoveCommand(GameBuilder.CURRENTGAME.Players[0].Race.Units[1], (new Position(5, 5))).canDo());
        }
    }
}
