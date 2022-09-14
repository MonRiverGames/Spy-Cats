using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(other.gameObject);
        }
    }
}
