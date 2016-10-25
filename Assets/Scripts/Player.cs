public class Player
{
    public Board.e_cell color { get; private set; }

    public int capturedPawns = 0;

    public Player(Board.e_cell p_color)
    {
        this.color = p_color;
    }
}