using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	public TileType[] tileTypes;
	public GameObject defaultTilePrefab;


	public int mapSizeX;
	public int mapSizeY;
	public float startX;	// Coordinates of first tile
	public float startY;

	private float horiz = 1.5f;	// Distance between tiles in the same
	private float vert = 0.433f;	//	row/column
	private Hex[,] tiles;
	private Hex selected = null;

	void Start() {
		spawnEmptyTiles();

		// TODO: spawn a few
		GameManager.instance.inputManager.registerOnBgClickCb(deselect);
	}

	public void select(Hex hex) {
		if (selected != null) {
			selected.deselect();
		}
		selected = hex;
	}

	public void deselect() {
		if (selected != null) {
			selected.deselect();
		}
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
				hexGO = Instantiate(defaultTilePrefab, new Vector3(hexX, hexY, 0), Quaternion.identity, this.transform);
				hex = hexGO.GetComponent<Hex>();
				hex.value = 0;
				tiles[x, y] = hex;
			}
			oddRow = 1 - oddRow;	// Invert oddrow
		}
	}

}
