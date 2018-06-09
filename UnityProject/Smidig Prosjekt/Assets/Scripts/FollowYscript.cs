using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowYscript : MonoBehaviour {

	public GameObject FollowTarget;
	
	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3 (transform.position.x,
			FollowTarget.transform.position.y, transform.position.z);

	}
}
