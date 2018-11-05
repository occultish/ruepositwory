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
	Vector2 dir = Vector2.down * PlayerSpeed;
	List<Transform> tail = new List<Transform>();
	private bool moved;
	public float turnspeed;
	private SpriteRenderer mySpriteRenderer;
	
	// Use this for initialization
	void Start()
	{
		moved = false;
		InvokeRepeating("Move", 0.25f, 0.25f);
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	IEnumerator PauseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(3.0f);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
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
	public void StopInvoke()
	{
		CancelInvoke();
		StartCoroutine("PauseTime");
	}

	// Update is called once per Frame
	void Update()
	{
		if (Input.GetKey(KeyCode.D))
		{
			dir = Vector2.right * PlayerSpeed;
			transform.Rotate(Vector3.right, turnspeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			dir = -Vector2.up * PlayerSpeed;
			transform.Rotate(Vector3.down, turnspeed * Time.deltaTime);

		}
		else if (Input.GetKey(KeyCode.A))
		{
			dir = -Vector2.right * PlayerSpeed;
			transform.Rotate(Vector3.left, turnspeed * Time.deltaTime);
			
		}
		else if (Input.GetKey(KeyCode.W))
		{
			dir = Vector2.up * PlayerSpeed;
			transform.Rotate(Vector3.up, turnspeed * Time.deltaTime);
		}
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.tag.StartsWith("map"))
		{
			CancelInvoke();
			StartCoroutine(PauseTime());
		}
		else if (coll.tag.StartsWith("Player"))
		{
			CancelInvoke();
			StartCoroutine(PauseTime());
		}
	}
}