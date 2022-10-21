﻿using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	public int numLives = 4;

	float respawnTimer;

	// Use this for initialization
	void Start () {
		SpawnPlayer();
	}

	void SpawnPlayer() {
		numLives--; //Takes a life away when respawning
		respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;
			//Respawn timer
			if(respawnTimer <= 0) {
				SpawnPlayer();
			}
		}
	}

	void OnGUI() {
		//Displaying the number of lives left
		if(numLives > 0 || playerInstance!= null) {
			GUI.Label( new Rect(0, 0, 100, 50), "Lives Left: " + numLives);
		}
		//Game Over text
		else {
			GUI.Label( new Rect( Screen.width/2 - 50 , Screen.height/2 - 25, 100, 50), "Game Over, Man!");

		}
	}
}