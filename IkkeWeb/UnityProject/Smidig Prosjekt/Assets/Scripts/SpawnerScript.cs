using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public bool RandomOrder = true;

	public GameObject[] enemy;
	public bool randomSpawnTime;
	public float rST1;
	public float rST2;
	public float spawnCycle;
	public float timeElapsed;
	public float SpawnPosition;

	public float rRX1;
	public float rRX2;
	public float rRY1;
	public float rRY2;

	private int MyIndex;

	void Update () {

		if (randomSpawnTime == true) {
			spawnCycle = Random.Range (rST1, rST2);
		}

		timeElapsed += Time.deltaTime;

		if (timeElapsed > spawnCycle) {
			
			if (RandomOrder) {
				MyIndex = Random.Range (0, (enemy.Length));
			} else {
				if (MyIndex < enemy.Length) {
					MyIndex += 1;
				} else {
					MyIndex = 0;
				}
			}
				
			enemy [MyIndex].transform.position = new Vector3 (Random.Range (rRX1, rRX2), Random.Range (rRY1, rRY2), transform.position.z);
			Instantiate (enemy[MyIndex]);
			timeElapsed = 0;

		}
	}
}
