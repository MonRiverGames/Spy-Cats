using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Gay() => print("gay");

    public void StartGame()
    {
        SceneManager.LoadScene("Main Level");
    }
}
