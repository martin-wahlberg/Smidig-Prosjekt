using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthScript : MonoBehaviour {

	public Sprite FilledHeart;
	public Sprite EmptyHeart;

	public int HeartNumber;

	public GameObject Player;
	private FenceJumpScript fJS;

	private Image img;

	// Use this for initialization
	void Start () {

		fJS = Player.GetComponent<FenceJumpScript> ();
		img = GetComponent<Image> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (fJS.HitPoints >= HeartNumber) {

			img.sprite = FilledHeart;

		} else {

			img.sprite = EmptyHeart;
		}
		
	}
}
