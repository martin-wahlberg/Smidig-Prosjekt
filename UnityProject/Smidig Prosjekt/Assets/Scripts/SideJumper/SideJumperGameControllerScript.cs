using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SideJumperGameControllerScript : MonoBehaviour {

	private GameObject Player;

	public GameObject curText;
	public GameObject highText;
	public GameObject dailyText;

	private Text cT;
	private Text hT;
	private Text dT;

	private float curScore;
	private float highScore;
	private float dailyScore;

	public GameObject Spawner;
	private SideJumperSpawnerScript sjss;
	private float difficultyRating;

	private bool endCalculationsDone = false;

	void Start(){
		Player = GameObject.FindGameObjectWithTag ("Player");

		cT = curText.GetComponent<Text> ();
		hT = highText.GetComponent<Text> ();
		dT = dailyText.GetComponent<Text> ();

		highScore = PlayerPrefs.GetFloat ("SJhighscore");
		dailyScore = PlayerPrefs.GetFloat ("dailyscore");

		Spawner = GameObject.FindGameObjectWithTag ("Spawner");
		sjss = Spawner.GetComponent<SideJumperSpawnerScript> ();

	}


	void Update () {

		//UI
		cT.text = "Score: "+curScore.ToString("F0");
		hT.text = "HighScore: " + highScore.ToString("F0");

		if (dailyScore < 500) {
			dT.text = "Poeng til du er ferdig: " + (500 - dailyScore).ToString ("F0");
		} else {
			dT.text = "Du har nok poeng nå";
		}
		//Calculations

		if (Player.activeInHierarchy == false && endCalculationsDone == false) {


			PlayerPrefs.SetFloat ("dailyscore", dailyScore);

			if (highScore < curScore) {
				PlayerPrefs.SetFloat ("SJhighscore", curScore);
			} else {
			}

			ReloadScene ();
			}

			
		 else {

			difficultyRating = sjss.timerTarget;
			
			dailyScore += (Time.deltaTime*10/difficultyRating);
			curScore += (Time.deltaTime*10/difficultyRating);
		}
		
	}

	void ReloadScene (){

		if (dailyScore > 500) {
			SceneManager.LoadScene ("BetweenGames");
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}
}
