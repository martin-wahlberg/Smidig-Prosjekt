using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour {

	public bool Red = true;
	public bool Blue = false;

	private SpriteRenderer _sr;

	void Awake () {

		_sr = this.GetComponent<SpriteRenderer> ();
		_sr.color = Color.red;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)){

			if (Red) {

				_sr.color = Color.blue;

				Blue = true;
				Red = false;

			}
			else if (Blue) {

				_sr.color = Color.red;

				Blue = false;
				Red = true;

			}


		}

	}
}
