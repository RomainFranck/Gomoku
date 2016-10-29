using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeCinq : MonoBehaviour {

	public Sprite[] sprCinq;

	bool VCinq;

	public Image Cinq;
	// Use this for initialization
	void Start () {
		VCinq = false;
		Cinq = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckChangeCinq()
	{
		if (VCinq) {
			VCinq = false;

			Cinq.sprite = sprCinq [0];
		} else {
			VCinq = true;
			Cinq.sprite = sprCinq [1];
		}
	}
}
