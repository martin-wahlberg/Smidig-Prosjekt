using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


	public float jumpStrength;
	public Rigidbody2D rigidBody;
	public float velocityY;
	public Vector2 v;

	public bool Fishy =false;

	void Start () {

		rigidBody = GetComponent<Rigidbody2D> ();

	}

	void Update () {

		if (Fishy) {

			if (transform.position.y > 6) {
				transform.position = new Vector3 
					(transform.position.x, transform.position.y - 3, transform.position.z);
			} else if (transform.position.y < -6) {
				transform.position = new Vector3 
					(transform.position.x, transform.position.y + 2, transform.position.z);
			}
		}

		transform.Translate (new Vector2 ((Mathf.Cos (Time.time) * Time.deltaTime),0));

		v = rigidBody.velocity;

		velocityY = v.y;
		transform.eulerAngles = new Vector3 (0,0, velocityY*3);

		if (v.y < -2.5f) {
			v.y = -2.5f;
		}
		if (v.y > 2.5f) {
			v.y = 2.5f;
		}

		if (Input.GetKey(KeyCode.Space))
			{
			rigidBody.AddForce(new Vector2(0,jumpStrength), ForceMode2D.Impulse);

			}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {

			rigidBody.velocity = new Vector2 (0, v.y * -1);

		}

	}
}
