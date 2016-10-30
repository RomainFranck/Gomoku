using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayOverColor : MonoBehaviour {

	// Use this for initialization
	RectTransform coll;


	float Wbase;
	float Hbase;
	float Wup = 600;
	float Wdown = 407;
	float Hup = 100;
	float Hdown = 74;
    float ActionTime = 0.2f;
	int k;
	float i;
	float j;
	bool turnOrNot;

	void Start () {

		turnOrNot = false;
		//col = GetComponent<Image> ();
		coll = GetComponent<RectTransform> ();

		Wbase = GetComponent<RectTransform> ().rect.width;
		Hbase = GetComponent<RectTransform> ().rect.height;
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
        StopAllCoroutines();
		StartCoroutine (scaleUp());
	}

    public void NotOver()
    {
        StopAllCoroutines();
        StartCoroutine(scaleDown());
    }

    public void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(scaleDown());
    }

    IEnumerator scaleDown()
	{
        float W = GetComponent<RectTransform>().rect.width;
        float H = GetComponent<RectTransform>().rect.height;

        float time = Time.timeSinceLevelLoad; // 5

		while (Time.timeSinceLevelLoad - time < (ActionTime * (W - Wdown)/(Wup - Wdown))) 
		{
			coll.sizeDelta = new Vector2 (W - (W - Wdown) * (Time.timeSinceLevelLoad - time) / ActionTime, H - (H - Hdown) * (Time.timeSinceLevelLoad - time) / ActionTime);
			yield return null;
		}
	}

	IEnumerator scaleUp()
	{
        float W = GetComponent<RectTransform>().rect.width;
        float H = GetComponent<RectTransform>().rect.height;

        float time = Time.timeSinceLevelLoad; // 5

		while (Time.timeSinceLevelLoad - time < (ActionTime * (Wup - W)/(Wup - Wdown)))
		{
			coll.sizeDelta = new Vector2 (W + (Wup - W) * (Time.timeSinceLevelLoad - time) / ActionTime, H + (Hup - H) * (Time.timeSinceLevelLoad - time) / ActionTime);
			yield return null;
		}
	}
}