public class Player
{
    public Board.e_cell color { get; private set; }

    public int capturedPawns = 0;

    public TrafficLightComponent trafficLight;

    public void setLight(bool p_light)
    {
        trafficLight.setLight(p_light);
    }

    public Player(Board.e_cell p_color)
    {
        this.color = p_color;
    }
}