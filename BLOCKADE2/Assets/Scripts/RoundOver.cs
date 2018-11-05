using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoundOver : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			ResetGame();
		}
	}
	void ResetGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
