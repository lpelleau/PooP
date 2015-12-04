using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using System;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;

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
    }
}

