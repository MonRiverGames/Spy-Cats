using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Zach : MonoBehaviour
{
    Player_Zach player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.jumpPower *= 2;
            Debug.Log("POWER UP");
            Destroy(gameObject);
            
        }
    }
}
