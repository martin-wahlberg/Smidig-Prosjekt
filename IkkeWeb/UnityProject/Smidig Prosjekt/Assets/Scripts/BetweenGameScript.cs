using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BetweenGameScript : MonoBehaviour {



	public GameObject uiText;
	private Text uiT;
	private float dailyPoints;

	public string[] sceneNames;

	private bool _isWin;

	// Use this for initialization
	void Start () {

		PlayerPrefs.SetFloat ("timeSpent", 0);
		uiT = uiText.GetComponent<Text> ();
		PlayerPrefs.SetFloat ("dailyscore", 0);
		PlayerPrefs.SetFloat ("numberclears", 0);

	}
	
	// Update is called once per frame
	void Update () {
		
		uiT.text = "Du vant, ett poeng er lagt til.";
		
	}


	public void LoadScene(string name){

		SceneManager.LoadScene (name);
	}

	public void RandomGame(){

		SceneManager.LoadScene (sceneNames[Random.Range (0, sceneNames.Length)]);
	}

}
