using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
        
        if(levelAt > 10)
        {
            cat.gameObject.SetActive(false);
        }

        for (int i = 0; i < levelButtons.Length; i++) {
            int buttonID = i + 1;
            levelButtons[i].onClick.AddListener(delegate { LevelLoad(buttonID); });
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void LevelLoad(int index)
    {
        SceneManager.LoadScene(index);
    }

}
