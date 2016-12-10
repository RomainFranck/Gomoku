using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Board
{

    public List<Vector2> updatePool = new List<Vector2>();

    private BitArray _whiteMask = new BitArray(18 * 18);
    private BitArray _blackMask = new BitArray(18 * 18);

    public BitArray getWhiteMask()
    {
        return new BitArray(_whiteMask);
    }

    public BitArray getBlackMask()
    {
        return new BitArray(_blackMask);
    }

    public BitArray getMask(Board.e_cell p_color)
    {
        return p_color == e_cell.Black ? getBlackMask() : getWhiteMask();
    }

    public BitArray getPresenceMask()
    {
        return (new BitArray(_whiteMask)).Or(_blackMask);
    }

    public e_cell this[int x, int y]
    {
        get { return _whiteMask[18 * x + y] ? e_cell.White : _blackMask[18 * x + y] ? e_cell.Black : e_cell.Empty; }
        set
        {
            switch (value)
            {
                case (e_cell.White):
                    _whiteMask[18 * x + y] = true;
                    break;
                case (e_cell.Black):
                    _blackMask[18 * x + y] = true;
                    break;
                case (e_cell.Empty):
                    _blackMask[18 * x + y] = false;
                    _whiteMask[18 * x + y] = false;
                    break;
            }
            updatePool.Add(new Vector2(x, y));
        }
    }

    public enum e_cell
    {
        Empty = 0,
        Black = 1,
        White = 2,
        None,
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

	public void reset()
	{
		for (int i = 0; i < 18; i++) {
			for (int j = 0; j < 18; j++) {
				this [i, j] = e_cell.Empty;
			}
		}
	}
}
