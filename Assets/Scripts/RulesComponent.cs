using UnityEngine;
using System.Collections;

public class RulesComponent : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toggleDoubleThrees()
    {
        Arbiter.toggleDoubleThrees();
    }
    public void toggleBreakableFive()
    {
        Arbiter.toggleBreakableFive();
    }
}
