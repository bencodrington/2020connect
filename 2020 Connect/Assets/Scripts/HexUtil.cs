using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Heavily influenced by https://www.redblobgames.com/grids/hexagons/

public class HexUtil {
	Vector3[] cube_directions = {
		new Vector3(1, -1, 0),
		new Vector3(1, 0, -1),
		new Vector3(0, 1, -1),
		new Vector3(-1, 1, 0),
		new Vector3(-1, 0, 1),
		new Vector3(0, -1, 1)
	};

	// Returns the cubic coordinates of the neighbour of 'cube'
	// 	in 'direction'
	Vector3 cubeNeighbour(Vector3 cube, int direction) {
		return cube + cube_directions[direction];
	}

	// Used for converting from cubic (vector3) coordinates to offset
	//	(cartesian) coordinates
	Vector2 cubeToOffset(Vector3 cube) {
		int col = (int)cube.x;
		int row = (int)cube.z + ((int)cube.x - ((int)cube.x & 1)) / 2;
		return new Vector2(col, row);
	}

	// Used for converting from offset (cartesian) coordinates to cubic
	//	(vector3) coordinates
	Vector3 OffsetToCube(Vector2 hex) {
		int x = (int)hex.x;
		int z = (int)hex.y - ((int)hex.x - ((int)hex.x & 1)) / 2;
		int y = (-x - z);
		return new Vector3(x, y, z);
	}

	bool isCubeReachable(Vector3 start, Vector3 end) {
		Queue<Vector3> visited = new Queue<Vector3>();
		visited.Enqueue(start);

		while (visited.Count > 0) {

		}
		return false;
	}

}
