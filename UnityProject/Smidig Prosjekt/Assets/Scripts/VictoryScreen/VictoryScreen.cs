using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour {

	void Start () {

		float poeng = 1 * 5968385060;
		Application.ExternalCall ("gameWinTrue", poeng);

		PlayerPrefs.SetFloat ("dailyscore", 600);

	}

	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			BackToMenu ();
		}

	}

	void BackToMenu(){


		SceneManager.LoadScene ("MainMenu");

	}

}
