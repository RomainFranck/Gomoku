using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayOverColor : MonoBehaviour {

	// Use this for initialization
	Text col;
	void Start () {

		col = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pd()
	{
		col.color = Color.green;
		//sound
	}

	public void NotOver()
	{
		col.color = Color.black;
	}
}
