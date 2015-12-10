#ifdef _DEBUG
#include "Algo.h"
//#include "../PooP.NativeLib.Test/Algo.h"
#else
#include "Algo.h"
#endif

#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h>
#include <vector>

using namespace std;

/***
* @Description Destructor
**/
Algo::~Algo(void) {
	for (int i = 0; i < _height; i++) {
		delete _map[i];
	}
	delete _map;
}

/**
* @Description Initialize class attributes with the size of the map
* @Param size - Size of the map (number of tiles)
**/
void Algo::initVars(int size) {
	srand(time(NULL));

	_nbTiles = size;
	_height = sqrt(_nbTiles);
	_objTiles = _nbTiles / NB_TILES;

	_map = new TileType*[_height];
	for (int i = 0; i < _height; i++) {
		_map[i] = new TileType[_height];
	}
}

/**
* @Description Initialize the map of the class with a map already generated
* @Param map - Map generated
* @Param size - Size of the map (number of tiles)
**/
void Algo::init(TileType map[], int size) {
	initVars(size);

	for (int i = 0; i < _height; i++) {
		for (int j = 0; j < _height; j++) {
			_map[i][j] = map[i * _height + j];
		}
	}
}

/**
* @Description Initialize the map of the class with an algorithme
* and return it
* @Param map - Map to be generated
* @Param size - Size of the map (number of tiles)
**/
void Algo::fillMap(TileType map[], int size)
{
	initVars(size);

	do {
		for (int i = 0; i < NB_TILES; i++) {
			_tilesOnMap[i] = 0;
		}

		generatePlains();
		generateLakes();
		generateMountain();
		generateForest();

		for (int i = 0; i < _height; i++) {
			for (int j = 0; j < _height; j++) {
				map[i * _height + j] = _map[i][j];
			}
		}
	} while (getDryZones() > 1);
}

/**
 * @Description Labelize a zone with a certain label
 * @return The number of tiles labelized
 **/
int Algo::labelize(int zones[], int x, int y, int cpt){
	int nbLab = 1;

	zones[x * _height + y] = cpt;
	// If there is one, label the left tile
	if (x - 1 >= 0 && zones[(x - 1) * _height + y] == 0) nbLab += labelize(zones, x - 1, y, cpt);
	// If there is one, label the upper tile
	if (y - 1 >= 0 && zones[x * _height + y - 1] == 0) nbLab += labelize(zones, x, y - 1, cpt);
	// If there is one, label the right tile
	if (x + 1 < _height && zones[(x + 1) * _height + y] == 0) nbLab += labelize(zones, x + 1, y, cpt);
	// If there is one, label the down tile
	if (y + 1 < _height && zones[x * _height + y + 1] == 0) nbLab += labelize(zones, x, y + 1, cpt);
	return nbLab;
}

/**
 * @Description Finds how many dry zones there are in the map
 * @return The number of distinct dry zones
 **/
int Algo::getDryZones(){
	int *zones = new int[_nbTiles];
	int firstNonWaterX, firstNonWaterY;
	int labelled = 0;
	int cpt = 1;
	// Label all the water
	for (int x = 0; x < _height; x++) {
		for (int y = 0; y < _height; y++) {
			if (_map[x][y] == Water) {
				zones[x * _height + y] = -1;
				labelled++;
			}
			else zones[x * _height + y] = 0;
		}
	}
	// While there is at least one tile that is not labelled
	while (labelled < _nbTiles){
		// Find the first non-labelled tile
		for (int x = 0; x < _height; x++){
			for (int y = 0; y < _height; y++){
				if (zones[x * _height + y] == 0) {
					firstNonWaterX = x;
					firstNonWaterY = y;
					break;
				}
			}
		}
		// Begin with this tile and label its zone
		labelled += labelize(zones, firstNonWaterX, firstNonWaterY, cpt);
		// Begin a new zone
		cpt++;
	}

	delete zones;

	return cpt - 1;
}

/**
* @Description Fill the map with Plain tiles
**/
void Algo::generatePlains() {
	for (int i = 0; i < _height; i++) {
		for (int j = 0; j < _height; j++) {
			_map[i][j] = Plain;
			_tilesOnMap[Plain]++;
		}
	}
}

/**
* @Description Generate lakes in the map
**/
void Algo::generateLakes() {
	while (_tilesOnMap[Water] < _objTiles) {
		generateRec(Water, rand() % _height, rand() % _height, 1);
	}
}

