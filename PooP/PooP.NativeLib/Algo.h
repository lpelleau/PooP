#pragma once

enum TileType {
	Plain = 0,
	Mountain = 1,
	Forest = 2,
	Water = 3
};

class Algo {
private:
	bool generationOk(int *nbTiles);

public:
	Algo() {}
	~Algo() {}

	// You can change the return type and the parameters according to your needs.
	void fillMap(TileType map[], int size);
	void bestMoves();
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_fillMap(Algo* algo, TileType map[], int size) {
	return algo->fillMap(map, size);
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