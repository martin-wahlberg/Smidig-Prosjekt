using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScript : MonoBehaviour {

	public GameObject Player;
	private DroneScript _droneScript;

	private Text _text; 


	// Use this for initialization
	void Start () {
		_droneScript = Player.GetComponent<DroneScript> ();
		_text = this.GetComponent<Text> ();
		;

	}
	
	// Update is called once per frame
	void Update () {

		_text.text = (8 - _droneScript.DroneDeliveries) + " remaining.";

	}

	public void DisableUI(){
		StartCoroutine (WaitForSeconds());
	}

	IEnumerator WaitForSeconds (){
		yield return new WaitForSeconds (2);
		GameObject.FindGameObjectWithTag("Board").SetActive (false);
	}
}
