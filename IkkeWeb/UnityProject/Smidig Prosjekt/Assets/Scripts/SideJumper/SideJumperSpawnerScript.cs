using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideJumperSpawnerScript : MonoBehaviour {

	private GameObject[] SpawnPoints;
	public GameObject Enemies;

	private int rand1;
	private int rand2;
	private int prevRand1;
	private bool gate1open = false;
	private bool gate2open = false;
	private bool gate3open = false;

	private float timer = 0;
	public float timerTarget;

	public float minimumTimer;
	public float timerDecrease;


	void Start () {
		SpawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
	}

	void Update () {

		//Random spawn pattern


		if (gate1open == false) {
			rand1 = Random.Range (0, 3);
			if (rand1 != prevRand1) {
				gate1open = true;
			} else {
				return;
			}
		}
		if (gate2open == false) {
			
			prevRand1 = rand1;
			rand2 = Random.Range (0, 3);

			if (rand1 == rand2) {
				
				return;
			} else {
				gate2open = true;
			}
		}

		//Timer

		timer += Time.deltaTime;

		if (gate1open == true && gate2open == true) {

			if (timer >= timerTarget) {
				Spawn ();
			}

		}

	}

	void Spawn(){
		if (timerTarget > minimumTimer) {
			timerTarget = timerTarget * 0.95f;
		}

		if (timerTarget < minimumTimer	 && gate3open == false) {
			timerTarget -= timerDecrease;
			gate3open = true;
		}

		Instantiate (Enemies, SpawnPoints [rand1].gameObject.transform.position, Quaternion.Euler(new Vector3(220,0,180)));
		if (gate3open == false) {
			Instantiate (Enemies, SpawnPoints [rand2].gameObject.transform.position,Quaternion.Euler(new Vector3(220,0,180)));
		}

		timer = 0f;
		gate1open = false;
		gate2open = false;
	}
}
