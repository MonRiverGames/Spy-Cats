using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Tessla : MonoBehaviour
{
    // Total number of Collectibles in level
    public int numberOfCollectibles = 4;
    public float timeTillDestroyed = 0.1f;
    public GameObject ventCover;
    public GUIStyle style;
    public GUIStyle style2;
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
        if (other.gameObject.name == "Helicopter" && collectibeCount == numberOfCollectibles)
        {
            Debug.Log("Win");
            catHappy.Play();
            // Change scene
            // You have to make it wait for the sound to stop playing before scene change or the sound won't play fully :c
        }

        if (other.tag == "Vent" && collectibeCount != numberOfCollectibles)
        {
            Debug.Log("Missing items!");
            // Notify user
        }
        
        if (other.tag == "Vent" && collectibeCount == numberOfCollectibles) 
        {
            Debug.Log("Vent opened!");
            catHappy.Play();
            Destroy(ventCover);
        }
    }

    void OnGUI() 
    {
        // Goal GUI
        style2.fontSize = 35;
        style2.normal.textColor = Color.blue;
        style2.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(5, 0, 50, 50), "Collect all items and escape to the chopper!", style2);

        // Items GUI
        style.fontSize = 30;
        style.normal.textColor = Color.blue;
        GUI.Label(new Rect(5, 40, 50, 50), "Items Collected: " + collectibeCount.ToString() + " / " + numberOfCollectibles.ToString(), style);
    }
}
