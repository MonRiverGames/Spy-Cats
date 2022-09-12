using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Tessla : MonoBehaviour
{
    public float timeTillDestroyed = 0.1f;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Collectible")
        {
            Destroy(other.gameObject, timeTillDestroyed);
        }
    }
}
