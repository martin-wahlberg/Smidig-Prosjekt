using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour {

	void Update () {

		transform.position = new Vector2 ( Mathf.PingPong (Time.time*1f, 10), transform.position.y);
	}
}
