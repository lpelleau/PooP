#pragma once

#define NB_TILES 4
#define NB_RACES 3

#define STEP_GEN 1

/* Types of the differents tiles */
enum TileType {
	Plain = 0,
	Mountain = 1,
	Forest = 2,
	Water = 3
};

/* Types of the differents races */
enum Race {
	Human = 0,
	Orc = 1,
	Elf = 2
};

class Algo {
private:
	TileType** _map;			// Map of the current game
	int _nbTiles;				// Number of tiles on the map
	int _height;				// Height of the map
	int _objTiles;				// Number of tiles per types of tile (goal)
	int _tilesOnMap[NB_TILES];	// Number of tiles per types of tile (real)

	void initVars(int size);

	int labelize(int *zones, int x, int y, int cpt);
	int getDryZones();

	void generatePlains();
	void generateLakes();
	void generateMountain();
	void generateForest();

	void generateRec(TileType type, int x, int y, int step);

	void placeP1(int *x, int *y);
	void placeP2(int *x, int *y);

	double moveCostFromTile(Race race, int x, int y, int life, int enemies[], int nbEnemies);
	double moveCost(Race race, int xS, int yS, int xT, int yT, int life, int enemies[], int nbEnemies);

public:
	Algo() {}
	~Algo() {}

	void init(TileType map[], int size);
	void fillMap(TileType map[], int size);
	void placePlayers(int players[]);
	void bestMoves(Race race, int units[], int nbUnits, int life[], int enemies[], int nbEnemies, int moves[]);
};

#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_init(Algo* algo, TileType map[], int size) {
	return algo->init(map, size);
}

EXPORTCDECL void Algo_fillMap(Algo* algo, TileType map[], int size) {
	return algo->fillMap(map, size);
}

EXPORTCDECL void Algo_placePlayers(Algo* algo, int players[]) {
	return algo->placePlayers(players);
}

EXPORTCDECL void Algo_bestMoves(Algo* algo, Race race, int units[], int nbUnits, int life[], int enemies[], int nbEnemies, int moves[]) {
	return algo->bestMoves(race, units, nbUnits, life, enemies, nbEnemies, moves);
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}
