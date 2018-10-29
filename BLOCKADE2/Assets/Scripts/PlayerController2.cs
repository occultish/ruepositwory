using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{

	// Current Movement Direction
	// (by default it moves to the right)
	public static float PlayerSpeed = 0.25f;
	public GameObject tailPrefab;
	Vector2 dir = Vector2.down * PlayerSpeed;
	List<Transform> tail = new List<Transform>();
	private bool moved;
	public Text scoreText;
	private int score;
	
	// Use this for initialization
	void Start()
	{
		score = 0;
		UpdateScore ();
		// Move the Snake every 300ms
		moved = false;
		InvokeRepeating("Move", 0.25f, 0.25f);
	}

	void Move()
	{
		// Move head into new direction
		Vector2 v = transform.position;
		transform.Translate(dir);
		if (transform.hasChanged)
		{
			// Get longer in next Move call
			moved = true;
		}

		if (moved)
		{
			// Load Prefab into the world
			GameObject g = Instantiate(tailPrefab,
				v,
				Quaternion.identity);

			// Keep track of it in our tail list
			tail.Insert(0, g.transform);
		}
	}

	// Update is called once per Frame
	void Update()
	{
		// Move in a new Direction?
		if (Input.GetKey(KeyCode.A))
			dir = Vector2.right * PlayerSpeed;
		else if (Input.GetKey(KeyCode.S))
			dir = -Vector2.up * PlayerSpeed;
		else if (Input.GetKey(KeyCode.D))
			dir = -Vector2.right * PlayerSpeed;
		else if (Input.GetKey(KeyCode.W))
			dir = Vector2.up * PlayerSpeed;
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
}
