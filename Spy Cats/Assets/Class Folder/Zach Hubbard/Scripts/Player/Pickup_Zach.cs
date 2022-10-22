using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Zach : MonoBehaviour
{
    LevelSelection levelSelection;
    public PlayerController_David player;
    public GameObject pickupObject;
    public GameObject LevelCompleteUI;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);

        if (col.gameObject.tag == "Player" && gameObject.tag == "PowerUp")
        {
            player.jumpForce *= (float) 1.3;
            Debug.Log("POWER UP: JUMP BOOST");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player" && gameObject.tag == "SpecialItem")
        {
            Debug.Log("Picked up Snowglobe, Level Complete");
            LevelCompleteUI.SetActive(true);
            LevelSelection.NextLevel();
        }
    }
}
