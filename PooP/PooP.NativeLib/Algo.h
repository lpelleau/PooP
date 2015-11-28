#pragma once

enum TileType {
	Plain = 0,
	Mountain = 1,
	Forest = 2,
	Water = 3
};

class Algo {
private:
	int generateNext(TileType map[], int h, TileType type, int x, int y, int remain);
	int generateNextInner(TileType map[], int sixe, TileType type, int pos, int remain);

public:
	Algo() {}
	~Algo() {}

	// You can change the return type and the parameters according to your needs.
	void fillMap(TileType map[], int size);
	void placePlayers(int players[], int size);
	void bestMoves();
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_fillMap(Algo* algo, TileType map[], int size) {
	return algo->fillMap(map, size);
}

EXPORTCDECL void Algo_PlacePlayers(Algo* algo, int players[], int size) {
	return algo->placePlayers(players, size);
}

EXPORTCDECL void Algo_bestMoves(Algo* algo) {
	return algo->bestMoves();
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}
