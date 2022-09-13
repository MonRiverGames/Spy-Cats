using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath_Nick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController_Nick>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
