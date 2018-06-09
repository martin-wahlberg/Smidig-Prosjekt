using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DronePlatformScript : MonoBehaviour {

	public GameObject Player;
	public GameObject Box;

	private Rigidbody2D rb;
	private DroneScript _droneScript;

	private DeliverySpawnerScript _spawnerScript;

	private GameObject[] _deliveriesLeft;

	public GameObject _uiScore;
	public CountScript _countScript;


	void Awake () {

		_uiScore  = GameObject.FindGameObjectWithTag ("Board");
		_countScript = GameObject.FindGameObjectWithTag("DeliveryCount").GetComponent<CountScript> ();
		_countScript.DisableUI ();

		Player = GameObject.FindGameObjectWithTag ("Player");
		rb = Player.GetComponent<Rigidbody2D> ();
		_droneScript = Player.GetComponent<DroneScript> ();
		_spawnerScript = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<DeliverySpawnerScript> ();


	}


	private void OnTriggerEnter2D (Collider2D other){


		if (other.tag == "Candy") {
			_uiScore.SetActive (true);

			rb.velocity = new Vector2 (rb.velocity.x*0.5f,rb.velocity.y*0.5f);

			_droneScript.Plain.SetActive(true);
			_droneScript.Box.SetActive (false);
			_droneScript.Snor.SetActive (false);

			Instantiate (Box);
			_spawnerScript.SpawnPlatform();

			_deliveriesLeft = GameObject.FindGameObjectsWithTag ("LandingPlatform");

			if (_deliveriesLeft.Length <= 0) {
				SceneManager.LoadScene ("BetweenGames");
			}
			_droneScript.DroneDeliveries += 1;


			_countScript.DisableUI();

			Destroy (gameObject);
		}
	}



	void RestartScene(){


		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
