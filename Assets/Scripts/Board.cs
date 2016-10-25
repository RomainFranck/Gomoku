using UnityEngine;
using System.Collections;

public class Board {

    public enum e_cell
    {
        Empty,
        Black,
        White,
    };

    public Board()
    {
        grid = new e_cell[18][];
        for (int i = 0; i < 18 ; i++)
        {
            grid[i] = new e_cell[18];
        }
    }

    public e_cell[][] grid;
}
