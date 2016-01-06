#include <cstdio>
#include <cstdlib>
#include <iostream>
#include "Algo.h"
#include <time.h>
#include <math.h>

#define SIZE 196
#define NB_UNITS 5

using namespace std;

int main() {
	srand(time(NULL));
	int height = (int)sqrt(SIZE);

	Algo alg;
	TileType map[SIZE];
	int players[4] = { 0 };
	int moves[6] = { 0 };
	double mvPts[NB_UNITS] = { 2.0 };
	int units[NB_UNITS * 2];
	int life[NB_UNITS];
	int enemies[NB_UNITS * 2];

	for (int i = 0; i < NB_UNITS * 2; i += 2) {
		units[i] = rand() % height;
		units[i + 1] = rand() % height;
	}

	for (int i = 0; i < NB_UNITS; i++) {
		life[i] = rand() % 20;
	}

	for (int i = 0; i < NB_UNITS * 2; i += 2) {
		enemies[i] = rand() % height;
		enemies[i + 1] = rand() % height;
	}

	alg.fillMap(map, SIZE);
	alg.placePlayers(players);
	int n[4]{ 0 };

	cout << "All" << endl;
	for (int i = 0; i < height; i++) {
		for (int j = 0; j < height; j++) {
			cout << map[i * height + j] << " ";
			n[map[i * height + j]]++;
		}
		cout << endl;
	}

	cout << " ===" << endl;
	cout << "Plain" << endl;
	for (int i = 0; i < height; i++) {
		for (int j = 0; j < height; j++) {
			if (map[i * height + j] == Plain)
				cout << map[i * height + j];
			else
				cout << " ";
			cout << " ";
		}
		cout << endl;
	}

	cout << " ===" << endl;
	cout << "Mountain" << endl;
	for (int i = 0; i < height; i++) {
		for (int j = 0; j < height; j++) {
			if (map[i * height + j] == Mountain)
				cout << map[i * height + j];
			else
				cout << " ";
			cout << " ";
		}
		cout << endl;
	}

	cout << " ===" << endl;
	cout << "Forest" << endl;
	for (int i = 0; i < height; i++) {
		for (int j = 0; j < height; j++) {
			if (map[i * height + j] == Forest)
				cout << map[i * height + j];
			else
				cout << " ";
			cout << " ";
		}
		cout << endl;
	}

	cout << " ===" << endl;
	cout << "Water" << endl;
	for (int i = 0; i < height; i++) {
		for (int j = 0; j < height; j++) {
			if (map[i * height + j] == Water)
				cout << map[i * height + j];
			else
				cout << " ";
			cout << " ";
		}
		cout << endl;
	}

	cout << " ===" << endl;
	cout << "P1: " << players[0] << ":" << players[1] << "; on Water ? " << (map[players[0] * height + players[1]] == Water) << endl;
	cout << "P2: " << players[2] << ":" << players[3] << "; on Water ? " << (map[players[2] * height + players[3]] == Water) << endl;

	cout << " ===" << endl;
	cout << "Plain:  \t" << n[Plain] << endl;
	cout << "Mountain:\t" << n[Mountain] << endl;
	cout << "Forest: \t" << n[Forest] << endl;
	cout << "Water:  \t" << n[Water] << endl;

	cout << " ===" << endl;
	cout << "Units" << endl;
	for (int i = 0; i < NB_UNITS; i++) {
		cout << "\t" << i << " - " << units[i * 2] << ":" << units[i * 2 + 1] << endl;
	}

	alg.bestMoves(Orc, units, mvPts, NB_UNITS, life, enemies, NB_UNITS, moves);

	cout << " ===" << endl;
	cout << "3 best moves:" << endl;
	cout << "\t1 - " << moves[0] << ":" << moves[1] << endl;
	cout << "\t2 - " << moves[2] << ":" << moves[3] << endl;
	cout << "\t3 - " << moves[4] << ":" << moves[5] << endl;

	TileType testmap[] = {
		Water	, Mountain	, Plain	, Water	, Water	, Water	, Forest	, Mountain	, Water		, Plain	, Mountain	, Mountain	, Water		, Water	,
		Forest	, Mountain	, Water	, Plain	, Forest, Forest, Mountain	, Forest	, Mountain	, Plain	, Mountain	, Water		, Mountain	, Water	,
		Forest	,
		Forest	,
		Plain	,
		Plain	,
		Forest	,
		Forest	,
		Plain	,
		Forest	,
		Plain	,
		Plain	,
		Forest	,
		Water	,
		Plain	,
		Plain	,
		Forest	,
		Plain	,
		Forest	,
		Water	,
		Mountain	,
		Plain	,
		Water	,
		Plain	,
		Mountain	,
		Mountain	,
		Mountain	,
		Water	,
		Plain	,
		Water	,
		Mountain	,
		Mountain	,
		Plain	,
		Water	,
		Mountain	,
		Mountain	,
		Plain	,
		Plain	,
		Forest	,
		Plain	,
		Water	,
		Water	,
		Forest	,
		Forest	,
		Plain	,
		Water	,
		Forest	,
		Plain	,
		Plain	,
		Water	,
		Mountain	,
		Forest	,
		Mountain	,
		Mountain	,
		Forest	,
		Mountain	,
		Mountain	,
		Forest	,
		Mountain	,
		Plain	,
		Mountain	,
		Mountain	,
		Mountain	,
		Forest	,
		Mountain	,
		Water	,
		Water	,
		Forest	,
		Plain	,
	Forest,
	Plain,
	Mountain,
	Forest,
	Water,
	Plain,
	Forest,
	Plain,
	Forest,
	Forest,
	Forest,
	Mountain,
	Plain,
	Water,
	Forest,
	Plain,
	Plain,
	Forest,
	Mountain,
	Water,
	Water,
	Forest,
	Water,
	Water,
	Water,
	Mountain,
	Plain,
	Water,
	Mountain,
	Mountain,
	Forest,
	Forest,
	Water,
	Water,
	Forest,
	Plain,
	Water,
	Water,
	Mountain,
	Forest,
	Water,
	Plain,
	Plain,
	Forest,
	Mountain,
	Water,
	Water,
	Water,
	Forest,
	Mountain,
	Mountain,
	Water,
	Water,
	Plain,
	Plain,
	Water,
	Mountain,
	Plain,
	Mountain,
	Mountain,
	Forest,
	Mountain,
	Water,
	Plain,
	Mountain,
	Water,
	Mountain,
	Forest,
	Plain,
	Forest,
	Water,
	Water,
	Plain,
	Plain,
	Forest,
	Forest,
	Water,
	Plain,
	Forest,
	Forest,
	Mountain,
	Plain,
	Forest,
	Mountain,
	Water,
	Mountain,
	Plain,
	Water,
	Mountain,
	Forest,
	Plain,
	Mountain,
	Forest,
	Water,
	Plain,
	Forest,
	Forest,
	Plain,
	Plain,
	Plain,
	Mountain };

	alg.init(testmap, 196);

	cout << "All" << endl;
	for (int i = 0; i < height; i++) {
		for (int j = 0; j < height; j++) {
			cout << testmap[i * height + j] << " ";
			n[map[i * height + j]]++;
		}
		cout << endl;
	}

	int tunits[] = { 1, 8, 4, 5, 8, 3, 3, 9 };
	int tlife[] = { 17, 17, 17, 17 };
	double tmv[] = { 2.0, 2.0, 2.0, 2.0, 2.0 };
	int tenemies[] = { 12, 6, 8, 5, 4, 7, 3, 5, 6, 7 };

	alg.bestMoves(Elf, tenemies, tmv, 5, tlife, tunits, NB_UNITS, moves);

	cout << " ===" << endl;
	cout << "3 best moves:" << endl;
	cout << "\t1 - " << moves[0] << ":" << moves[1] << endl;
	cout << "\t2 - " << moves[2] << ":" << moves[3] << endl;
	cout << "\t3 - " << moves[4] << ":" << moves[5] << endl;

	system("pause");
}