using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using System;
using System.Collections.Generic;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Games;
using PooP.Core.Ressource;

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
            Player[] p = GameBuilder.CURRENTGAME.Players;

            List<Unit>.Enumerator e = p[0].Race.Units.GetEnumerator();
            int nbUnits = p[0].Race.Units.Count;
            int[] units = new int[nbUnits * 2];
            int[] life = new int[nbUnits];
            for (int i = 0; i  < nbUnits; i++)
            {
                e.MoveNext();
                units[i * 2] = e.Current.Position.XPosition;
                units[i * 2 + 1] = e.Current.Position.YPosition;
                life[i] = e.Current.LifePoints;
            }

            e = p[1].Race.Units.GetEnumerator();
            int nbEnemies = p[1].Race.Units.Count;
            int[] enemies = new int[nbEnemies * 2];
            for (int i = 0; i < nbEnemies; i++)
            {
                e.MoveNext();
                enemies[i * 2] = e.Current.Position.XPosition;
                enemies[i * 2 + 1] = e.Current.Position.YPosition;
            }

            Algo alg = Algo.INSTANCE;
            int[] moves = alg.BestMoves(14 * 14, WRace.Orc, units, nbUnits, life, enemies, nbEnemies);
            int[] expectedMoves = new int[6] { 6, 5, 6, 6, 6, 7 }; // Real expected value here...

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(moves[i * 2] == expectedMoves[i * 2]); 
                Assert.IsTrue(moves[i * 2 + 1] == expectedMoves[i * 2 + 1]);
            }
        }
    }
}

