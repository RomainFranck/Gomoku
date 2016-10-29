using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashTitle : MonoBehaviour {

	// Use this for initialization
	public Sprite []Title;

	Image img;

	//bool isBlnkink;
	int counter;
	int blinkspeed;

	void Start () {	
		counter = 0;
		blinkspeed = 300;
		img = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (counter);

		if (counter == blinkspeed) {
			counter = 0;
		}

		if (counter <= 100) {
			img.sprite = Title[0];
			
		} else if (counter <= 200) {
			img.sprite = Title[1];
		} else if (counter <= 300) {
			img.sprite = Title[2];
		}

		counter++;

		/*if (isBlnkink)
			img.enabled = true;
		else
			img.enabled = false;*/
	}
	
}