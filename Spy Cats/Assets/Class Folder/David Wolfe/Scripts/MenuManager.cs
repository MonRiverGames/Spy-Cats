using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject helpMenuCanvas;
    public bool isPaused;

    private void Awake()
    {
        pauseMenuCanvas = GameObject.Find("Pause Menu Canvas");
        helpMenuCanvas = GameObject.Find("Help Screen");
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        helpMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        } else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) 
        {
            pauseMenuCanvas.SetActive(false);
            helpMenuCanvas.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
    
    
    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
        ClosePauseMenu();
    }
    
    public void QuitGame(){
        Application.Quit();
    }

    public void ClosePauseMenu()
    {
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
    
    public void CloseHelpMenu()
    {
        helpMenuCanvas.SetActive(false);
    }

    public void OpenHelpMenu()
    {
        pauseMenuCanvas.SetActive(true);
        isPaused = true;
        helpMenuCanvas.SetActive(true);
    }
}
