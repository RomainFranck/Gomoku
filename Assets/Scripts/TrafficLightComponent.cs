using UnityEngine;
using System.Collections;

public class TrafficLightComponent : MonoBehaviour
{

    public Sprite SpriteIfTrue = null;
    public Sprite SpriteIfFalse = null;

    public int Order = 0;

    private SpriteRenderer _renderer;

    // Use this for initialization
    void Start()
    {
        Arbiter.Instance.AddLight(this, Order);
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setLight(bool p_light)
    {
        _renderer.sprite = p_light ? SpriteIfTrue : SpriteIfFalse;
    }
}
