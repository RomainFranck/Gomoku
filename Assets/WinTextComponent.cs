using UnityEngine;
using System.Collections;

public class WinTextComponent : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Arbiter.Instance.textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
