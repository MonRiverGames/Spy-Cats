using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject cat;

    public static LevelSelection instance;
    public GameObject loadingScreen;

    private void Awake()
    {
        LoadMenu();
    }

    void LoadMenu()
    {
        loadingScreen.SetActive(false);
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
        
        if(levelAt >= 8)
        {
            cat.gameObject.SetActive(false);
        }

        for (int i = 0; i < levelButtons.Length; i++) {
            int buttonID = i + 1;
            levelButtons[i].onClick.RemoveAllListeners();
            levelButtons[i].onClick.AddListener(delegate { LevelLoad(buttonID); });
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
            LoadMenu();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            int levelAt = PlayerPrefs.GetInt("levelAt", 1);
            PlayerPrefs.SetInt("levelAt", levelAt + 1);
            
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
            LoadMenu();
        }
    }

    public void LevelLoad(int index)
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(index);
    }

    public static void NextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        if (currentLevel == levelAt)
        {
            PlayerPrefs.SetInt("levelAt", currentLevel + 1);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
