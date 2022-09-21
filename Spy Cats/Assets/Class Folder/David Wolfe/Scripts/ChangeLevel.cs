using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    int nextSceneIndex;

    public void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("ChangeScene");
        }
    }
}
