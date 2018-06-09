using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour {

	public GameObject Player;
	private TacoScript tS;
	public GameObject Text;
	public GameObject Image;


	// Use this for initialization
	void Start () {

		tS = Player.GetComponent<TacoScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (tS.Cheese && tS.Tomato && tS.Salad) {

			StartCoroutine (BackToMenu ());

			Text.SetActive (enabled);
			Image.SetActive (enabled);
			Time.timeScale = 0;
		}

	}

	IEnumerator BackToMenu()
	{

		yield return new WaitForSecondsRealtime (2);

		SceneManager.LoadScene ("BetweenGames");

	}
}
