using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour {
	private Rigidbody rb;

	public float enemySpeedX;
	public float enemySpeedY;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (enemySpeedX, enemySpeedY, 0), ForceMode.Impulse);
	}

}
