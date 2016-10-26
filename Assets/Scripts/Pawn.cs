using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour
{
	public Renderer rend;

	public int x;
	public int y;

	void Start()
	{

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
			rend.material.color = Color.blue;
			break;
		case Board.e_cell.White:
			rend.enabled = true;
			rend.material.color = Color.red;
			break;
		case Board.e_cell.Empty:
			rend.enabled = false;
			break;
		}
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
            Arbiter.Instance.input(x, y);
		}
	}
}