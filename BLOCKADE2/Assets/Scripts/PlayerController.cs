using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public static float PlayerSpeed = 0.25f;
	public GameObject tailPrefab;
	public GameObject roundOver;
	Vector2 dir = Vector2.up * PlayerSpeed;
	List<Transform> tail = new List<Transform>();
	private bool moved;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	private int score;
	private bool gameOver;
	private bool restart;
		
	
	// Use this for initialization
	void Start()
	{
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		score = 0;
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
		if (transform.hasChanged) {
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
			if (Input.GetKey(KeyCode.RightArrow))
				dir = Vector2.right * PlayerSpeed;
			else if (Input.GetKey(KeyCode.DownArrow))
				dir = -Vector2.up * PlayerSpeed;
			else if (Input.GetKey(KeyCode.LeftArrow))
				dir = -Vector2.right * PlayerSpeed;
			else if (Input.GetKey(KeyCode.UpArrow))
				dir = Vector2.up * PlayerSpeed;
			
			if (restart)
			{
				if (Input.GetKeyDown (KeyCode.R))
				{
					Application.LoadLevel (Application.loadedLevel);
				}
			}
			if (gameOver)
			{
				restartText.text = "Press '1' to Begin Next Round.";
				restart = true;
			}
		}
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.tag.StartsWith("map"))
		{
			Instantiate(roundOver, coll.transform.position, coll.transform.rotation);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		else if (coll.tag.StartsWith("Player"))
		{
			Instantiate(roundOver, coll.transform.position, coll.transform.rotation);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

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
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
	}