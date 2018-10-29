using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
	private static float PlayerSpeed = 0.25f;
	public GameObject tailPrefab;
	public RoundOver other;
	Vector2 dir = Vector2.down * PlayerSpeed;
	List<Transform> tail = new List<Transform>();
	private bool moved;

	// Use this for initialization
	void Start()
	{
		moved = false;
		InvokeRepeating("Move", 0.25f, 0.25f);
	}

	void Move()
	{
		Vector2 v = transform.position;
		transform.Translate(dir);
		if (transform.hasChanged)
		{
			moved = true;
		}

		if (moved)
		{
			GameObject g = Instantiate(tailPrefab, v, Quaternion.identity);
			tail.Add(tailPrefab.transform);
			tail.Insert(0, g.transform);
		}
	}

	// Update is called once per Frame
	void Update()
	{
		if (Input.GetKey(KeyCode.D))
			dir = Vector2.right * PlayerSpeed;
		else if (Input.GetKey(KeyCode.S))
			dir = -Vector2.up * PlayerSpeed;
		else if (Input.GetKey(KeyCode.A))
			dir = -Vector2.right * PlayerSpeed;
		else if (Input.GetKey(KeyCode.W))
			dir = Vector2.up * PlayerSpeed;
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.tag.StartsWith("map"))
		{
			other.StopInvoke();
		}
		else if (coll.tag.StartsWith("Player"))
		{
			other.StopInvoke();
		}
	}
}