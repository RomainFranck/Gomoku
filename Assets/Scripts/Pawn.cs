using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour
{
	public Renderer rend;
	void Start()
	{
		rend = gameObject.GetComponent<Renderer> ();
	}

	void Update()
	{

	}

	public void SetColor(Board.e_cell newColor)
	{
		rend = gameObject.GetComponent<Renderer> ();

		switch (newColor) {
		case Board.e_cell.Black:
			rend.enabled= true;
			rend.material.color = Color.black;
			break;
		case Board.e_cell.White:
			rend.enabled = true;
			rend.material.color = Color.white;
			break;
		case Board.e_cell.Empty:
			rend.enabled = false;
			break;
		}
	}
}