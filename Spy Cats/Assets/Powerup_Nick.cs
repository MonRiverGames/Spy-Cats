using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Nick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController_Nick player = collision.GetComponent<PlayerController_Nick>();
        if (player)
        {
            player.ActivatePowerup();
            Destroy(gameObject);
        }
    }
}
