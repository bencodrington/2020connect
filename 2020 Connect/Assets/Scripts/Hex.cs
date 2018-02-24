using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Color selectedColor;
	protected Color startingColor;
	protected Vector2 _coordinates;
	public Vector2 coordinates {
		get { return _coordinates; }
		set { _coordinates = value; }
	}
	public int value;

	public void Start() {
		startingColor = spriteRenderer.color;
	}

	public virtual void select() {
		spriteRenderer.color = selectedColor;
		GameManager.instance.tileMap.select(this);
	}

	public virtual void deselect() {
		spriteRenderer.color = startingColor;
	}

	public void click() {
		select();
	}
}
