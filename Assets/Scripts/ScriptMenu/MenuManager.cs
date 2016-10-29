using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	public GameObject MainMenu;
	public GameObject RulesObject;
	public GameObject ModeObject;


	public enum e_MenuState{
	
		Main, 
		Rules,
		Mode,
	};
	public e_MenuState menuState;

	void Start () {

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
		}
			

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
