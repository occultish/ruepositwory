using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	private static float PlayerSpeed = 0.25f;
	public GameObject tailPrefab;
	Vector2 dir = Vector2.up * PlayerSpeed;
	List<Transform> tail = new List<Transform>();
	private bool moved;
	// Use this for initialization
	void Start()
	{
		moved = false;
		InvokeRepeating("Move", 0.25f, 0.25f);
	}
	IEnumerator PauseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(2.0f);
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
		if (Input.GetKeyDown(KeyCode.RightArrow))
			dir = Vector2.right * PlayerSpeed;
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			dir = -Vector2.up * PlayerSpeed;
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			dir = -Vector2.right * PlayerSpeed;
		else if (Input.GetKeyDown(KeyCode.UpArrow))
			dir = Vector2.up * PlayerSpeed;
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