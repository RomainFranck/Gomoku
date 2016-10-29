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
	bool turnOrNot;

	void Start () {

		turnOrNot = false;
		//col = GetComponent<Image> ();
		coll = GetComponent<RectTransform> ();

		W = GetComponent<RectTransform> ().rect.width;
		H = GetComponent<RectTransform> ().rect.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (turnOrNot)
			transform.Rotate (Vector3.forward * (Time.deltaTime * 15));
	}

	public void TurnAround()
	{
		turnOrNot = true;
	}

	public  void DontTurnAround()
	{
		turnOrNot = false;
	}

	public void Over()
	{
		StartCoroutine (scaleUp());
		
		//for (float j = 50; j > 0; j--)
		//	coll.rect.size.x -= 1f;
	}

	IEnumerator scaleDown()
	{
		float time = Time.timeSinceLevelLoad; // 5

		while (Time.timeSinceLevelLoad - time < 1) 
		{
			coll.sizeDelta = new Vector2 (Wup - (Wup - Wdown) * (Time.timeSinceLevelLoad - time), H);
			yield return null;
		}
	}

	IEnumerator scaleUp()
	{
		float time = Time.timeSinceLevelLoad; // 5

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
