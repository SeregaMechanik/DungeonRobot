using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        int g = GameObject.Find("GemController").GetComponent<GemController>().Gems;
        GameObject.Find("GemController").GetComponent<GemController>().Gems = g + 1;
        Destroy(gameObject);
    }
}
