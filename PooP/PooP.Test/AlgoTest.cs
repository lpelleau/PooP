using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using System;
using System.Collections.Generic;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Games;

namespace PooP.Test
{
    /// <summary>
    /// Tests the C++ algorithmes
    /// </summary>
    [TestClass]
    public class AlgoTest
    {
        private static int SIZE = 10;

        /// <summary>
        /// Test the map generation
        /// (Same number of tile for each types)
        /// </summary>
        [TestMethod]
        public void MapGenerationTest()
        {
            Algo alg = Algo.INSTANCE;
            WMap map = alg.CreateMap(SIZE * SIZE);
            int[] n = new int[4] { 0, 0, 0, 0 };

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    n[(int)map.Tiles[i * SIZE + j]]++;
                }
            }

            Assert.AreEqual(SIZE * SIZE / 4, n[(int)TileType.Plain]);
            Assert.AreEqual(SIZE * SIZE / 4, n[(int)TileType.Mountain]);
            Assert.AreEqual(SIZE * SIZE / 4, n[(int)TileType.Forest]);
            Assert.AreEqual(SIZE * SIZE / 4, n[(int)TileType.Water]);
        }
        /// <summary>
        /// Test the placement of the players
        /// (they should not be on the same tile and be at a distanec of 8 minimum)
        /// </summary>
        [TestMethod]
        public void PlayersPlacementTest()
        {
            string[] nplayers = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("small").createGame(nplayers, races);
            Algo alg = Algo.INSTANCE;
            int[] players = alg.PlacePlayers(SIZE * SIZE);
            Assert.IsTrue(Math.Sqrt(Math.Pow(players[0] - players[2], 2) + Math.Pow(players[1] - players[3], 2)) >= SIZE - 2*2);
        }

        /// <summary>
        /// Test the best moves finder
        /// </summary>
        [TestMethod]
        public void BestMovesTest()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");
            int[] moves = GameBuilder.CURRENTGAME.getBestMoves();
            Position[] expectedPositions = { new Position(1,8),
                                             new Position(3,6), 
                                             new Position(4,6), 
                                             new Position(4,3), 
                                             new Position(4,4), 
                                             new Position(8,1), 
                                             new Position(8,3), 
                                             new Position(8,5), 
                                             new Position(9,3), 
                                             new Position(10,3) };

            for (int i = 0; i < 3; i++)
            {
                bool contains = false;
                Position givenPosition = new Position(moves[i*2], moves[i*2+1]);
                for (int j = 0; j < expectedPositions.Length && !contains; j++)
                    if (expectedPositions[j].Equals(givenPosition)) contains = true;
                Assert.IsTrue(contains);
            }
        }
    }
}

