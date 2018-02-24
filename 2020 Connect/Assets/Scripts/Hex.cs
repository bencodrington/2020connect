using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public TextMesh textMesh;
	public Color selectedColor;
	protected Color startingColor;

	// protected Vector2 _coordinates;
	// public Vector2 coordinates {
	// 	get { return _coordinates; }
	// 	set { _coordinates = value; }
	// }
	public Vector3 cubeCoords;

	// The number shown on the tile's face
	protected int _value;
	public int value {
		get { return _value; }
		set { 
			_value = value;
			updateText(value);
		}
	}


	public void Start() {
		startingColor = spriteRenderer.color;
	}

	public void select() {
		spriteRenderer.color = selectedColor;
		GameManager.instance.tileMap.select(this);
	}

	public void deselect() {
		spriteRenderer.color = startingColor;
	}

	public void click() {
		if (value == 0) {
			GameManager.instance.tileMap.moveTo(this);
		} else {
			select();
		}
	}

	void updateText(int value) {
		if (value == 0) {
			textMesh.text = "";
		} else {
			textMesh.text = value.ToString();
		}
	}
}
