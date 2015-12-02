using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Implementation.Commands;

namespace PooP.Test
{
    [TestClass]
    public class EndTurnTest
    {
        [TestInitialize]
        public void init()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("standard").createGame(players, races);
        }

        /// <summary>
        /// Tests if the number of turns is actually decreased
        /// </summary>
        [TestMethod]
        public void DecreaseTurns()
        {
            int nt = GameBuilder.CURRENTGAME.NumberOfTurns;
            new EndTurn().execute();
            Assert.IsTrue(nt - 1 == GameBuilder.CURRENTGAME.NumberOfTurns);
        }

        /// <summary>
        /// Checks that there is not any winner (the turn has been ended without doing anything)
        /// </summary>
        [TestMethod]
        public void NoWinner()
        {
            new EndTurn().execute();
            Assert.IsNull(EndTurn.winner);
        }

        /// <summary>
        /// Tests if the turn can be ended
        /// </summary>
        [TestMethod]
        public void CanEndTurn()
        {
            Assert.IsTrue(new EndTurn().canDo());
        }

        [TestMethod]
        public void ClearsCommands()
        {
            // TO DO : Add commands to the stack
            new EndTurn().execute();
            Assert.IsTrue(UndoableImpl.DoneCommands.Count == 0);
            Assert.IsTrue(UndoableImpl.UndoneCommands.Count == 0);
        }
    }
}
