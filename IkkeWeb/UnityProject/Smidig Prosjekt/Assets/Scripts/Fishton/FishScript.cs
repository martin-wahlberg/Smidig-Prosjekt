using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FishScript : MonoBehaviour {

	public float Speed = 2f;
	public float LevelTimer;
	public float swimmingPosition;
	private float _timer;
	private bool _chasingScene = false;


	public GameObject curText;
	private Text cT;
	public float CurrentPoints;

	public float _GameOverTime;
	private float _TotalTimeSpent;



	void Awake(){
		
		CurrentPoints = PlayerPrefs.GetFloat ("dailyscore");

		cT = curText.GetComponent<Text> ();

		_TotalTimeSpent = PlayerPrefs.GetFloat ("timeSpent");
	}

	void FixedUpdate(){

		_GameOverTime = _TotalTimeSpent + (Time.time * _timer)/5;

		//Point dsitrubution

		if (!_chasingScene && CurrentPoints >= 0) {
			CurrentPoints += Speed / 50;

		} 
		if (_chasingScene && CurrentPoints >= 0){
			CurrentPoints += Speed / 20;
		}

		cT.text = "Points: "+CurrentPoints.ToString("F0");

		_timer += Time.deltaTime;
		Speed = 2f + 0.1f * _timer;
	

		LevelTimer += Speed/60;

		if (LevelTimer > 60 && _chasingScene == false) {

			float transition = Mathf.MoveTowards (transform.position.x, 0, 1f * Time.deltaTime);
			transform.position = new Vector3 (transition, transform.position.y, transform.position.z);

			if (transform.position.x >= 0) {

				_chasingScene = true;

			}
		}
	
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Wall"){

			float upwards = 0;
			upwards += 0.2f;

			transform.position = new Vector3
				(transform.position.x, transform.position.y + upwards, transform.position.z);

		}
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if (other.tag == "Cheese") {
			_timer = _timer * 0.7f;
		} else if (other.tag == "Tomato") {

			Destroy (gameObject);
		} else if (other.tag == "Salad") {
			_timer = _timer + 11f;
			StartCoroutine (SpeedBoostFade ());
		} else if (other.tag == "Board") {



		}
	}

	IEnumerator SpeedBoostFade(){

		yield return new WaitForSeconds (2);

		_timer = _timer - 10f;
		
	}
}
