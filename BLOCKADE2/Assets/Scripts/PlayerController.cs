using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Current Movement Direction
	// (by default it moves to the right)
	public static float PlayerSpeed = 0.29f;
	Vector2 dir = Vector2.up*PlayerSpeed;
	
	// Use this for initialization
	void Start () {
		// Move the Snake every 300ms
		InvokeRepeating("Move", 0.3f, 0.3f);    
	}
    
	void Move() {
		// Move head into new direction
		transform.Translate(dir);
	}
	// Update is called once per Frame
	void Update() {
		// Move in a new Direction?
		if (Input.GetKey(KeyCode.RightArrow))
			dir = Vector2.right*PlayerSpeed;
		else if (Input.GetKey(KeyCode.DownArrow))
			dir = -Vector2.up*PlayerSpeed;    // '-up' means 'down'
		else if (Input.GetKey(KeyCode.LeftArrow))
			dir = -Vector2.right*PlayerSpeed; // '-right' means 'left'
		else if (Input.GetKey(KeyCode.UpArrow))
			dir = Vector2.up*PlayerSpeed;
	}
}
