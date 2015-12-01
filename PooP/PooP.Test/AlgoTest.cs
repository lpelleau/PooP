using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using System;

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
                    try
                    {
                        n[(int)map.Tiles[i * SIZE + j]]++;
                    }
                    catch (Exception e)
                    {
                        Console.Write(i + " " + j);
                    }
                }
            }

            Assert.IsTrue(n[(int)TileType.Plain] == 25);
            Assert.IsTrue(n[(int)TileType.Mountain] ==  25);
            Assert.IsTrue(n[(int)TileType.Forest] == 25);
            Assert.IsTrue(n[(int)TileType.Water] == 25);
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

            Assert.IsTrue(players[0] != players[2] && players[1] != players[3]);
            Assert.IsTrue(Math.Sqrt(Math.Pow(players[0] - players[2], 2) + Math.Pow(players[1] - players[3], 2)) >= 8);
        }
    }
}

