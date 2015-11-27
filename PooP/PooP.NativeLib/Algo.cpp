#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>

void Algo::fillMap(TileType map[], int size, int players[])
{
	//TODO : init map tiles with a better algorithm
	// A map should have the same  number of the differents types of tile
	// Place the units too

	int height = sqrt(size); // Height of the map
	int obj = size / 4; // Objectif for the number of each tiles
	int nbTiles[4] { 0 };
	for (int i = 0; i < size; i++) { // Init the map to full plain
		map[i] = Plain;
		nbTiles[Plain]++;
	}

	srand(time(NULL)); // Random init

	// Fit Mountain
	while (nbTiles[Mountain] != obj) {
		int x = rand() % height; // Calculate center point
		int y = rand() % height;

		map[x * height + y] = Mountain; // Add the tile on the map
		nbTiles[Mountain]++;
		nbTiles[Plain]--;

		// Generate other tiles of the same type 
		int added = generateNext(map, height, Mountain, x, y, nbTiles[Mountain] - obj);;
		nbTiles[Mountain] += added;
		nbTiles[Plain] -= added;
	}

	// Fit Forest
	while (nbTiles[Forest] != obj) {
		int x = rand() % height; // Calculate center point
		int y = rand() % height;

		map[x * height + y] = Forest; // Add the tile on the map
		nbTiles[Forest]++;
		nbTiles[Plain]--;

		// Generate other tiles of the same type around
		int added = generateNext(map, height, Forest, x, y, nbTiles[Forest] - obj);
		nbTiles[Forest] += added;
		nbTiles[Plain] -= added;
	}

	// Fit Water
	while (nbTiles[Water] != obj) {
		int x = rand() % height; // Calculate center point
		int y = rand() % height;

		map[x * height + y] = Water; // Add the tile on the map
		nbTiles[Water]++;
		nbTiles[Plain]--;

		// Generate other tiles of the same type around
		int added = generateNext(map, height, Water, x, y, nbTiles[Water] - obj);
		nbTiles[Water] += added;
		nbTiles[Plain] -= added;
	}

	// Players placement
	// P1
	int border = rand() % 4;

	switch (border) {
	case 0: // West
		players[0] = rand() % 2;
		players[1] = rand() % height;
		break;
	case 1: // East
		players[0] = rand() % 2 + height - 2;
		players[1] = rand() % height;
		break;
	case 2: // South
		players[0] = rand() % height;
		players[1] = rand() % 2 + height - 2;
		break;
	case 3: // North
		players[0] = rand() % height;
		players[1] = rand() % 2;
		break;
	}

	// P2
	players[2] = height - 1 - players[0];// Strict opposit of P1
	players[3] = height - 1 - players[1];
	int move, res;
	do {
		move = 1 - (rand() % 3);
		res = (players[2] + move) * height + players[3];
	} while (res < 0 || res >= size);
	players[2] += move; // Randomly move near the opposite
	do {
		move = 1 - (rand() % 3);
		res = players[2] * height + (players[3] + move);
	} while (res < 0 || res >= size);
	players[3] += move; // Randomly move near the opposite
}

int Algo::generateNext(TileType map[], int h, TileType type, int x, int y, int remain) {
	int tilesAdded = 0;
	int size = h * h;

	int pos = (x - 1) * h + y; // West
	tilesAdded += generateNextInner(map, size, type, pos, remain);

	pos = (x + 1) * h + y; // East
	tilesAdded += generateNextInner(map, size, type, pos, remain);

	pos = x * h + (y - 1); // South
	tilesAdded += generateNextInner(map, size, type, pos, remain);

	pos = x * h + (y + 1); // North
	tilesAdded += generateNextInner(map, size, type, pos, remain);
	return tilesAdded;
}

int Algo::generateNextInner(TileType map[], int size, TileType type, int pos, int remain) {
	if (pos >= 0 && pos < size && map[pos] == Plain) {
		if (remain > 0) {
			if (rand() % 2) {
				map[pos] = type;
				return 1;
			}
		}
	}
	return 0;
}

void Algo::bestMoves()
{

}