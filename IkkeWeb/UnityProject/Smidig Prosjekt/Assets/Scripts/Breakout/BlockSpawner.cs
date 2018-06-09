using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockSpawner : MonoBehaviour {

	public List<GameObject> Blocks = new List<GameObject>();

	private Vector2 _startingPosition;

	private float _clears;

	// Use this for initialization
	void Start () {



		_clears = PlayerPrefs.GetFloat ("numberclears") - 1;
		PlayerPrefs.SetFloat ("numberclears", _clears);
		print ("You have cleared the screen " + _clears + " times.");

		_startingPosition = this.transform.position;

		SpawnBlocks ();

		
	}

	public void SpawnBlocks()
	{
		_clears = PlayerPrefs.GetFloat ("numberclears") + 1;
		PlayerPrefs.SetFloat ("numberclears", _clears);
		print ("You have cleared the screen " + _clears + " times.");



		if (_clears >= 3) {
			SceneManager.LoadScene ("BetweenGames");
		}

		transform.position = _startingPosition;

		for (int i = 0; i < 15; i++) {
			

			Instantiate (Blocks[Random.Range(0, 5)], transform.position, Quaternion.identity);
			transform.position = new Vector2 (transform.position.x + 1f, transform.position.y);
		}

		transform.position = new Vector2 (_startingPosition.x, _startingPosition.y - 0.5f);
		for (int i = 0; i < 15; i++) {


			Instantiate (Blocks[Random.Range(0, 5)], transform.position, Quaternion.identity);
			transform.position = new Vector2 (transform.position.x + 1f, transform.position.y);
		}
		transform.position = new Vector2 (_startingPosition.x, _startingPosition.y - 1f);
		for (int i = 0; i < 15; i++) {


			Instantiate (Blocks[Random.Range(0, 5)], transform.position, Quaternion.identity);
			transform.position = new Vector2 (transform.position.x + 1f, transform.position.y);
		}
		transform.position = new Vector2 (_startingPosition.x, _startingPosition.y - 1.5f);
		for (int i = 0; i < 15; i++) {


			Instantiate (Blocks[Random.Range(0, 5)], transform.position, Quaternion.identity);
			transform.position = new Vector2 (transform.position.x + 1f, transform.position.y);
		}
		transform.position = new Vector2 (_startingPosition.x, _startingPosition.y - 2f);
		for (int i = 0; i < 15; i++) {


			Instantiate (Blocks[Random.Range(0, 5)], transform.position, Quaternion.identity);
			transform.position = new Vector2 (transform.position.x + 1f, transform.position.y);
		}
	}
}
