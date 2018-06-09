using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakoutBall : MonoBehaviour {

	private Rigidbody2D _rB;
	private GameObject _player;

	public bool Red;
	public bool Blue;

	public float SpeedIncrease;
	private float MaxSpeed;

	public GameObject[] ExtraBall;
	public GameObject BlockSpawnerObject;

	private BlockSpawner _spawnScript;

	public GameObject ScoreText;
	private Text _texty;


	// Use this for initialization
	void Awake () {

		ScoreText = GameObject.FindGameObjectWithTag("Score");
		BlockSpawnerObject = GameObject.FindGameObjectWithTag ("Board");

		 MaxSpeed = 8;
		_rB = this.GetComponent<Rigidbody2D> ();

		_rB.AddForce(new Vector3 (Random.Range(-400, 400), -100, 0));

		_player = GameObject.FindGameObjectWithTag ("Salad");

		_spawnScript = BlockSpawnerObject.GetComponent<BlockSpawner> ();

		_texty = ScoreText.GetComponent<Text> ();


	}
	
	// Update is called once per frame
	void Update () {

		_rB.velocity = new Vector2(Mathf.Clamp (_rB.velocity.x, -MaxSpeed,MaxSpeed), Mathf.Clamp (_rB.velocity.y, -MaxSpeed,MaxSpeed));

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Candy" || other.gameObject.tag == "Meat") {
			int random = Random.Range (0, 5);
			if (random == 0) {
				Instantiate (ExtraBall[Random.Range(1,3)], other.transform.position, Quaternion.identity);
			}

			Destroy (other.gameObject);
		} 

		if (other.gameObject.tag == "Tomato") {

			GameObject[] _greenBlocks;

			_greenBlocks = GameObject.FindGameObjectsWithTag ("Tomato");

			int longness = _greenBlocks.Length - 1;
			_texty.text = "Blocks remaining: " + longness;

			if (_greenBlocks.Length <= 1) {

				GameObject[] _reds = GameObject.FindGameObjectsWithTag ("Meat");

				for (int i = 0; i > _reds.Length; i++) {
					Destroy (_reds [i]);
				}

				GameObject[] _blues = GameObject.FindGameObjectsWithTag ("Candy");

				for (int i = 0; i > _blues.Length; i++) {
					Destroy (_blues [i]);
				}


				_spawnScript.SpawnBlocks ();

			}

			Destroy (other.gameObject);
		}

	}

	void OnTriggerExit2D (Collider2D other){

		if (other.gameObject.tag == "Player") {

			CircleCollider2D cc2d = this.GetComponent<CircleCollider2D>();

			cc2d.isTrigger = false;

		}
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "Player") {

			CircleCollider2D cc2d = this.GetComponent<CircleCollider2D>();

			cc2d.isTrigger = true;
		}

		if (other.gameObject.tag == "Wall") {

			_rB.velocity = new Vector2 (_rB.velocity.x * -1, _rB.velocity.y);

		}
		if (other.gameObject.tag == "Cheese") {

			_rB.velocity = new Vector2 (_rB.velocity.x, _rB.velocity.y * -1);

		}

		if (other.gameObject.tag == "Candy") {

			if (Blue) {
				int random = Random.Range (0, 5);
				if (random == 0) {
					Instantiate (ExtraBall[Random.Range(1,3)], other.transform.position, Quaternion.identity);
				}

				Destroy (other.gameObject);
			}
		} else if (other.gameObject.tag == "Meat") {

			if (Red) {
				int random = Random.Range (0, 5);
				if (random == 1) {
					Instantiate (ExtraBall[Random.Range(1,3)], other.transform.position, Quaternion.identity);
				}

				Destroy (other.gameObject);
			}
		}

		if (other.gameObject.tag == "Salad") {

			if (_rB.velocity.y < 0) {


				float paddlePos = _player.transform.position.x;
				float paddleMult = 3 * (this.transform.position.x - paddlePos);

				_rB.velocity = new Vector2 (_rB.velocity.x/2 + paddleMult, 
					((_rB.velocity.y) * -1) + SpeedIncrease);

				}
			}
		
	}
}
