using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Tessla : MonoBehaviour
{
    // Total number of Collectibles in level
    public int numberOfCollectibles = 2;
    public float timeTillDestroyed = 0.1f;
    public AudioSource collectSound;
    public AudioSource catHappy;

    // Amount of Collectibles player has gotten
    private int collectibeCount = 0;

    void OnTriggerEnter2D(Collider2D other) 
    {
        // Collect item
        if (other.tag == "Collectible")
        {
            collectibeCount++;
            collectSound.Play();
            Destroy(other.gameObject, timeTillDestroyed);
        }

        // Win mechanic
        if (other.tag == "Vent" && collectibeCount == numberOfCollectibles)
        {
            Debug.Log("Win");
            catHappy.Play();
            // Change scene
        }

        if (other.tag == "Vent" && collectibeCount != numberOfCollectibles)
        {
            Debug.Log("Missing items!");
            // Notify user
        }
    }
}
