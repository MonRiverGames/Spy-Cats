using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond: MonoBehaviour
{
    AudioSource source;
    public AudioClip[] levelComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Controller_Jackson>() || collision.name == "Player")
        {
            LevelComplete();
            StartCoroutine(Win(3));
        }
    }
    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    IEnumerator Win(float time)
    {
        
        Vector2 startScale = transform.localScale;
        Vector2 endScale = startScale * 2;

        if (FindObjectOfType<CameraFollow_JacksonSigler>())
        {
            CameraFollow_JacksonSigler cam = FindObjectOfType<CameraFollow_JacksonSigler>();
            cam.target = gameObject.transform;
            cam.velocityTrackFactor = 0;
        }
        for (float t = 0; t < 1; t += Time.unscaledDeltaTime / time)
        {
            transform.localScale = Vector2.Lerp(startScale, endScale, t);
            yield return null;
        }
        
        LevelSelection.NextLevel();
        
    }

    public void LevelComplete()
    {
        source.clip = levelComplete[Random.Range(0, levelComplete.Length)];
        source.PlayOneShot(source.clip);


    }
}