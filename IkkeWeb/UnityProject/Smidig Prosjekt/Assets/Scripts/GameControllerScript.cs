using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

	public bool SpaceToStart;

	// Use this for initialization
	void Start () {
		if (SpaceToStart) {
			Time.timeScale = 0;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {

			SceneManager.LoadScene ("MainMenu");

		}

		if (Input.GetKeyDown (KeyCode.Space) && SpaceToStart) {

			Time.timeScale = 1;
		}
		if (Input.GetKeyDown(KeyCode.R)){
			Scene CurrentScene;
			CurrentScene = SceneManager.GetActiveScene();

			SceneManager.LoadScene (CurrentScene.name);
		}
	}
}
