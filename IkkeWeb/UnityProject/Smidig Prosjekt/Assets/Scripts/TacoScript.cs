using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TacoScript : MonoBehaviour {

	public bool Cheese;
	public bool Tomato;
	public bool Salad;

	public GameObject CheeseSprite;
	public GameObject TomatoSprite;
	public GameObject SaladSprite;

	private float dailyScore;

	// Use this for initialization
	void Start () {
		Cheese = false;
		Tomato = false;
		Salad = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Cheese") {
			if (Cheese == false) {
				dailyScore -= 100;
			}
			Cheese = true;
			CheeseSprite.SetActive(true);
			Destroy (other.gameObject);
		}
		if (other.tag == "Tomato") {
			if (Tomato == false) {
				dailyScore -= 100;
			}
			Tomato = true;
			TomatoSprite.SetActive(true);
			Destroy (other.gameObject);
		}
		if (other.tag == "Salad") {
			if (Salad == false) {
				dailyScore -= 100;
			}
			Salad = true;
			SaladSprite.SetActive(true);
			Destroy (other.gameObject);
		}
		if (Salad && Tomato && Cheese) {

			dailyScore -= 300;

			PlayerPrefs.SetFloat ("dailyscore", dailyScore);

			BackToMenu ();

		}
	}

	void BackToMenu()
	{
		SceneManager.LoadScene ("BetweenGames");
	}
}
