using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Emma : MonoBehaviour
{
  void Start(){
    gameObject.SetActive(true);
  }

    // Apply this script to an item you wish to be destroyed upon collision. Make sure isTrigger is active
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            LevelSelection.NextLevel();
        }
    }
}
