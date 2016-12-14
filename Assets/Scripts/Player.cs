public class Player : APlayer
{
    public Player(string p_name, Board.e_cell p_color)
    {
        this.name = p_name;
        this.color = p_color;

        this.changeTurn += (object s, Board b) => { };
    }
}