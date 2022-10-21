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
    public GUIStyle boxStyle;
    public AudioSource collectSound;
    public AudioSource catHappy;

    public bool immediateWin = false;
    // Amount of Collectibles player has gotten
    private int collectibeCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Collect item
        if (other.tag == "Collectible")
        {
            collectibeCount++;
            if (collectibeCount == numberOfCollectibles)
            {
                catHappy.Play();
                Invoke("ChangeScene", 1);
            }
            
            collectSound.Play();
            Destroy(other.gameObject, timeTillDestroyed);
        }

        // Win mechanic
        if (other.gameObject.name == "Helicopter" && collectibeCount == numberOfCollectibles)
        {
            
            catHappy.Play();
            Invoke("ChangeScene", 1);
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

    private void ChangeScene()
    {
        LevelSelection.NextLevel();
    }
    void OnGUI()
    {
        // Box behind Items GUI
        boxStyle.normal.background = MakeTex(2, 2, new Color(0.21f, 0.37f, 0.90f, 0.99f));
        GUI.Label(new Rect(5, 5, 310, 50), "", boxStyle);

        // Items GUI
        style.fontSize = 30;
        style.normal.textColor = Color.white;
        style.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(10, 10, 100, 50), "Items Collected: " + collectibeCount.ToString() + " / " + numberOfCollectibles.ToString(), style);
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
