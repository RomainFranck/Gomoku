public class Player
{
    public string name { get; private set; }

    public Board.e_cell color { get; private set; }

    public int capturedPawns = 0;

    public TrafficLightComponent trafficLight;

    public void setLight(bool p_light)
    {
        trafficLight.setLight(p_light);
    }

    public Player(string p_name, Board.e_cell p_color)
    {
        this.name = p_name;
        this.color = p_color;
    }
}