using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int PlayerNumber;
	private Text TXT;

	// Use this for initialization
	void Start () {
		TXT = GameObject.Find("Player" + PlayerNumber + "Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (PlayerNumber) {
		case 1:
			TXT.text = /*"Captured pawns: " + */Arbiter.Instance.player1.capturedPawns.ToString();
			break;
		
		case 2:
			TXT.text = /*"Captured pawns: " + */Arbiter.Instance.player2.capturedPawns.ToString();
			break;
		}
	}
}
