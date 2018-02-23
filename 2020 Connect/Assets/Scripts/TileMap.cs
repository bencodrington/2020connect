using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	public TileType[] tileTypes;
	public GameObject defaultTilePrefab;

	int[,] tiles;

	public int mapSizeX = 10;
	public int mapSizeY = 10;
	public float startX = 0;	// Coordinates of first tile
	public float startY = 0;
	public float horiz = 0.75f;	// Distance between tiles in the same
	public float vert = 0.433f;	//	row/column

	void Start() {
		int index = 0;	// Will be used to decide which tile to place
		float hexX, hexY = 0;	// Where to spawn tiles
		int oddRow = 0;

		// Allocate space for tiles
		tiles = new int[mapSizeX, mapSizeY];

		// Instantiate each tile to type 0 by default
		for (int x = 0; x < mapSizeX; x++) {
			for (int y = 0; y < mapSizeY; y++) {
				tiles[x, y] = 0;
			}
		}

		// TODO: spawn a few
				// index = Random.Range(0, tileTypes.Length);
				// tiles[x, y] = tileTypes[index].value;

		// Spawn default tiles to fill the map
		for (int x = 0; x < mapSizeX; x++) {
			for (int y = 0; y < mapSizeY; y++) {
				// TODO: check if tiles[x, y] == 0
				hexX = startX + horiz * y + (oddRow * horiz / 2);
				hexY = startY + vert * x;
				Instantiate(defaultTilePrefab, new Vector3(hexX, hexY, 0), Quaternion.identity);
			}
			oddRow = 1 - oddRow;	// Invert oddrow
		}

		
	}

}
