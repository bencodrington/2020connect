using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	public TileType[] tileTypes;
	public int numSpawnableTileTypes;
	public GameObject hexPrefab;


	public int mapSizeX;
	public int mapSizeY;
	public float startX;			// Coordinates of first tile
	public float startY;

	public int startingTilesMin;	// Range of number of starting tiles,
	public int startingTilesMax;	//	both min and max are inclusive.

	private float horiz = 1.5f;		// Distance between tiles in the same
	private float vert = 0.433f;	//	row/column
	private Hex[,] tiles;
	private Hex selected = null;

	void Start() {
		spawnEmptyTiles();

		spawnStartingTiles();

		GameManager.instance.inputManager.registerOnBgClickCb(deselect);
	}

	// Deselect currently selected hex
	public void deselect() {
		if (selected != null) {
			selected.deselect();
		}
	}

	// Move currently selected hex to provided destination
	public void moveTo(Hex destination) {
		if (selected != null) {
			destination.value = selected.value;
			selected.value = 0;
			selected.deselect();
		}
	}

	// Select the provided hex
	public void select(Hex hex) {
		if (selected != null) {
			selected.deselect();
		}
		selected = hex;
	}

	void spawnEmptyTiles() {
		float hexX, hexY = 0;	// Where to spawn tiles
		int oddRow = 0;			// Used for horiz. offsetting every other row
		GameObject hexGO;
		Hex hex;

		// Allocate space for tiles
		tiles = new Hex[mapSizeX, mapSizeY];

		// Spawn default tiles to fill the map
		for (int x = 0; x < mapSizeX; x++) {
			for (int y = 0; y < mapSizeY; y++) {
				hexX = startX + horiz * y + (oddRow * horiz / 2);
				hexY = startY + vert * x;
				hexGO = Instantiate(hexPrefab, new Vector3(hexX, hexY, 0), Quaternion.identity, this.transform);
				hex = hexGO.GetComponent<Hex>();
				hex.value = 0;
				tiles[x, y] = hex;
			}
			oddRow = 1 - oddRow;	// Invert oddrow
		}
	}

	// Spawns the tiles that the game starts with
	//	The number of tiles it spawns is determined by startingTilesMin
	//	and startingTilesMax.
	// Effectively does what TODO: spawnWave() will do, but more efficiently
	//	in this case.
	void spawnStartingTiles() {
		Hex emptyHex = null;
		int numStartingTiles = Random.Range(startingTilesMin, startingTilesMax + 1);
		int x, y, newValue;

		// Sanity check
		if (numStartingTiles > mapSizeX * mapSizeY) {
			Debug.LogError("Trying to spawn too many tiles at start of game, so spawning none.");
			return;
		}

		for (int i = 0; i < numStartingTiles; i++) {
			// Select an empty space
			while (emptyHex == null || emptyHex.value != 0) {
				x = Random.Range(0, mapSizeX);
				y = Random.Range(0, mapSizeY);
				emptyHex = tiles[x, y];
			}

			// Select a spawnable tile
			newValue = tileTypes[Random.Range(0, numSpawnableTileTypes)].value;
			emptyHex.value = newValue;
		}
	}

}
