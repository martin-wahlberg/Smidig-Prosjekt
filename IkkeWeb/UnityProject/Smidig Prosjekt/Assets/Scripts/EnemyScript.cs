using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	private Rigidbody2D rb;

	public float enemySpeedX;
	public float enemySpeedY;
	public bool randomRotation = true;

	private float startingRotation;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (enemySpeedX, enemySpeedY), ForceMode2D.Impulse);
	
		if (randomRotation) {
			startingRotation = Random.Range (0, 500);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (randomRotation) {
			rb.angularVelocity = startingRotation * Time.deltaTime;
		}
	}
}
