using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorBladeScript : MonoBehaviour {

	private GameObject Player;
	private Rigidbody2D rb;

	private float rotorSpeed;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		rb = Player.GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		float HighestVelocity;
		if (Mathf.Abs(rb.velocity.y) > Mathf.Abs(rb.velocity.x)) {
			HighestVelocity = rb.velocity.y;
		} else {
			HighestVelocity = rb.velocity.x;
		}
		
		if (Mathf.Abs (rb.velocity.y) > 0) {

			rotorSpeed = 10 * Mathf.Abs (HighestVelocity) * 3;
		} else {
			rotorSpeed = 10;
		}
		transform.Rotate (new Vector3(0,0,rotorSpeed));
		
	}
}
