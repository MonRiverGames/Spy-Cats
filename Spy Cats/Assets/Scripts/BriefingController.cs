using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BriefingController : MonoBehaviour
{
    public BriefingText[] briefingTexts;

    public Animator catAnim;
    public TMP_Text briefingText;
    public Button startButton;
    public float timeBtwChars = .05f;

    public void SetLevelBriefing(int levelNum)
    {
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(delegate { StartLevel(levelNum); });

        briefingText.enableAutoSizing = true;
        briefingText.text = briefingTexts[levelNum - 1].briefingText;
        briefingText.enableAutoSizing = false;

        StartCoroutine(TypeWriterTMP(briefingTexts[levelNum -1].briefingText, briefingTexts[levelNum -1].flashingElipsis));
    }
    IEnumerator TypeWriterTMP(string text, bool flashElipsis)
    {
        briefingText.text = "";
        catAnim.SetFloat("talkingSpeed", .9f);

        foreach (char c in text)
        {
            if (briefingText.text.Length > 0)
            {
                briefingText.text = briefingText.text.Substring(0, briefingText.text.Length);
            }
            briefingText.text += c;

            yield return new WaitForSeconds(timeBtwChars);
        }
        catAnim.SetFloat("talkingSpeed", .05f);
        while (flashElipsis)
        {
            briefingText.text = text + ".";
            yield return new WaitForSeconds(.5f);
            briefingText.text = text;
            yield return new WaitForSeconds(.5f);
        }
    }

    public void StartLevel(int levelNum)
    {
        FindObjectOfType<LevelSelection>().LevelLoad(levelNum);
    }
}
