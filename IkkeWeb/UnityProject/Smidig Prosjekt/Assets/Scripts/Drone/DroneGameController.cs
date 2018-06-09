using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DroneGameController : MonoBehaviour {

	public Text DeliveryCount;
	public List<GameObject> DeliveryPoints;

	public GameObject PlatformSpawner;
	private DeliverySpawnerScript spawnScript;

	private bool MadeList = false;


	// Use this for initialization
	void Start () {
		
		spawnScript = PlatformSpawner.GetComponent<DeliverySpawnerScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (spawnScript.amount == spawnScript.MaxDeliveries) {


			if (MadeList == false) {
				DeliveryPoints.AddRange (GameObject.FindGameObjectsWithTag ("LandingPlatform"));
				MadeList = true;
			}

			DeliveryPoints.RemoveAll (GameObject => GameObject == null);
			DeliveryCount.text = DeliveryPoints.Count + " deliveries remaining.";

			if (DeliveryPoints.Count == 0) {
				DeliveryCount.text = "You win!";
				StartCoroutine (BackToMenu ());
			}
		}
	}
	IEnumerator BackToMenu()
	{



		yield return new WaitForSecondsRealtime (2);

		SceneManager.LoadScene ("BetweenGames");

	}
}


