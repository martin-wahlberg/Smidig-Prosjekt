using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {
	
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

	private FishScript _fS;
	public float Speed;



	// Use this for initialization
	void Start () {

		GameObject Fish = GameObject.FindGameObjectWithTag ("Player");
		_fS = Fish.GetComponent<FishScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		Speed = _fS.Speed;

		spawnCycle = Random.Range (rST1, rST2);

		timeElapsed += Time.deltaTime * Speed;	

		if (timeElapsed > spawnCycle) {
				
		if (RandomOrder) 	{
				
				MyIndex = Random.Range (0, (enemy.Length));

		} 
			if (MyIndex < 4) {
				enemy [MyIndex].transform.position = new Vector3 (rRX1, rRY1,transform.position.z);
			} else {
				enemy [MyIndex].transform.position = new Vector3 (Random.Range (rRX1, rRX2), Random.Range (rRY1, rRY2), transform.position.z);
			}

			Instantiate (enemy[MyIndex]);		
			timeElapsed = 0;
		
		}
	
	}
}
