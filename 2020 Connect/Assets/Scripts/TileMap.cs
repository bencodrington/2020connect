using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	public TileType[] tileTypes;

	int[,] tiles;

	int mapSizeX = 10;
	int mapSizeY = 10;

	void Start() {
		// Allocate space for tiles
		tiles = new int[mapSizeX, mapSizeY];

		// Instantiate each tile to type 0 by default
		for (int x = 0; x < mapSizeX; x++) {
			for (int y = 0; y < mapSizeY; y++) {
				tiles[x, y] = 0;
			}
		}
	}

}
