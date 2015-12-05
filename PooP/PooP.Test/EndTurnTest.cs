using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Implementation.Commands;
using PooP.Core.Ressource;

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
            Assert.AreEqual(GameBuilder.CURRENTGAME.NumberOfTurns, nt - 1);
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
            GameSave.INSTANCE.load("../../Test_files/tester1");

            // Adding some useless command to the stack
            new MoveCommand(GameBuilder.CURRENTGAME.FirstPlayer.Race.Units[0], new Position(0, 8));
            new AttackCommand(GameBuilder.CURRENTGAME.FirstPlayer.Race.Units[2], new Position(8, 5));
            
            // Ending the turn
            new EndTurn().execute();
            Assert.AreEqual(0, UndoableImpl.DoneCommands.Count);
            Assert.AreEqual(0, UndoableImpl.UndoneCommands.Count);
        }

        /// <summary>
        /// Checks that ending a turn adds move points to the player that will play
        /// </summary>
        [TestMethod]
        public void ReinitsMovePoints()
        {
            new EndTurn().execute();
            Assert.IsTrue(GameBuilder.CURRENTGAME.FirstPlayer.Race.Units.TrueForAll(u => u.MovePoints == 2));
        }

        /// <summary>
        /// Checks that the game ends if there is 0 turns
        /// </summary>
        [TestMethod]
        public void EndsGameIfZeroTurns()
        {
            throw new NotImplementedException();
            
            // Load the correct file

            new EndTurn().execute();

            Assert.IsNotNull(EndTurn.winner);

            // Checks that the given winner is correct
        }
    }
}
