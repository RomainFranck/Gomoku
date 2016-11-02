using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoubleThreeButtonComponent : MonoBehaviour
{
    public Sprite[] sprites;

    public Image image;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprites[Arbiter.checkDoubleThrees ? 0 : 1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckButton()
    {
        Arbiter.checkDoubleThrees = !Arbiter.checkDoubleThrees;
        image.sprite = sprites[Arbiter.checkDoubleThrees ? 0 : 1];
    }
}
