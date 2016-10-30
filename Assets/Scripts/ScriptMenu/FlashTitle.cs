using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashTitle : MonoBehaviour {

	// Use this for initialization
	//public Sprite []Title;

	Image img;

	bool isBlnkink;
	int counter;
	int blinkspeed;

	void Start () {	
		counter = 0;
		blinkspeed = 100;
		img = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("Main Camera").GetComponent<MenuManager> ().isBlinking) {

			if (counter == blinkspeed) {
				counter = 0;
			}

			if (counter <= 50)
				isBlnkink = false;
			else
				isBlnkink = true;

			counter++;

			if (isBlnkink)
				img.enabled = true;
			else
				img.enabled = false;
		}
	}
	
}