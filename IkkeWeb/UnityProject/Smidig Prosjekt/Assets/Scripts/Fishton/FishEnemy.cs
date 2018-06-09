using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEnemy : MonoBehaviour {
	
	private Rigidbody2D rb;
	public bool UpwardsMovement;
	public float SpeedX;
	public float SpeedY;
	private FishScript _fS;

	// Use this for initialization
	void Awake () {
	 
		GameObject Fish = GameObject.FindGameObjectWithTag ("Player");
		_fS = Fish.GetComponent<FishScript> ();


	}
	
	// Update is called once per frame
	void Update () {
		SpeedX = _fS.Speed;

	

		rb = GetComponent<Rigidbody2D> ();
		if (UpwardsMovement != true) {
			rb.velocity = new Vector2 (-SpeedX, SpeedY);
		} else {
			rb.velocity = new Vector2 (-SpeedX, Random.Range(10, 20)* Mathf.Cos (Time.time)*Time.deltaTime);
		}

	}
}
