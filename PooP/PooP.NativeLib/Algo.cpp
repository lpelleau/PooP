#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>

void Algo::fillMap(TileType map[], int size)
{
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

		int pos = x * height + y;
		if (map[pos] != Plain)
			continue;
		map[pos] = Mountain; // Add the tile on the map
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

		int pos = x * height + y;
		if (map[pos] != Plain)
			continue;
		map[pos] = Forest; // Add the tile on the map
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

		int pos = x * height + y;
		if (map[pos] != Plain)
			continue;
		map[pos] = Water; // Add the tile on the map
		nbTiles[Water]++;
		nbTiles[Plain]--;

		// Generate other tiles of the same type around
		int added = generateNext(map, height, Water, x, y, nbTiles[Water] - obj);
		nbTiles[Water] += added;
		nbTiles[Plain] -= added;
	}

	_map = map;
}

int Algo::generateNext(TileType map[], int h, TileType type, int x, int y, int remain) {
	int remainB = remain;
	int size = h * h;

	int pos = (x - 1) * h + y; // West
	remain -= generateNextInner(map, size, type, pos, remain);

	pos = (x + 1) * h + y; // East
	remain -= generateNextInner(map, size, type, pos, remain);

	pos = x * h + (y - 1); // South
	remain -= generateNextInner(map, size, type, pos, remain);

	pos = x * h + (y + 1); // North
	remain -= generateNextInner(map, size, type, pos, remain);

	return remainB - remain;
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

void Algo::placePlayers(int players[], int size) {
	int height = sqrt(size); // Height of the map

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
	} while (res < 0 || res >= size || players[3] + move < 0);
	players[3] += move; // Randomly move near the opposite
}

void Algo::bestMoves(int size, Race race, int units[], int nbUnits, int moves[])
{
	// TODO: Orc spend 0.5 move points to move on plain tile
	// TODO: Elf spend 2 move points to move on mountain tile

	int height = sqrt(size);
	int victoryPoints[3] { -1 }; // Nb victory points for the best tiles

	for (int i = 0; i < nbUnits * 2; i += 2){ // For all player units
		int x = units[i], y = units[i + 1]; // Unit coordinates

		// All tiles around (2 of distance) the one where is the unit
		for (int j = 0; j < 5; j++) {
			for (int k = 0; k < 5; k++) {
				if (x - j >= 0 && x + j < height && y - k >= 0 && y + k < height) { // Tile on the map
					if (abs(x - j) + abs(y - k) <= 2) { // Distance <= 2

						// Calculate best moves based on victory points
						int points;
						bool movePossible = true;
						switch (race) {
						case Human:
							switch (_map[j * height + k]){
							case Plain:
								points = 2;
								break;
							case Mountain:
								points = 1;
								break;
							case Forest:
								points = 1;
								break;
							case Water:
								points = 0;
								break;
							}
							break;
						case Orc:
							switch (_map[j * height + k]){
							case Plain:
								points = 1;
								break;
							case Mountain:
								points = 2;
								break;
							case Forest:
								points = 1;
								break;
							case Water:
								movePossible = false;
								break;
							}
							break;
						case Elf:
							switch (_map[j * height + k]){
							case Plain:
								points = 1;
								break;
							case Mountain:
								points = 0;
								break;
							case Forest:
								points = 3;
								break;
							case Water:
								movePossible = false;
								break;
							}
							break;
						}

						if (movePossible) {
							// Change best moves
							for (int m = 0; m < 3; m++) {
								if (victoryPoints[m] < points) {
									moves[m * 2] = j;
									moves[m * 2 + 1] = k;
									break;
								}
							}
						}
					}
				}
			}
		}
	}
}