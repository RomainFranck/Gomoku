using UnityEngine;
using System.Collections;

public class Checkerboard : MonoBehaviour {

	public GameObject Intersection;

	int posX;
	int posY;
	Pawn[][] pawnList;

		void Start () {

		Intersection.GetComponent<Pawn> ();
			
			pawnList = new Pawn[18][];
			for (int i = 0; i < 18; i++) 
			{
				pawnList [i] = new Pawn[18];
				for (int a = 0; a < 18; a++) 
				{
					Pawn tmp = (Pawn)Instantiate (Intersection.GetComponent<Pawn>(), new Vector3 (i, a, 0), Quaternion.identity);
					pawnList[i][a] = tmp;
				}
			}
			pawnList [1] [1].SetColor (Board.e_cell.Black);
		}
	
	// Update is called once per frame
	void Update () {


	}
}
