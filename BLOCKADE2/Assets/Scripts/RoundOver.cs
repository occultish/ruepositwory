using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoundOver : MonoBehaviour
{
	
	IEnumerator PauseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(2.0f);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	public void StopInvoke()
	{
		CancelInvoke();
		StartCoroutine("PauseTime");
	}
}