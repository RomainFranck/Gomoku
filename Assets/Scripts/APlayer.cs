﻿using System;

public delegate void turnChangedEvent(object sender, Board p_board);

public abstract class APlayer
{
    public turnChangedEvent changeTurn;

    public string name;

    public Board.e_cell color;

    public void setLight(bool p_light)
    {
        if (trafficLight != null)
            trafficLight.setLight(p_light);
    }

    public int capturedPawns = 0;

    public TrafficLightComponent trafficLight;

    
}