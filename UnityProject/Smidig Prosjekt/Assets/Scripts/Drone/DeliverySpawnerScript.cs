using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySpawnerScript : MonoBehaviour {

	public GameObject[] SpawnPositions;
	public GameObject LandingPlatform;
	public GameObject SpawnObject;

	public int MaxDeliveries;
	public int amount;

	void Start () {

		SpawnPositions = GameObject.FindGameObjectsWithTag ("SpawnPoint");

		for (int i= 0; i < 3; i++) {
			SpawnPlatform ();
		}

	}

	void Update(){

	}

	public void SpawnPlatform(){
		SpawnObject = SpawnPositions [Random.Range (0, SpawnPositions.Length)];

		if (SpawnObject == null) {
			return;
		}
		else
		{
			for (int i = 0; i < MaxDeliveries; i++) {

				Vector3 SpawnPosition = new Vector3 (SpawnObject.transform.position.x,
					                       SpawnObject.transform.position.y + 0.15f, SpawnObject.transform.position.z);

				Instantiate (LandingPlatform, SpawnPosition, Quaternion.identity);
				Destroy (SpawnObject);
				amount += 1;
			}
		}
	}
}
