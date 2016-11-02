using UnityEngine;
using System.Collections;



using t_Pattern = Tuple<int[], e_cellColor[]>;
using t_vecPattern = Tuple<UnityEngine.Vector2, Tuple<int[], e_cellColor[]>>;

using System.Collections.Generic;
using System;

enum e_cellColor
{
    Empty,
    Same,
    Inverse,
};

public class Arbiter
{
    public bool isPlaying { get; private set; }


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

    private static t_Pattern[] _breakPatterns = { (new t_Pattern(new int[] { -1, 1, 2}, new e_cellColor[] { e_cellColor.Empty, e_cellColor.Same, e_cellColor.Inverse})),
                                                    (new t_Pattern(new int[] { -1, 1, 2}, new e_cellColor[] { e_cellColor.Inverse, e_cellColor.Same, e_cellColor.Empty})),
    };

    private static t_Pattern _pairPattern = new t_Pattern(new int[] { 1, 2, 3 }, new e_cellColor[] { e_cellColor.Inverse, e_cellColor.Inverse, e_cellColor.Same });

    private static Arbiter _instance = null;

    public Board board = new Board();

    public Player player1 = new Player("player 1", Board.e_cell.White);
    public Player player2 = new Player("player 2", Board.e_cell.Black);
    public Player currentPlayer;

    internal void AddLight(TrafficLightComponent trafficLightComponent, int order)
    {
        if (order == 0)
        {
            player1.trafficLight = trafficLightComponent;
        }
        else
            player2.trafficLight = trafficLightComponent;
    }

    public TextMesh textMesh;

    public static bool checkDoubleThrees = true;
    public static void toggleDoubleThrees()
    {
        checkDoubleThrees = !checkDoubleThrees;
    }

    public static bool checkBreakableFive = true;
    public static void toggleBreakableFive()
    {
        checkBreakableFive = !checkBreakableFive;
    }

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

    public Arbiter()
    {
        isPlaying = true;
        currentPlayer = player1;
    }

    private t_vecPattern checkPattern(int x, int y, t_Pattern pattern, Board.e_cell color, Vector2 direction)
    {
        bool isPattern = true;

        for (int i = 0; i < pattern.First.Length; i++)
        {
            Vector2 p = new Vector2(x + pattern.First[i] * (int)(direction.x), y + pattern.First[i] * (int)(direction.y));

            if (p.x > 0 && p.x < 18 && p.y > 0 && p.y < 18)
            {
                isPattern &= (board[(int)(p.x), (int)(p.y)] == (pattern.Second[i] == e_cellColor.Same ? color : pattern.Second[i] == e_cellColor.Inverse ? color == Board.e_cell.Black ? Board.e_cell.White : Board.e_cell.Black : Board.e_cell.Empty));
            }
            else
            {
                isPattern = false;
            }
        }

        return isPattern == true ? new t_vecPattern(direction, pattern) : null;
    }

    private List<t_vecPattern> checkPatternInEveryDirection(int x, int y, t_Pattern pattern, Board.e_cell color)
    {
        List<t_vecPattern> directionsList = new List<t_vecPattern>();

        foreach (Vector2 direction in _directions)
        {
            t_vecPattern dir = checkPattern(x, y, pattern, color, direction);

            if (dir != null)
            {
                directionsList.Add(dir);
            }
        }

        Debug.Log(directionsList.Count);

        return directionsList;
    }

    private bool isDoubleThree(int x, int y, Board.e_cell color)
    {
        List<t_vecPattern> directionsList = new List<t_vecPattern>();

        foreach (t_Pattern pattern in _freeThrees)
        {
            directionsList.AddRange(checkPatternInEveryDirection(x, y, pattern, color));
            if (pattern == _freeThrees[1])
            {
                List<t_vecPattern> vecToRemove = new List<t_vecPattern>();
                foreach(t_vecPattern dir in directionsList)
                {
                    vecToRemove.Add(directionsList.Find((t_vecPattern obj) => { return obj.First.x == dir.First.x * -1 && obj.First.y == dir.First.y * -1; }));
                }

                foreach(t_vecPattern toRemove in vecToRemove)
                {
                    directionsList.Remove(toRemove);
                }
            }
        }

        if (directionsList.Count > 1)
            return true;
        else if (directionsList.Count > 0)
        {
            for (int i = 0; i < directionsList[0].Second.First.Length; i++)
            {
                if (directionsList[0].Second.Second[i] == e_cellColor.Same)
                {
                    foreach (t_Pattern pattern in _freeThrees)
                    {
                        directionsList.AddRange(checkPatternInEveryDirection(x + (int)directionsList[0].First.x * directionsList[0].Second.First[i], y + (int)directionsList[0].First.y * directionsList[0].Second.First[i], pattern, color));
                    }
                }
            }
        }

        if (directionsList.Count > 1)
            return true;
        return false;
    }

    private bool isWinningMove(int x, int y, Board.e_cell color)
    {
        foreach (t_Pattern pattern in _winPatterns)
        {
            List<t_vecPattern> winningPatterns = checkPatternInEveryDirection(x, y, pattern, color);
            foreach (t_vecPattern winPat in winningPatterns)
            {
                if (checkBreakableFive == false)
                {
                    return true;
                }

                List<t_vecPattern> breakers = new List<t_vecPattern>();
                for (int i = 0; i < winPat.Second.First.Length; i++)
                {
                    foreach (t_Pattern pat in _breakPatterns)
                    {
                        breakers.AddRange(checkPatternInEveryDirection(x + winPat.Second.First[i] * (int)winPat.First.x, y + winPat.Second.First[i] * (int)winPat.First.y, pat, color));
                    }
                }

                if (breakers.Count == 0)
                    return true;
                Debug.Log(breakers.Count);
            }
        }

        return false;
    }

    public int move(int x, int y, Board.e_cell color)
    {
        int returnValue = 0;

        board[x, y] = color;

        List<t_vecPattern> pair = checkPatternInEveryDirection(x, y, _pairPattern, color);

        foreach (t_vecPattern dir in pair)
        {
            board[x + (int)(dir.First.x) * _pairPattern.First[0], y + (int)(dir.First.y) * _pairPattern.First[0]] = Board.e_cell.Empty;
            board[x + (int)(dir.First.x) * _pairPattern.First[1], y + (int)(dir.First.y) * _pairPattern.First[1]] = Board.e_cell.Empty;
            returnValue += 2;
        }

        if (isWinningMove(x, y, color))
            returnValue = -1;
        return returnValue;
    }

    public void input(int x, int y)
    {
        if ((isPlaying == false)||x > 18 || y > 18 || x < 0 || y < 0 || board[x, y] != Board.e_cell.Empty)
            return;

        if (checkDoubleThrees && isDoubleThree(x, y, currentPlayer.color) == true)
            return;

        int returnValue = move(x, y, currentPlayer.color);

        if (returnValue == -1)
        {
            isPlaying = false;
           if (textMesh != null)
            {
                textMesh.text = currentPlayer.name + " wins";
            }
        }
        else
        {
            currentPlayer.capturedPawns += returnValue;
            if (currentPlayer.capturedPawns >= 10)
            {
                isPlaying = false;
                if (textMesh != null)
                {
                    textMesh.text = currentPlayer.name + " wins by capture";
                }
            }
        }

        currentPlayer.setLight(false);
        currentPlayer = currentPlayer == player1 ? player2 : player1;
        currentPlayer.setLight(true);

    }
}
