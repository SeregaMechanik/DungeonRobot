using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public int Gems;
    public int invul;

    void Start()
    {

    }

    void Update()
    {
        Buy();
    }

    void Buy()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (Gems >= 10)
            {
                invul = 10;
                Gems -= 10;
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 100, 100), "Gems: " + Gems);
        GUI.Label(new Rect(10, 50, 100, 100), "Invul: " + invul);
    }
}
