using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase_Tessla : MonoBehaviour
{
    public AudioSource glassBreak;
    private bool hasBroken = false;

    void OnCollisionEnter2D(Collision2D other) 
    {
        // Plays vase breaking sound just once
        if (other.collider.gameObject.name == "Ground" && !hasBroken) 
        {
            glassBreak.Play();
            hasBroken = true;
        }
    }
}
