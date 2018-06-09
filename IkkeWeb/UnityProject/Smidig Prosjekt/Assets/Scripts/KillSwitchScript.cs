using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitchScript : MonoBehaviour {

	public bool CandyLand = false;
	public GameObject Player;



	void OnTriggerEnter2D (Collider2D other)
	{
		if (CandyLand == true) {

			Player.transform.position = new Vector2 (Player.transform.position.x, Player.transform.position.y + 0.5f);

		}
			
		Destroy (other.gameObject);

	}
}
