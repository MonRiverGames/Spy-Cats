using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximitySound_Tessla : MonoBehaviour
{
    public AudioSource sound;
    private float relativeTime;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && relativeTime <= Time.fixedTime)
        {
            sound.Play();
            relativeTime = Time.fixedTime + 6.0f;
        }
    }
}