/**
* @Description Generate a group of tiles from a central point
* @Param type - Type of tile
* @Param x - X coordinate
* @Param y - Y coordinate
* @Param step - Level of recursion : higher mean less chance to generate recursion
**/
void Algo::generateRec(TileType type, int x, int y, int step) {
	step += STEP_GEN;

	if ((_tilesOnMap[type] < _objTiles) && (_map[x][y] == Plain) && ((rand() % step) == 0)) {
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

/**
* @Description Generate Mountains in the map
**/
void Algo::generateMountain() {
	while (_tilesOnMap[Mountain] < _objTiles) {
		generateRec(Mountain, rand() % _height, rand() % _height, 1);
	}
}

/**
* @Description Generate Forests in the map
**/
void Algo::generateForest() {
	while (_tilesOnMap[Forest] < _objTiles) {
		generateRec(Forest, rand() % _height, rand() % _height, 1);
	}
}

/**
* @Description Place the two players on the map, the can't be on a Water tile
* @Param players - Array of players
**/
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

/**
* @Description Place the first player near of a border
* @Param *x - X position
* @Param *y - Y position
**/
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

/**
* @Description Place the second player at the opposite of the first player modulo one tile
* @Param *x - X position
* @Param *y - Y position
**/
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

double Algo::moveCostFromTile(Race race, int y, int x, int life, int enemies[], int nbEnemies)
{
	double res = 0;

	if (life < 5)
		for (int i = 0; i < nbEnemies * 2; i++)
			if (enemies[i] == x && enemies[i + 1] == y)
				return DBL_MAX / 100;

	if (race != Human && _map[x][y] == Water)
		return DBL_MAX / 100;
	else if (race == Elf && _map[x][y] == Mountain)
		return 2;
	else if (race == Orc && _map[x][y] == Plain)
		return 0.5;
	return 1;
}

double Algo::moveCost(Race race, int xS, int yS, int xT, int yT, int life, int enemies[], int nbEnemies)
{
	double totalCost = 0;
	// Moving on Y axis
	if (xS == xT)
		// Moving forward on Y axis
		if (yS < yT)
			for (int i = yS + 1; i <= yT; i++)
				totalCost += moveCostFromTile(race, xT, i, life, enemies, nbEnemies);
	// Moving backward on Y axis
		else
			for (int i = yS - 1; i >= yT; i--)
				totalCost += moveCostFromTile(race, xT, i, life, enemies, nbEnemies);

	// Moving on X axis
	else if (yS == yT)
		// Moving forward on X axis
		if (xS < xT)
			for (int i = xS + 1; i <= xT; i++)
				totalCost += moveCostFromTile(race, i, yT, life, enemies, nbEnemies);
	// Moving backward on X axis
		else
			for (int i = xS - 1; i >= xT; i--)
				totalCost += moveCostFromTile(race, i, yT, life, enemies, nbEnemies);

	// Find the correct path
	else
	{
		// Try moving to another tile and test
		vector<double> possibleCosts = vector<double>();
		int TestedPaths[4 * 2] = { xS + 1, yS,
			xS, yS + 1,
			xS - 1, yS,
			xS, yS - 1 };

		if (xS < xT && yS < yT)
		{
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[0], TestedPaths[1], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[0], TestedPaths[1], xT, yT, life, enemies, nbEnemies));
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[2], TestedPaths[3], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[2], TestedPaths[3], xT, yT, life, enemies, nbEnemies));
		}
		else if (xS < xT && yS > yT)
		{
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[0], TestedPaths[1], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[0], TestedPaths[1], xT, yT, life, enemies, nbEnemies));
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[6], TestedPaths[7], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[6], TestedPaths[7], xT, yT, life, enemies, nbEnemies));
		}
		else if (xS > xT && yS > yT)
		{
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[4], TestedPaths[5], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[4], TestedPaths[5], xT, yT, life, enemies, nbEnemies));
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[6], TestedPaths[7], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[6], TestedPaths[7], xT, yT, life, enemies, nbEnemies));
		}
		else
		{
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[2], TestedPaths[3], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[2], TestedPaths[3], xT, yT, life, enemies, nbEnemies));
			possibleCosts.push_back(moveCost(race, xS, yS, TestedPaths[4], TestedPaths[5], life, enemies, nbEnemies)
				+ moveCost(race, TestedPaths[4], TestedPaths[5], xT, yT, life, enemies, nbEnemies));
		}

		totalCost += *min_element(possibleCosts.begin(), possibleCosts.end());
	}
	return totalCost;
}

void Algo::bestMoves(Race race, int units[], double mvPts[], int nbUnits, int life[], int enemies[], int nbEnemies, int moves[])
{
	int* victoryPoints = new int[_nbTiles * 2];  // Nb victory points for the best tiles
	for (int i = 0; i < _nbTiles * 2; i++) victoryPoints[i] = -1;

	for (int i = 0; i < nbUnits * 2; i += 2){ // For all player units
		int x = units[i], y = units[i + 1]; // Unit coordinates

		// All tiles around (2 of distance) the one where is the unit
		for (int j = fmax(0, x - 3); j < fmin(x + 3, _height - 1); j++) {
			for (int k = fmax(0, y - (3-abs(x-j))); k < fmin(y + (3-abs(x-j)), _height - 1); k++) {
				int points = 0;
				double mvpoints = moveCost(race, x, y, j, k, life[i / 2], enemies, nbEnemies);

				// Calculate best moves based on victory points
				switch (race) {
				case Human:
					switch (_map[k][j]){
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
					switch (_map[k][j]){
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
						points = -1;
						break;
					}
					break;
				case Elf:
					switch (_map[k][j]){
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
						points = -1;
						break;
					}
					break;
				}


				if (mvpoints <= mvPts[i]) {
					// Change best moves
					for (int m = 0; m < 3; m++) {
						// If this is the same value, 1/2 chance of changing it
						if (victoryPoints[m] < points && moves[m * 2] != j && moves[m * 2 + 1] != k) {
							moves[m * 2] = j;
							moves[m * 2 + 1] = k;
							victoryPoints[m] = points;
							break;
						}
						else if (victoryPoints[m] == points && moves[m * 2] != j && moves[m * 2 + 1] != k &&
							rand() % 2) {
							moves[m * 2] = j;
							moves[m * 2 + 1] = k;
							victoryPoints[m] = points;
							break;
						}
					}
				}
			}
		}
	}

	delete victoryPoints;
}