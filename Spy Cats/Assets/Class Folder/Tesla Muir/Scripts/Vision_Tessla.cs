using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision_Tessla : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Caught");
            Destroy(other.gameObject);
        }
    }
}
