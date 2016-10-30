using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	public GameObject MainMenu;
	public GameObject RulesObject;
	public GameObject ModeObject;

	public RectTransform titleMenu;

	public RectTransform[] t_Title;

	public bool isFallingDownFinished = false;

	float otherTime = 1000;

	public enum e_MenuState{
	
		Main, 
		Rules,
		Mode,
		Idle,
	};
	public e_MenuState menuState = e_MenuState.Idle;

	void Start () {
		for (int i = 0; i < t_Title.Length; i++)
			StartCoroutine(letterFall(t_Title[i]));
	}
	
	// Update is called once per frame
	void Update () {
		switch (menuState) {
		case(e_MenuState.Rules):

			MainMenu.SetActive (false);
			RulesObject.SetActive (true);
			break;
		case(e_MenuState.Mode):

			MainMenu.SetActive (false);
			ModeObject.SetActive (true);
			break;

		case(e_MenuState.Main):

			MainMenu.SetActive (true);
			ModeObject.SetActive (false);
			RulesObject.SetActive (false);
			break;
		default: 
			menuState = e_MenuState.Idle;
			break;
		}
		if (isFallingDownFinished) 
		{
			for (int i = 0; i < t_Title.Length; i++)
				t_Title [i].gameObject.SetActive (false);
			titleMenu.gameObject.SetActive (true);
			isFallingDownFinished = false;
			StartCoroutine (titleUp ());
		}
	}

	IEnumerator titleUp()
	{
		while (titleMenu.localPosition.y < 435) 
		{
			titleMenu.localPosition = new Vector3 (titleMenu.localPosition.x, titleMenu.localPosition.y + Time.deltaTime * otherTime, 0);
			yield return null;
		}
	}

	IEnumerator letterFall(RectTransform p_rect)
	{
		float randTime = Random.Range (-200, 200);

		while (p_rect.localPosition.y > (-100)) {
			p_rect.localPosition = new Vector3 (p_rect.localPosition.x, p_rect.localPosition.y - Time.deltaTime * (otherTime + randTime), 0);
			yield return null;
			isFallingDownFinished = false;
		}
		p_rect.localPosition = new Vector3 (p_rect.localPosition.x, -100, 0);
		isFallingDownFinished = true;
	}

	public void setMenuState(string p_menuState)
	{
		switch (p_menuState) {
		case("main"):
			menuState = e_MenuState.Main;
			break;
		case("mode"):
			menuState = e_MenuState.Mode;
			break;
		case("rules"):
			menuState = e_MenuState.Rules;
			break;
		}
	}

	public void Play()
	{
		Application.LoadLevel ("Checkboard");
	}

	public void Rules()
	{
		
	}

	public void Quit()
	{
		Application.Quit ();
	}
		
	/*void OnMouseDown()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Debug.Log("passe");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, 100)) 
			{
				if (hit.transform.gameObject.name == "Joueur")
					Application.LoadLevel ("Checkboard");
			}
		}*/
	}
