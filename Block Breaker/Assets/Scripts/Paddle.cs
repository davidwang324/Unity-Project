﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private int left, right;
	private KeyCode leftKey, rightKey;
	public Ball ball;
	private float changeXPerFrame;

	void Awake() {

		// Initialize KeyCodes
		left = PlayerPrefs.GetInt ("block-breaker-left-control");
		right = PlayerPrefs.GetInt ("block-breaker-right-control");
		leftKey = (KeyCode)left;
		rightKey = (KeyCode)right;
		changeXPerFrame = .16f;

		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
	}
	// Update is called once per frame
	void Update () {

		// Get current position, change it, then set current position to altered position
		if(Input.GetKey(leftKey)) {
			Vector2 position = this.transform.position;
			position.x = position.x - changeXPerFrame;
			this.transform.position = position;
		}
		if(Input.GetKey(rightKey)) {
			Vector2 position = this.transform.position;
			position.x = position.x + changeXPerFrame;
			this.transform.position = position;
		}

		// Restrict paddle movement to boundaries
		if(gameObject.transform.position.x <= 1.25f) {
			Vector3 position = this.transform.position;
			position.x = 1.22f;
			this.transform.position = position;
		}
		if(gameObject.transform.position.x >= 14.67f) {
			Vector3 position = this.transform.position;
			position.x = 14.67f;
			this.transform.position = position;
		}

		// Paused menu
		if (PlayerPrefs.GetString ("block-breaker-paused") == "true") {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
		else {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
