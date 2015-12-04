#pragma once

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
	TileType* _map;

	int generateNext(TileType map[], int h, TileType type, int x, int y, int remain);
	int generateNextInner(TileType map[], int sixe, TileType type, int pos, int remain);

public:
	Algo() {}
	~Algo() {}

	// You can change the return type and the parameters according to your needs.
	void init(TileType map[], int size);
	void fillMap(TileType map[], int size);
	void placePlayers(int players[], int size);
	void bestMoves(int size, Race race, int units[], int nbUnits, int moves[]);
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
