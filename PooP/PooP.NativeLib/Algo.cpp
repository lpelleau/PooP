#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>

void Algo::initVars(int size) {
	_nbTiles = size;
	_height = sqrt(_nbTiles);
	_objTiles = _nbTiles / NB_TILES;

	_map = new TileType*[_height];
	for (int i = 0; i < _height; i++) {
		_map[i] = new TileType[_height];
	}
}

void Algo::init(TileType map[], int size) {
	initVars(size);

	for (int i = 0; i < _height; i++) {
		for (int j = 0; j < _height; j++) {
			_map[i][j] = map[i * _height + j];
		}
	}
}

void Algo::fillMap(TileType map[], int size)
{
	srand(time(NULL));

	initVars(size);

	generatePlains();
	generateLakes();
	generateMountain();
	generateForest();

	for (int i = 0; i < _height; i++) {
		for (int j = 0; j < _height; j++) {
			map[i * _height + j] = _map[i][j];
		}
	}
}

void Algo::generatePlains() {
	for (int i = 0; i < _height; i++) {
		for (int j = 0; j < _height; j++) {
			_map[i][j] = Plain;
			_tilesOnMap[Plain]++;
		}
	}
}

void Algo::generateLakes() {
	while (_tilesOnMap[Water] < _objTiles) {
		generateRec(Water, rand() % _height, rand() % _height, 1);
	}
}

void Algo::generateRec(TileType type, int x, int y, int step) {
	step += STEP_LAKE_GEN;

	if ((_tilesOnMap[type] < _objTiles) && (_map[x][y] == Plain) && ((rand() % step) == (step - 1))) {
		_map[x][y] = type;
		_tilesOnMap[type]++;

		if ((x - 1) >= 0) {
			generateRec(type, x - 1, y, step);
		}
		if ((x + 1) < _height) {
			generateRec(type, x + 1, y, step);
		}
		if ((y - 1) >= 0) {
			generateRec(type, x, y - 1, step);
		}
		if ((y + 1) < _height) {
			generateRec(type, x, y + 1, step);
		}
	}
}

void Algo::generateMountain() {
	while (_tilesOnMap[Mountain] < _objTiles) {
		generateRec(Mountain, rand() % _height, rand() % _height, 1);
	}
}

void Algo::generateForest() {
	while (_tilesOnMap[Forest] < _objTiles) {
		generateRec(Forest, rand() % _height, rand() % _height, 1);
	}
}

void Algo::placePlayers(int players[]) {
	do {
		// Players placement
		// P1
		int border = rand() % 4;

		switch (border) {
		case 0: // West
			players[0] = rand() % 2;
			players[1] = rand() % _height;
			break;
		case 1: // East
			players[0] = rand() % 2 + _height - 2;
			players[1] = rand() % _height;
			break;
		case 2: // South
			players[0] = rand() % _height;
			players[1] = rand() % 2 + _height - 2;
			break;
		case 3: // North
			players[0] = rand() % _height;
			players[1] = rand() % 2;
			break;
		}

		// P2
		players[2] = _height - 1 - players[0];// Strict opposit of P1
		players[3] = _height - 1 - players[1];
		int move, res;
		do {
			move = 1 - (rand() % 3);
			res = (players[2] + move) * _height + players[3];
		} while (res < 0 || res >= _nbTiles);
		players[2] += move; // Randomly move near the opposite
		do {
			move = 1 - (rand() % 3);
			res = players[2] * _height + (players[3] + move);
		} while (res < 0 || res >= _nbTiles || players[3] + move < 0);
		players[3] += move; // Randomly move near the opposite
	} while (_map[players[0]][players[1]] != Water && _map[players[2]][players[3]] != Water);
}

void Algo::bestMoves(Race race, int units[], int nbUnits, int moves[])
{
	int victoryPoints[3] { -1 }; // Nb victory points for the best tiles

	for (int i = 0; i < nbUnits * 2; i += 2){ // For all player units
		int x = units[i], y = units[i + 1]; // Unit coordinates

		// All tiles around (2 of distance) the one where is the unit
		for (int j = 0; j < _height; j++) {
			for (int k = 0; k < _height; k++) {
				if (x - j >= 0 && x + j < _height && y - k >= 0 && y + k < _height) { // Tile on the map
					int points;
					bool movePossible = true;

					if (race == Orc && _map[j][k] == Plain) {
						points = 1;
					}
					else if (abs(x - j) + abs(y - k) <= 2) { // Distance <= 2
						// Calculate best moves based on victory points
						switch (race) {
						case Human:
							switch (_map[j][k]){
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
							switch (_map[j][k]){
							case Plain: // Useless case
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
							switch (_map[j][k]){
							case Plain:
								points = 1;
								break;
							case Mountain:
								if (abs(x - j) + abs(y - k) <= 1) {
									movePossible = false;
								}
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
					}

					if (movePossible) {
						// Change best moves
						for (int m = 0; m < 3; m++) {
							if (victoryPoints[m] < points && moves[m * 2] != j && moves[m * 2 + 1] != k) {
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