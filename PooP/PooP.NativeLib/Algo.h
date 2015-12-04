#pragma once

#define NB_TILES 4
#define NB_RACES 3

#define STEP_LAKE_GEN 1

enum TileType {
	Plain = 0,
	Mountain = 1,
	Forest = 2,
	Water = 3
};

enum Race {
	Human = 0,
	Orc = 1,
	Elf = 2
};

class Algo {
private:
	TileType** _map;
	int _nbTiles;
	int _height;
	int _objTiles;
	int _tilesOnMap[NB_TILES];

	void initVars(int size);

	void generatePlains();
	void generateLakes();
	void generateMountain();
	void generateForest();

	void generateRec(TileType type, int x, int y, int step);

public:
	Algo() {}
	~Algo() {}

	void init(TileType map[], int size);
	void fillMap(TileType map[], int size);
	void placePlayers(int players[]);
	void bestMoves(Race race, int units[], int nbUnits, int moves[]);
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

EXPORTCDECL void Algo_placePlayers(Algo* algo, int players[], int size) {
	return algo->placePlayers(players, size);
}

EXPORTCDECL void Algo_bestMoves(Algo* algo, int size, Race race, int units[], int nbUnits, int moves[]) {
	return algo->bestMoves(size, race, units, nbUnits, moves);
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}
