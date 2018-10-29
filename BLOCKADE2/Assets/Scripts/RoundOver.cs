using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
	public GameObject roundOver;
	public int scoreValue;
	private PlayerController playerScore;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.tag.StartsWith("map"))
		{
			Instantiate(roundOver, coll.transform.position, coll.transform.rotation);
		}
		Instantiate(roundOver, transform.position, transform.rotation);
		if (coll.tag.StartsWith("player"))
		{
			Instantiate(roundOver, coll.transform.position, coll.transform.rotation);
		}
		playerScore.AddScore (scoreValue);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}