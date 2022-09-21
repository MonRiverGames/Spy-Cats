using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Zach : MonoBehaviour
{
    public Player_Zach player;
    public GameObject pickupObject;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);

        if (col.gameObject.tag == "Player" && gameObject.tag == "PowerUp")
        {
            player.jumpPower *= (float) 1.5;
            Debug.Log("POWER UP: JUMP BOOST");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" && gameObject.tag == "SpecialItem")
        {
            Debug.Log("Picked up snowglobe");
            Destroy(gameObject);
        }
    }
}
