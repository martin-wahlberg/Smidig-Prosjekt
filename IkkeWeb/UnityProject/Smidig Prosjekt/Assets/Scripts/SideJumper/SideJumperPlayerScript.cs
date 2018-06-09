using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideJumperPlayerScript : MonoBehaviour {



	void Update () {

		//Movement

		if (Input.GetKeyDown (KeyCode.A) && transform.position.x > -3f) {
			transform.position = new Vector3 (transform.position.x - 3.5f, transform.position.y,transform.position.z );
		}
		if (Input.GetKeyDown (KeyCode.D) && transform.position.x < 3f) {
			transform.position = new Vector3 (transform.position.x + 3.5f, transform.position.y,transform.position.z );
		}

	}
}
