using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public bool objCollision;
	public Quaternion playerRotation;
	public static float PlayerSpeed = 0.25f;
	public GameObject tailPrefab;
	private Vector3 dir;
	private Vector3 prevPosition;
	//List<Transform> tail = new List<Transform>();
	//private bool moved;
	private bool paused;
	private float playerMoveTimer;
	private Quaternion rotation;
	public AudioSource squidtunes;
	private SpriteRenderer mySpriteRenderer;
	
	// Use this for initialization
	void Start()
	{
		squidtunes = GetComponent<AudioSource>();
		//moved = false;
		//InvokeRepeating("Move", 0.25f, 0.25f);
		playerRotation = transform.rotation;
	}
	
	IEnumerator PauseTime(float pauseTime)
	{
		paused = true;
		float originalSpeed = PlayerSpeed;
		
		yield return new WaitForSeconds(pauseTime);
		paused = false;
		PlayerSpeed = originalSpeed;
	}
	
	private void PressStart()
	{
		dir = Vector2.up;
		rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
		playerMoveTimer = 0;
	}
	// GOT RID OF THE INVOKE FINALLY
	//public void StopInvoke()
	//{
	//	CancelInvoke();
	//	StartCoroutine("PauseTime");
	//}
    // Admittedly got help from Carsen's script on this next part. I really, really could not figure it out.
	// Update is called once per Frame
	void Update()
	{
		playerMoveTimer += Time.deltaTime;
		
		if (Input.GetKeyDown(KeyCode.UpArrow) && dir != Vector3.down)
		{
			dir = Vector2.up * PlayerSpeed;
			rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) && dir != Vector3.right)
		{
			dir = Vector2.left * PlayerSpeed;
			rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) && dir != Vector3.up)
		{
			dir = Vector2.down * PlayerSpeed;
			rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) && dir != Vector3.left)
		{
			dir = Vector2.right * PlayerSpeed;
			rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);		
		}

		if (playerMoveTimer >= PlayerSpeed)
		{
			prevPosition = transform.position;
			transform.rotation = rotation;
			transform.position += dir;
			GameObject Ink = Instantiate(tailPrefab, prevPosition, transform.rotation);
			Ink.GetComponent<SpriteRenderer>();
			playerMoveTimer = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.tag.StartsWith("map"))
		{
			objCollision = true;
		}
		else if (coll.tag.StartsWith("Player"))
		{
			objCollision = true;
		}
	}
}