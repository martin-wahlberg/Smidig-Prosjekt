using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBackground : MonoBehaviour {

	public Renderer rend;
	public float offset;
	public float scrollspeed;


	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		offset = Time.time * scrollspeed;
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (1.35f, offset));

	}
}
