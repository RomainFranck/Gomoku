using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeRules : MonoBehaviour {

	public Sprite[] sprCinq;
	public Sprite[] sprDouble;

	bool VCinq;
	bool VDouble;

	public Image Cinq;
	public Image DoubleTrois;
	void Start () {
	
		VCinq = true;
		VDouble = false;
		//Cinq = GetComponent<Image> ().sprite;
		//DoubleTrois = GetComponent<Image> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	}

	/*public void ChangeCinq()
	{
		Debug.Log(Cinq.name);
		if (VCinq) {
			VCinq = false;

			Cinq = sprCinq [0];
		} else {
			VCinq = true;
			Cinq = sprCinq [1];
		}
	}

	public void ChangeDouble()
	{

		if (VDouble) {
			VDouble = false;
			DoubleTrois = sprDouble [0];
		} else {
			VDouble = true;
			DoubleTrois = sprDouble [1];
		}
			
	}*/

}
