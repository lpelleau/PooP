using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using PooP.Wrapper;

namespace PooP.Test
{
    private static int SIZE = 10;

    /// <summary>
    /// Tests the C++ algorithmes
    /// </summary>
    [TestClass]
    public class AlgoTest
    {
        /// <summary>
        /// Test the map generation
        /// (Same number of tile for each types)
        /// </summary>
        [TestMethod]
        public void MapGenerationTest()
        {
            Algo alg = Algo.INSTANCE;
            WMap[] map = alg.CreateMap(SIZE * SIZE);
            int[] n = new int[] { 0 };

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    n[map[i * 10 + j]]++;
                }
            }

            Assert.IsTrue(n[Plain] == n[Mountain] == n[Forest] == n[Water]);
        }
        /// <summary>
        /// Test the placement of the players
        /// (they should not be on the same tile)
        /// </summary>
        [TestMethod]
        public void PlayersPlacementTest()
        {
            Algo alg = Algo.INSTANCE;
            int[] players = alg.PlacePlayers(SIZE * SIZE);

            Assert.IsTrue(players[0] != players[2] && players[1] != players[3]);
        }
    }
}

