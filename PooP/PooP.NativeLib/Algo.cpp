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
	int *x1 = &(players[0]);
	int *y1 = &(players[1]);
	int *x2 = &(players[2]);
	int *y2 = &(players[3]);

	do {
		placeP1(x1, y1);

		*x2 = _height - 1 - *x1;// Strict opposit of P1
		*y2 = _height - 1 - *y1;
		placeP2(x2, y2);
	} while (_map[*x1][*y1] == Water || _map[*x2][*y2] == Water);
}
void Algo::placeP1(int *x, int *y) {
	int border = rand() % 4;

	switch (border) {
	case 0: // West
		*x = rand() % 2;
		*y = rand() % _height;
		break;
	case 1: // East
		*x = rand() % 2 + _height - 2;
		*y = rand() % _height;
		break;
	case 2: // South
		*x = rand() % _height;
		*y = rand() % 2 + _height - 2;
		break;
	case 3: // North
		*x = rand() % _height;
		*y = rand() % 2;
		break;
	}
}
void Algo::placeP2(int *x, int *y) {
	int move, res;
	do {
		move = 1 - (rand() % 3);
		res = (*x + move) * _height + *y;
	} while (res < 0 || res >= _nbTiles);
	*x += move; // Randomly move near the opposite
	do {
		move = 1 - (rand() % 3);
		res = *x * _height + (*y + move);
	} while (res < 0 || res >= _nbTiles || *y + move < 0);
	*y += move; // Randomly move near the opposite
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