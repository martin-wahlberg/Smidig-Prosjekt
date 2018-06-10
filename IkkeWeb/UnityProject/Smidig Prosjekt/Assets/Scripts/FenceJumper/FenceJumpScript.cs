using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FenceJumpScript : MonoBehaviour {

	private Rigidbody2D rb;
	public bool jumping;
	public int HitPoints;

	private bool jumpDebug = false;
	private Animator jAnimation;

	private float dailyScore;

	// Use this for initialization
	void Start () {
		dailyScore = PlayerPrefs.GetFloat("dailyscore");
	
		rb = GetComponent<Rigidbody2D> ();
		HitPoints = 3;
		jAnimation = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {


			jAnimation.SetBool("JumpingAnimation", true);
			rb.AddForce (Vector2.up * 20, ForceMode2D.Impulse);
			jumpDebug = false;
		
		}

		if (Input.GetKeyUp(KeyCode.Space) && jumpDebug == false){
			jumping = true;
			jAnimation.SetBool("JumpingAnimation", false);
		}
	} 
			
		


	void OnCollisionEnter2D (Collision2D other)
	{
		jumpDebug = true;
		jumping = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {

			HitPoints -= 1;

			Destroy (other.gameObject);

			if (HitPoints <= 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}

	}

	void ReloadScene()
	{
		
		SceneManager.LoadScene ("BetweenGames");
		
	}

}
