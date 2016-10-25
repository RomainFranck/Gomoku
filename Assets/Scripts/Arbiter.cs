using UnityEngine;
using System.Collections;

using t_Pattern = Tuple<int[], bool[]>;

public class Arbiter {

    private static Vector2[] _directions = {new Vector2(1, 0),
                                            new Vector2(1, 1),
                                            new Vector2(0, 1),
                                            new Vector2(-1, 1),
                                            new Vector2(-1, 0),
                                            new Vector2(-1, -1),
                                            new Vector2(0, -1),
                                            new Vector2(1, -1)};

    private static t_Pattern[] _freeThrees = {   (new t_Pattern(new int[]{-1, 1, 2, 3}, new bool[]{false, true, true, false})),
                                                 (new t_Pattern(new int[]{-2, -1, 1, 2}, new bool[]{false, true, true, false})),
                                                 (new t_Pattern(new int[]{-1, 1, 2, 3, 4}, new bool[]{false, true, false, true, false})),
                                                 (new t_Pattern(new int[]{-2, -1, 1, 2, 3}, new bool[]{false, true, false, true, false})),
                                                 (new t_Pattern(new int[]{-1, 1, 2, 3, 4}, new bool[]{false, false, true, true, false}))
    };

    private static t_Pattern[] _winPatterns = { (new t_Pattern(new int[] { 1, 2, 3, 4 }, new bool[] { true, true, true, true })),
                                                (new t_Pattern(new int[] {-1, 1, 2, 3 }, new bool[] { true, true, true, true })),
                                                (new t_Pattern(new int[] {-2, -1, 1, 2 }, new bool[] { true, true, true, true }))};

    private static Arbiter _instance = null;

    private Board _board = new Board();

    public static Arbiter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Arbiter();
            }

            return _instance;
        }
    }

    private bool checkPattern(int x, int y, t_Pattern pattern, Board.e_cell color)
    {
        bool isPattern = true;

        foreach (Vector2 direction in _directions)
        {
            for (int i = 0; i < pattern.First.Length; i++)
            {
                Vector2 p = new Vector2(x + pattern.First[i] * (int)(direction.x), y + pattern.First[i] * (int)(direction.y));

                if (p.x > 0 && p.x < 18 && p.y > 0 && p.y < 18)
                {
                    isPattern &= (_board.grid[(int)(p.x)][(int)(p.y)] != (pattern.Second[i] ? color : Board.e_cell.Empty));
                }
            }
        }

        return isPattern;
    }

    private bool isDoubleThree(int x, int y, Board.e_cell color)
    {
        int patterns = 0;

            foreach (t_Pattern pattern in _freeThrees)
            {
                if(checkPattern(x, y, pattern, color))
                {
                    patterns++;
                }
            }

        if (patterns > 1)
            return true;
        return false;
    }

    public bool tryMove(int x, int y, Board.e_cell color)
    {
        if (x > 18 || y > 18 || x < 0 || y < 0 || color == Board.e_cell.Empty || _board.grid[x][y] != Board.e_cell.Empty)
            return false;

        if (isDoubleThree(x, y, color) == true)
            return false;

        return true;
    }
}
