using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

	private float cloudSpeed;

	// Use this for initialization
	void Start () {

		cloudSpeed = Random.Range (-0.2f, -1f);

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector2(cloudSpeed*Time.deltaTime, 0));

	}
}
