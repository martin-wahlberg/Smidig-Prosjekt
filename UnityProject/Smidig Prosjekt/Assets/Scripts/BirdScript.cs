using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

	private float startPosition;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector2 (-5f*Time.deltaTime, (Mathf.Cos (Time.time) * Time.deltaTime)));
		
	}
}
