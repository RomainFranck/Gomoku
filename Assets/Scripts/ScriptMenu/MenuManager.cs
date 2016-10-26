using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play()
	{
		Application.LoadLevel ("Checkboard");
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
