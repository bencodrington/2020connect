using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// Static instance of GameManager for public access
	
	public TileMap tileMap;
	public InputManager inputManager;

	public GameObject tileMapPrefab;
	public GameObject inputManagerPrefab;

	void Awake() {
		// Check if instance already exists
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			// Destroy this to enforce singleton pattern
			Destroy(gameObject);
		}

		// TODO: DontDestroyOnLoad(gameObject)

		initiateGame();
	}

	void initiateGame() {
		GameObject inputManagerGO = Instantiate(inputManagerPrefab);
		inputManager = inputManagerGO.GetComponent<InputManager>();
		GameObject tileMapGO = Instantiate(tileMapPrefab, Vector3.zero, Quaternion.identity, transform);
		tileMap = tileMapGO.GetComponent<TileMap>();
	}
}
