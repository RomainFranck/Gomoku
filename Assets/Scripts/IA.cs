using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IA : APlayer
{
    private static Threat[] _threats = {
        new Threat(new bool[]{false, true, true, true, true}, 4000),
        new Threat(new bool[]{true, false, true, true, true}, 4000),
        new Threat(new bool[]{true, true, false, true, true}, 4000),
        new Threat(new bool[]{false, true, true, true, false, false}, 100),
        new Threat(new bool[]{false, true, true, true, false}, 50),
        new Threat(new bool[]{false, false, true, true, true}, 30),
        new Threat(new bool[]{false, true, false, true, true, false}, 30),
        new Threat(new bool[]{false, true, true, false, false}, 12),
        new Threat(new bool[]{true, false, true}, 12),
        new Threat(new bool[]{true, false, false}, 8),
        new Threat(new bool[]{false, false, false, false, false}, 1),
    };

    public int[] weights = new int[324];
    int[] indexes = new int[324];

    public IA(string p_name, Board.e_cell p_color)
    {
        this.name = p_name;
        this.color = p_color;
        changeTurn += playNextMove;

        for (int i = 0; i < 324; i++)
        {
            weights[i] = 2;
        }
    }

    public void playNextMove(object sender, Board p_Board, int position)
    {
       for (int x = 0; x < 18; x++)
        {
            for (int y = 0; y < 18; y++)
            {
                weights[x * 18 + y] = 0;
                foreach (Threat t in _threats)
                {
                    weights[x * 18 + y] += t.match(p_Board, new Vector2(x, y));
                }
                indexes[x * 18 + y] = x * 18 + y;
            }
        }

        Array.Sort(indexes, FunctionalComparer<int>.Create((a, b) => { return weights[b] - weights[a]; }));

        int i = 0;
        while (Arbiter.Instance.input(indexes[i] / 18, indexes[i] % 18) == 0 && i < 324)
            i++;
    }
}

public class Threat
{
    public bool[] pattern;
    public int score;

    public Threat(bool[] p_pattern, int p_score)
    {
        pattern = p_pattern;
        score = p_score;
    }

    public int match(Board p_board, Vector2 p_pos)
    {
        int match = 0;

        foreach(Vector2 v in Arbiter.directions)
        {
            match += matchForDirection(p_board, v, p_pos);
        }

        return match;
    }

    public int matchForDirection(Board p_board, Vector2 p_dir, Vector2 p_pos)
    {
        int match = 0;

        for (int i = 0; i < pattern.Length; i++)
        {
            if (!pattern[i])
            {
                Vector2 a_pos = p_pos - p_dir * i;
                Board.e_cell color = Board.e_cell.None;

                bool isMatch = true;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (a_pos.x < 0 || a_pos.x >= 18 || a_pos.y < 0 || a_pos.y >= 18)
                    {
                        isMatch = false;
                        break;
                    }

                    if (pattern[j])
                    {
                        color = color == Board.e_cell.None ? p_board[(int)a_pos.x, (int)a_pos.y] != Board.e_cell.Empty ? p_board[(int)a_pos.x, (int)a_pos.y] : color : color;
                        isMatch = (p_board[(int)a_pos.x, (int)a_pos.y] == color);
                    }
                    else
                    {
                        isMatch = (p_board[(int)a_pos.x, (int)a_pos.y] == Board.e_cell.Empty);
                    }

                    if (!isMatch)
                        break;
                    a_pos += p_dir;

                }

                if (isMatch)
                {
                    match += score;
                }
            }
        }
        return match;
    }
}

public class FunctionalComparer<T> : IComparer<T>
{
    private Func<T, T, int> comparer;
    public FunctionalComparer(Func<T, T, int> comparer)
    {
        this.comparer = comparer;
    }
    public static IComparer<T> Create(Func<T, T, int> comparer)
    {
        return new FunctionalComparer<T>(comparer);
    }
    public int Compare(T x, T y)
    {
        return comparer(x, y);
    }
}