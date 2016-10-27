using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayOverColor : MonoBehaviour {

	// Use this for initialization
	RectTransform coll;


	float W;
	float H;
	float Wup = 600;
	float Wdown = 407;
	float Hup = 100;
	float Down = 74;
	int k;
	float i;
	float j;

	void Start () {

		//col = GetComponent<Image> ();
		coll = GetComponent<RectTransform> ();

		W = GetComponent<RectTransform> ().rect.width;
		H = GetComponent<RectTransform> ().rect.height;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void TurnAround()
	{
		//gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gam
	}

	public void Over()
	{
		StartCoroutine (scaleUp());
		
		//for (float j = 50; j > 0; j--)
		//	coll.rect.size.x -= 1f;
	}

	IEnumerator scaleDown()
	{
		float time = Time.timeSinceLevelLoad;

		while (Time.timeSinceLevelLoad - time < 1) 
		{
			coll.sizeDelta = new Vector2 (Wup - (Wup - Wdown) * (Time.timeSinceLevelLoad - time), H);
			yield return null;
		}
	}

	IEnumerator scaleUp()
	{
		float time = Time.timeSinceLevelLoad;

		while (Time.timeSinceLevelLoad - time < 1) 
		{
			coll.sizeDelta = new Vector2 (W + (Wup - W) * (Time.timeSinceLevelLoad - time), H);
			yield return null;
		}
	}

	public void NotOver()
	{
		StartCoroutine (scaleDown ());
		//coll.rect.height = H;
		//coll.rect.width = W;
	}
}
