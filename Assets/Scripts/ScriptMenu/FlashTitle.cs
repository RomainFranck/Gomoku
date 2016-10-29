using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashTitle : MonoBehaviour {

	// Use this for initialization
	public Image img;
	bool isBlnkink;
	int counter;
	int blinkspeed;

	void Start () {	
		img = GetComponent<Image> ();
		isBlnkink = false;
		counter = 0;
		blinkspeed = 100;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (counter);

		if (counter == blinkspeed) {
			counter = 0;
		}

		if (counter > (blinkspeed / 2)) {
			isBlnkink = true;
			
		} else if (counter <= (blinkspeed / 2)) {
			isBlnkink = false;
		}

		counter++;

		if (isBlnkink)
			img.enabled = true;
		else
			img.enabled = false;
	}
	
}