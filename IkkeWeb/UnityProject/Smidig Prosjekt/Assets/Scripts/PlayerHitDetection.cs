using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHitDetection : MonoBehaviour {

	private float dailyScore;

	public GameObject Model1;
	public GameObject Model2;
	public GameObject Model3;

	public GameObject ScoreText;
	private Text _scoreText;

	public float _points;


	void Start(){
		dailyScore = PlayerPrefs.GetFloat("dailyscore");
		_scoreText = ScoreText.GetComponent<Text> ();

	}

	void Update(){

		if (_scoreText != null) {

			if (_points < 600) {
				_scoreText.text = "Du mangler " + (600 - _points).ToString ("F0") + " poeng for å vinne.";
			} else {
				_scoreText.text = "Du har nok poeng for å vinne.";
			}
			if (Model1 != null && Model2 != null && Model3 != null) {

				if (_points < 200) {
					Model1.SetActive (true);
					Model2.SetActive (false);
					Model3.SetActive (false);
				} else if (_points < 400) {
					Model1.SetActive (false);
					Model2.SetActive (true);
					Model3.SetActive (false);
				} else {
					Model1.SetActive (false);
					Model2.SetActive (false);
					Model3.SetActive (true);
				}
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {

			gameObject.SetActive(false);
			Invoke ("ReloadScene", 0.2f);

		}

		if (other.tag == "Candy") {
			CandyPickUp CP;
			CP = other.GetComponent<CandyPickUp> ();

			_points += CP.PointValue;

			Destroy (other.gameObject);
		
		}

	}

	void ReloadScene()
	{

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

	}
}
