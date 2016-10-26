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
                Pawn tmp = (Pawn)Instantiate(Intersection.GetComponent<Pawn>(), new Vector3(i, j, 0), Quaternion.identity);
                pawnList[i][j] = tmp;
                pawnList[i][j].x = i;
                pawnList[i][j].y = j;
            }
        }
        pawnList[1][1].SetColor(Board.e_cell.Black);
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
                    pawnList[i][j].SetColor(_board.grid[i][j]);
                }
            }

            _board.update = false;
        }

    }
}
