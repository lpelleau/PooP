﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Ressource
{
    public class Algo : IDisposable
    {
        bool disposed = false;
        IntPtr nativeAlgo;

        public static Algo INSTANCE = new Algo();

        public void InitMap(TileType[] map, int nbTiles)
        {
            Algo_init(nativeAlgo, map, nbTiles);
        }

        public WMap CreateMap(int nbTiles)
        {
            var tiles = new TileType[nbTiles];
            Algo_fillMap(nativeAlgo, tiles, nbTiles);
            return new WMap(tiles);
        }

        public int[] PlacePlayers(int nbTiles)
        {
            var players = new int[4];
            Algo_placePlayers(nativeAlgo, players, nbTiles);
            return players;
        }

        public int[] BestMoves(int nbMoves, WRace race, int[] units, double[] mvPts, int nbUnits, int[] life, int[] enemies, int nbEnemies)
        {
            var moves = new int[nbMoves*2];
            Algo_bestMoves(nativeAlgo, race, units, mvPts, nbUnits, life, enemies, nbEnemies, moves);
            return moves;
        }

        private Algo()
        {
            nativeAlgo = Algo_new();
        }

        ~Algo()
        {
            Dispose(false);
            Algo_delete(nativeAlgo);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                Algo_delete(nativeAlgo);
            }
            disposed = true;
        }


        [DllImport("PooP.NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_init(IntPtr algo, TileType[] map, int nbTiles);

        [DllImport("PooP.NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

        [DllImport("PooP.NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_placePlayers(IntPtr algo, int[] players, int nbTiles);

        [DllImport("PooP.NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_bestMoves(IntPtr algo, WRace race, int[] units, double[] mvPts, int nbUnits, int[] life, int[] enemies, int nbEnemies, int[] moves);

        [DllImport("PooP.NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("PooP.NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);
    }
}
