using UnityEngine;
using System.Collections.Generic;

public class Board
{

    public List<Vector2> updatePool = new List<Vector2>();

    private char[] _byteBoard = new char[81];

    public e_cell this[int x, int y]
    {
        get { return (e_cell)((_byteBoard[(x * 18 + y) / 4] >> (2 * ((x * 18 + y) % 4))) % 4); }
        set
        {
            char octet = _byteBoard[(x * 18 + y) / 4];
            char shift = (char)(2 * ((x * 18 + y) % 4));
            char mask = (char)(3 << shift);
            char val = (char)((int)value << shift);
            _byteBoard[(x * 18 + y) / 4] = (char)(octet & ~mask | val);
            updatePool.Add(new Vector2(x, y));
        }
    }

    public enum e_cell
    {
        Empty = 0,
        Black = 1,
        White = 2,
    };

    public Board()
    {
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                this[i, j] = e_cell.Empty;
            }
        }
    }
}
