using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlalomScript : MonoBehaviour {


	public Camera Camera;
	private Vector3 _mousePosition;
	public Vector2 _target;
	public float transformX;
	public float speed;

	private float angleW;
	private float angleE;

	public PlayerHitDetection scoreScript; 

	public void Awake(){

		scoreScript = this.GetComponent<PlayerHitDetection> ();
	}

	public void Update()
	{
		var mousePos = Input.mousePosition;
		mousePos.z = 10; // select distance = 10 units from the camera
		_mousePosition = (Camera.ScreenToWorldPoint(mousePos));
		_target = new Vector2 (_mousePosition.x, transform.position.y);
		transformX = transform.position.x;

		if (transformX > 9) {
			transform.position = new Vector2(9, transform.position.y);
		}

		if (transformX < -9){
			transform.position = new Vector2(-9, transform.position.y);
		}

		if (this.transform.position.y >= 3f) {

			GameOver ();

		}

		transform.position = Vector2.MoveTowards (transform.position, _target, speed * Time.deltaTime);

	}

	void GameOver(){

		if (scoreScript._points >= 600) {

			SceneManager.LoadScene ("BetweenGames");
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

	}
}
