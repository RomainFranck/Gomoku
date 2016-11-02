using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int playerNumber;
	private Text _textComponent;

	// Use this for initialization
	void Start () {
		_textComponent = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (playerNumber) {
		case 1:
			_textComponent.text = Arbiter.Instance.player1.name + "\nCaptured pawns: " + Arbiter.Instance.player1.capturedPawns.ToString();
			break;
		
		case 2:
			_textComponent.text = Arbiter.Instance.player2.name + "\nCaptured pawns: " + Arbiter.Instance.player2.capturedPawns.ToString();
			break;
		}
	}
}
