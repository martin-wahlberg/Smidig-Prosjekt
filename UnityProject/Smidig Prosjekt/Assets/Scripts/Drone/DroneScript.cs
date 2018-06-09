using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DroneScript : MonoBehaviour {

	public float DroneDeliveries;

	private Rigidbody2D rb;
	public float Force;

	public float VelocityY;
	public float VelocityX;


	public GameObject Plain;
	public GameObject Snor;
	public GameObject Box;

	private float dailyScore;



	// Use this for initialization
	void Start () {
		dailyScore = PlayerPrefs.GetFloat("dailyscore");

		rb = GetComponent<Rigidbody2D> ();

		DroneDeliveries = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (DroneDeliveries >= 8) {
			BetweenGames ();
		}


		VelocityY = rb.velocity.y;
		VelocityX = rb.velocity.x;

		//Control max speed

		if (rb.velocity.y < -5) {
			rb.velocity = new Vector2 ( rb.velocity.x, -5f);
		}
		if (rb.velocity.y > 2) {
			rb.velocity = new Vector2 ( rb.velocity.x, 2f);
		}

			if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)) {

				rb.AddForce (new Vector2 (0f, 2f) * Force, ForceMode2D.Force);
		
			} else {
			
				if (Input.GetKey (KeyCode.A)) {

					if (rb.velocity.x > 0) {
						rb.AddForce (new Vector2 (-0.75f, 0.25f) * Force, ForceMode2D.Force);

					} else {
						rb.AddForce (new Vector2 (-0.75f, 1.3f) * Force, ForceMode2D.Force);

					}
				} else if (Input.GetKey (KeyCode.D)) {
					if (rb.velocity.x < 0) {
						rb.AddForce (new Vector2 (0.75f, 0.25f) * Force, ForceMode2D.Force);
				
					} else {
						rb.AddForce (new Vector2 (0.75f, 1.3f) * Force, ForceMode2D.Force);

					}
				}

		} 


		//rotation animation

		transform.eulerAngles = new Vector3 (0,0, VelocityX*-6);


	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Cheese") {
			
			Plain.SetActive (false);
			Box.SetActive (true);
			Snor.SetActive (true);

			Destroy (other.gameObject);

		}

		if (other.tag == "Enemy") {

			RestartScene ();

			Destroy (gameObject);

		}
	}
		
	void RestartScene(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

	}
	void BetweenGames(){

		SceneManager.LoadScene ("BetweenGames");

	}
}
