using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUpScript : MonoBehaviour {

	private float dailyPoints;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat ("dailyscore", 600);
	}
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown || Time.time > 2) {
			BackToMenu ();
		}
	}

	void BackToMenu(){

		SceneManager.LoadScene ("MainMenu");
	}
}
