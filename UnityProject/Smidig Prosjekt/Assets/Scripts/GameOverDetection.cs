using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDetection : MonoBehaviour {

	private GameObject _player;
	private FishScript _fS;

	public bool replay = false;

	// Use this for initialization
	void Awake () {
		_player = GameObject.FindGameObjectWithTag ("Player");
		_fS = _player.GetComponent<FishScript> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (_player != isActiveAndEnabled) {

			_player = GameObject.FindGameObjectWithTag ("Player");

			if (_player != isActiveAndEnabled) {

				if (SceneManager.GetActiveScene ().name == "SwimmingFish") {

					PlayerPrefs.SetFloat ("dailyscore", _fS.CurrentPoints);
					PlayerPrefs.SetFloat ("timeSpent", _fS._GameOverTime);

					if (_fS._GameOverTime < 600) {

						SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

					} else {
						SceneManager.LoadScene ("BetweenGames");

					}


				}
				else if (!replay) {
					SceneManager.LoadScene ("BetweenGames");
				} else {
					SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				}
			}
		}
	}
}
