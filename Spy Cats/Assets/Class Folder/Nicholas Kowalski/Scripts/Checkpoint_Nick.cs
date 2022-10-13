using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Nick : MonoBehaviour
{
    private bool active = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
            return;
        if (collision.gameObject.GetComponent<PlayerController_Nick>())
        {
            active = true;
            GetComponent<Animator>().SetTrigger("Activate");
            collision.gameObject.GetComponent<PlayerController_Nick>().SetRespawnPoint(transform.position);
        }
    }
}
