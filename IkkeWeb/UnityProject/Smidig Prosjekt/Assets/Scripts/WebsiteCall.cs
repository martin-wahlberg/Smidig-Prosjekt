using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteCall : MonoBehaviour {

	public int Poeng;

	void Awake(){
		GameWinTrue(Poeng);	
	}

	void Update(){
	/*
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			Poeng = 1;
			GameWinTrue(Poeng);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Poeng = 2;
			GameWinTrue(Poeng);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Poeng = 3;
			GameWinTrue(Poeng);
		}
		*/
	}

	public void GameWinTrue (int points) {


		Application.ExternalCall ("gameWinTrue", points);
		
	}
}
