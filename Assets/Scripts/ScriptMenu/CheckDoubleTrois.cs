using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckDoubleTrois : MonoBehaviour {

	public Sprite[] sprDouble;

	bool VDoubleTrois;

	public Image DoubleTrois;
	// Use this for initialization
	void Start () {
		VDoubleTrois = false;
		DoubleTrois = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void CheckChangeDoubleTrois()
	{
		if (VDoubleTrois) {
			VDoubleTrois = false;

			DoubleTrois.sprite = sprDouble [0];
		} else {
			VDoubleTrois = true;
			DoubleTrois.sprite = sprDouble [1];
		}
	}
}
