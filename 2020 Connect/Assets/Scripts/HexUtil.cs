using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Heavily influenced by https://www.redblobgames.com/grids/hexagons/

public static class HexUtil {
	// FIXME:? Unclear why entries 3 and 6 needed to be changed to their
	// 	current values rather than (0, +1, -1) and (0, -1, +1),
	// 	but otherwise neighbours are not correctly selected
	static Vector3[] cube_directions = {
		new Vector3(1, -1, 0),
		new Vector3(1, 0, -1),
		new Vector3(+2, -1, -1),
		new Vector3(-1, 1, 0),
		new Vector3(-1, 0, 1),
		new Vector3(-2, 1, 1)
	};

	// Returns the cubic coordinates of the neighbour of 'cube'
	// 	in 'direction'
	static Vector3 cubeNeighbour(Vector3 cube, int direction) {
		return cube + cube_directions[direction];
	}

	public static List<Vector3> cubeNeighbours(Vector3 cube) {
		List<Vector3> neighbours = new List<Vector3>();
		Vector3 neighbour;
		for (int i = 0; i < 6; i++) {
			neighbour = cubeNeighbour(cube, i);

			// Only add if a hex exists for this neighbour
			if (isValidCube(neighbour)) {
				neighbours.Add(neighbour);
			}
		}
		return neighbours;
	}

	// Used for converting from cubic (vector3) coordinates to offset
	//	(cartesian) coordinates
	public static Vector2 cubeToOffset(Vector3 cube) {
		int col = (int)cube.x;
		int row = (int)cube.z + ((int)cube.x - ((int)cube.x & 1)) / 2;
		return new Vector2(col, row);
	}

	// Used for converting from offset (cartesian) coordinates to cubic
	//	(vector3) coordinates
	public static Vector3 OffsetToCube(Vector2 hex) {
		int x = (int)hex.x;
		int z = (int)hex.y - ((int)hex.x - ((int)hex.x & 1)) / 2;
		int y = (-x - z);
		return new Vector3(x, y, z);
	}

	static bool isCubeReachable(Vector3 start, Vector3 end) {
		Queue<Vector3> visited = new Queue<Vector3>();
		visited.Enqueue(start);

		while (visited.Count > 0) {
			// TODO:
		}
		return false;
	}

	// Return true iff provided cube is within the boundaries of the
	// 	tile map.
	static bool isValidCube(Vector3 cube) {
		// Convert to offset coordinates system
		Vector2 offset = cubeToOffset(cube);
		// Cache reference to tilemap
		TileMap tm = GameManager.instance.tileMap;
		// TODO:
		return offset.x >= 0 && offset.x < tm.mapSizeX &&
					offset.y >= 0 && offset.y < tm.mapSizeY;
	}

}
