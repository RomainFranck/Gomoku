using UnityEngine;
using System.Collections;



using t_Pattern = Tuple<int[], e_cellColor[]>;
using System.Collections.Generic;

enum e_cellColor
{
    Empty,
    Same,
    Inverse,
};

public class Arbiter {



    private static Vector2[] _directions = {new Vector2(1, 0),
                                            new Vector2(1, 1),
                                            new Vector2(0, 1),
                                            new Vector2(-1, 1),
                                            new Vector2(-1, 0),
                                            new Vector2(-1, -1),
                                            new Vector2(0, -1),
                                            new Vector2(1, -1)};

    private static t_Pattern[] _freeThrees = {   (new t_Pattern(new int[]{-1, 1, 2, 3}, new e_cellColor[]{e_cellColor.Empty, e_cellColor.Same, e_cellColor.Same, e_cellColor.Empty})),
                                                 (new t_Pattern(new int[]{-2, -1, 1, 2}, new e_cellColor[]{e_cellColor.Empty, e_cellColor.Same, e_cellColor.Same, e_cellColor.Empty})),
                                                 (new t_Pattern(new int[]{-1, 1, 2, 3, 4}, new e_cellColor[]{e_cellColor.Empty, e_cellColor.Same, e_cellColor.Empty, e_cellColor.Same, e_cellColor.Empty})),
                                                 (new t_Pattern(new int[]{-2, -1, 1, 2, 3}, new e_cellColor[]{e_cellColor.Empty, e_cellColor.Same, e_cellColor.Empty, e_cellColor.Same, e_cellColor.Empty})),
                                                 (new t_Pattern(new int[]{-1, 1, 2, 3, 4}, new e_cellColor[]{e_cellColor.Empty, e_cellColor.Empty, e_cellColor.Same, e_cellColor.Same, e_cellColor.Empty}))
    };

    private static t_Pattern[] _winPatterns = { (new t_Pattern(new int[] { 1, 2, 3, 4 }, new e_cellColor[] { e_cellColor.Same, e_cellColor.Same, e_cellColor.Same, e_cellColor.Same })),
                                                (new t_Pattern(new int[] {-1, 1, 2, 3 }, new e_cellColor[] { e_cellColor.Same, e_cellColor.Same, e_cellColor.Same, e_cellColor.Same })),
                                                (new t_Pattern(new int[] {-2, -1, 1, 2 }, new e_cellColor[] { e_cellColor.Same, e_cellColor.Same, e_cellColor.Same, e_cellColor.Same }))};

    private static t_Pattern _pairPattern = new t_Pattern(new int[] { 1, 2, 3 }, new e_cellColor[] { e_cellColor.Inverse, e_cellColor.Inverse, e_cellColor.Same });

    private static Arbiter _instance = null;

    public Board board = new Board();

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

    private Vector2 checkPattern(int x, int y, t_Pattern pattern, Board.e_cell color, Vector2 direction)
    {
        bool isPattern = true;

        for (int i = 0; i < pattern.First.Length; i++)
        {
            Vector2 p = new Vector2(x + pattern.First[i] * (int)(direction.x), y + pattern.First[i] * (int)(direction.y));

            if (p.x > 0 && p.x < 18 && p.y > 0 && p.y < 18)
            {
                isPattern &= (board.grid[(int)(p.x)][(int)(p.y)] != (pattern.Second[i] == e_cellColor.Same ? color : pattern.Second[i] == e_cellColor.Inverse ? color == Board.e_cell.Black ? Board.e_cell.White : Board.e_cell.Black : Board.e_cell.Empty));
            }
        }

        return isPattern == true ? direction : Vector2.zero;
    }

    private List<Vector2> checkPatternInEveryDirection(int x, int y, t_Pattern pattern, Board.e_cell color)
    {
        List<Vector2> directionsList = new List<Vector2>();

        foreach (Vector2 direction in _directions)
        {
            Vector2 dir = checkPattern(x, y, pattern, color, direction);

            if (dir != Vector2.zero)
            {
                directionsList.Add(dir);
            }
        }

        return directionsList;
    }

    private bool isDoubleThree(int x, int y, Board.e_cell color)
    {
        List<Vector2> directionsList = new List<Vector2>();

            foreach (t_Pattern pattern in _freeThrees)
            {
                directionsList.AddRange(checkPatternInEveryDirection(x, y, pattern, color));
            }

        if (directionsList.Count > 1)
            return true;
        return false;
    }

    private bool isWinningMove(int x, int y, Board.e_cell color)
    {
        foreach (t_Pattern pattern in _winPatterns)
        {
            if (checkPatternInEveryDirection(x, y, pattern, color).Count > 0)
            {
                return true;
            }
        }

        return false;
    }

    public int tryMove(int x, int y, Board.e_cell color)
    {
        if (x > 18 || y > 18 || x < 0 || y < 0 || color == Board.e_cell.Empty || board.grid[x][y] != Board.e_cell.Empty)
            return 0;

        if (isDoubleThree(x, y, color) == true)
            return 0;

        board.grid[x][y] = color;

        List<Vector2> pair = checkPatternInEveryDirection(x, y, _pairPattern, color);

        foreach (Vector2 direction in pair)
        {
            board.grid[x + (int)(direction.x) * _pairPattern.First[0]][y + (int)(direction.y) * _pairPattern.First[0]] = Board.e_cell.Empty;
            board.grid[x + (int)(direction.x) * _pairPattern.First[1]][y + (int)(direction.y) * _pairPattern.First[1]] = Board.e_cell.Empty;
        }

        if (isWinningMove(x, y, color))
            return 2;
        return 1;
    }
}
