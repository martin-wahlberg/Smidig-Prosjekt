using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour {

	public float SharkSpeed = 5f;

	private bool inForeground = false;
	private SpriteRenderer sR;
	private GameObject Player;
	private FishScript fS;
	private BoxCollider2D bC;

	void Start () {
		sR = this.GetComponent<SpriteRenderer> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
		fS = Player.GetComponent<FishScript> ();

		bC = GetComponent<BoxCollider2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (fS.LevelTimer > 60  && !inForeground) {

			inForeground = true;
		}


		if (!inForeground) {
			float swimmingPosition = fS.LevelTimer*0.4f;

			this.transform.position = new Vector3 (10 - swimmingPosition, transform.position.y, 15);
			this.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
			sR.color = new Color (0.2f, 0.2f, 0.2f);


			bC.enabled = false;

		} else {

			SharkSpeed += Time.fixedDeltaTime / 30;
				
			this.transform.position = new Vector3 (transform.position.x, Mathf.Lerp (this.transform.position.y, Player.transform.position.y, Time.deltaTime), 5);
		
			if (this.transform.position.x > -20f) { 
				this.transform.position += new Vector3 ((SharkSpeed - fS.Speed) * Time.deltaTime, 0,0);
			} else {
				
				this.transform.position += new Vector3 (Mathf.Abs(SharkSpeed - fS.Speed) * Time.deltaTime, 0, 0);

			}

			this.transform.localScale = new Vector3 (-1f, 1f, 1f);
			sR.color = Color.white;

			bC.enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other){


		if (other.tag == "Player") {
			print ("Game over");
			Destroy (other.gameObject);
		}
	}
}
