using UnityEngine;
using System.Collections;

public class Checkerboard : MonoBehaviour
{
    private Board _board;

    public GameObject Intersection;

    int posX;
    int posY;
    Pawn[][] pawnList;

    void Start()
    {
        _board = Arbiter.Instance.board;

        Intersection.GetComponent<Pawn>();

        pawnList = new Pawn[18][];
        for (int i = 0; i < 18; i++)
        {
            pawnList[i] = new Pawn[18];
            for (int j = 0; j < 18; j++)
            {
                Pawn tmp = (Pawn)Instantiate(Intersection.GetComponent<Pawn>(), new Vector3(i, j, 0), new Quaternion(0, 1, 0, 0));
                tmp.transform.parent = transform;
                pawnList[i][j] = tmp;
                pawnList[i][j].x = i;
                pawnList[i][j].y = j;
            }
            
        }

        transform.Rotate(-30, 0, 0);

        _board.update = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_board.update == true)
        {
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    pawnList[i][j].SetColor(_board[i, j]);
                }
            }

            _board.update = false;
        }

    }

	public void Quit()
	{
		Application.Quit ();
	}

	public void Retour()
	{
		Application.LoadLevel("Menu");
	}
}
