using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneSwitchScript : MonoBehaviour {

	public string[] sceneNames;

	public GameObject scoreText;
	private Text dailyScoreText;


	public void Start()
	{
		
		Time.timeScale = 1;

		if (scoreText != null) {

			dailyScoreText = scoreText.GetComponent<Text> ();
		
			dailyScoreText.text = "Poeng til neste billett: " + PlayerPrefs.GetFloat ("dailyscore").ToString ("F0");
		}
	}

	public void LoadScene(string name){

		SceneManager.LoadScene (name);
	}

	public void RandomScene()

	{
		SceneManager.LoadScene (sceneNames[Random.Range (0, sceneNames.Length)]);
	}
}
