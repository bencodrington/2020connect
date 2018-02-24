using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour {

	Action cbBackgroundClicked;
	int hexLayer;				// Will hold the layer mask for hexes

	// Use this for initialization
	void Start () {
		hexLayer = 1 << LayerMask.NameToLayer("Hexes");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
			
			// Check for hexes beneath mouse
			RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero, Mathf.Infinity, hexLayer);

			if (hit.collider != null) {
				hit.transform.GetComponent<Hex>().click();
			} else {
				onBackgroundClick();
			}
		}
	}

	void onBackgroundClick() {
		cbBackgroundClicked();
	}

	public void registerOnBgClickCb(Action cb) {
		cbBackgroundClicked += cb;
	}
}
