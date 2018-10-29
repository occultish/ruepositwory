using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoundOver : MonoBehaviour
{
	public GameObject roundOver;
	public int scoreValue;
	public PlayerController AddScore;
	private PlayerController playerScore;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.tag.StartsWith("map"))
		{
			Instantiate(roundOver, coll.transform.position, coll.transform.rotation);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		if (coll.tag.StartsWith("player"))
		{
			Instantiate(roundOver, coll.transform.position, coll.transform.rotation);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}