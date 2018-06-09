using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPickUp : MonoBehaviour {

	public int PointValue;
	public float SpeedY;

	private Rigidbody2D _rB;

	// Use this for initialization
	void Start () {

		_rB = this.GetComponent<Rigidbody2D> ();
		_rB.rotation = Random.Range (0, 180);

	}
	
	// Update is called once per frame
	void Update () {

		_rB.velocity = new Vector2 (0f, SpeedY);
		_rB.rotation += 3;

	}
}
