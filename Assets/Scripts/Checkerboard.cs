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
                pawnList[i][j] = (Pawn)Instantiate(Intersection.GetComponent<Pawn>(), new Vector3(i, j, 0), new Quaternion(0, 1, 0, 0), transform);
                pawnList[i][j].x = i;
                pawnList[i][j].y = j;
                pawnList[i][j].SetColor(_board[i, j]);
            }
            
        }
		_board.reset ();
        transform.Rotate(-30, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Vector2 v in _board.updatePool)
        { 
            pawnList[(int)v.x][(int)v.y].SetColor(_board[(int)v.x, (int)v.y]);
        }
        _board.updatePool.Clear();


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
