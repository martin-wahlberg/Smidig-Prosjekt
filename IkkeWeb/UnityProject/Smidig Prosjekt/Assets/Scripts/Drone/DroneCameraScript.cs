using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCameraScript : MonoBehaviour {

	public GameObject Player;
	private Rigidbody2D pRB;
	private float ZoomOut;
	private float ZoomOutX;
	private float ZoomOutY;

	private Camera cam;

	private float stillTimer;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		pRB = Player.GetComponent<Rigidbody2D> ();

		cam = GetComponent<Camera> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3 (Player.transform.position.x,Player.transform.position.y, transform.position.z);


		ZoomOutX = Mathf.Abs( pRB.velocity.x);

		ZoomOut = Mathf.MoveTowards (ZoomOut, ZoomOutX*1.25f, 1f);

		if (Input.GetKey(KeyCode.LeftShift)){
			ZoomOut = 50;
		}


		cam.orthographicSize = 4+ ZoomOut * 0.2f;

		
	}
}
