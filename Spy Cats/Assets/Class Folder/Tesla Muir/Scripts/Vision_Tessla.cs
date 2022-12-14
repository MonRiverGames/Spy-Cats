using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vision_Tessla : MonoBehaviour
{
    public AudioSource catSad;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Caught");
            catSad.Play();
            // Should switch screens to reset instead of destroy
            // You have to make it wait for the sound to stop playing before scene change or the sound won't play fully :c
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
        }
    }
}
