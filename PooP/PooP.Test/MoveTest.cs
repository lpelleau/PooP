﻿using System;
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
            // Forest
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[1].getMoveCost(new Position(8, 4)) == 1);
            // Plain
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[0].getMoveCost(new Position(12, 7)) == 1);

            // Water -> Infinite since impossible
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[1].getMoveCost(new Position(8, 6)) == Int16.MaxValue / 2);
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
            // Mountain
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(4, 6)) == 1);
            // Forest
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[3].getMoveCost(new Position(3, 10)) == 1);

            // Water -> Infinite since impossible
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(5, 5)) == Int16.MaxValue / 2);

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
            // Water
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(5, 5)) == 1);
            // Mountain
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(4, 6)) == 1);
            // Plain
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[2].getMoveCost(new Position(8, 2)) == 1);
            // Forest
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[3].getMoveCost(new Position(3, 10)) == 1);
        }

        /// <summary>
        /// Tests the move cost for a distant tile
        /// </summary>
        [TestMethod]
        public void DistantTile()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");

            // To move to a distant tile, this orc must spend 1.5pts
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[3].getMoveCost(new Position(4,10)) == 1.5);
        }

        /// <summary>
        /// A unit can't move to an occupied tile
        /// </summary>
        [TestMethod]
        public void MoveToOccupied()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");

            // The unit has enough move points to move to this tile
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(4, 7)) <= GameBuilder.CURRENTGAME.Players[0].Race.Units[1].MovePoints);
        }

        /// <summary>
        /// A unit can't move too far
        /// </summary>
        [TestMethod]
        public void MoveToTooFar()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");

            // The unit hasn't enough move points to move to this tile
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getMoveCost(new Position(4, 2)) > GameBuilder.CURRENTGAME.Players[0].Race.Units[1].MovePoints);
        }
    }
}
