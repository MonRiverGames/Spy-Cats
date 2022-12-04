using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public GameObject helpMenuMain;
    public Button[] levelButtons;
    public GameObject cat;
    public GameObject credits;
    

    public static LevelSelection instance;
    public GameObject loadingScreen;

    private void Awake()
    {
        helpMenuMain = GameObject.Find("Help Screen Main Menu");
        LoadMenu();
    }

    private void Start()
    {
        helpMenuMain.SetActive(false);
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
            levelButtons[i].onClick.AddListener(delegate { BriefingLoad(buttonID); });
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
            if (levelAt == 9)
            {
                credits.SetActive(true);
                PlayerPrefs.Save();
                return;
            }
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
            LoadMenu();
        }
    }

    public void BriefingLoad(int index)
    {
        loadingScreen.SetActive(true);
        loadingScreen.GetComponent<BriefingController>().SetLevelBriefing(index);
    }

    public void LevelLoad(int index)
    {
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
            if (currentLevel == 8)
            {
                SceneManager.LoadScene(0);
                instance.LoadMenu();
                instance.credits.SetActive(true);
                return;
            }
        }
        SceneManager.LoadScene(0);
        
    }
    
   

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenHelp()
    {
        helpMenuMain.SetActive(true);
    }

    public void CloseHelp()
    {
        helpMenuMain.SetActive(false);
    }

}
