#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>
using namespace std;

void Algo::fillMap(TileType map[], int size)
{
	//TODO : init map tiles with a better algorithm
	// A map should have the same  number of the differents types of tile
	// Place the units too

	//for (int i = 0; i < size; i++) {
	//	map[i] = (TileType) (i % 4);
	//}

	int* nbTiles = new int[4]{0};
	for (int i = 0; i < size; i++) {
		map[i] = (TileType) Plain; // Init the map to plain
		nbTiles[Plain]++;
	}

	srand(time(NULL));

	while (generationOk(nbTiles)) {
		map[rand() % size] = (TileType)(rand() % 3 + 1);
	}

	delete nbTiles;
}

bool Algo::generationOk(int *nbTiles) {
	return nbTiles[Plain] == nbTiles[Forest] == nbTiles[Water] == nbTiles[Mountain];
}

void Algo::bestMoves()
{

}