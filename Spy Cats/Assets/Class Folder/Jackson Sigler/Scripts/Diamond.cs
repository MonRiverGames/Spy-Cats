using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Controller_Jackson>())
        {
            StartCoroutine(Win(3));
        }
    }

    IEnumerator Win(float time)
    {
        Vector2 startScale = transform.localScale;
        Vector2 endScale = startScale * 2;
        CameraFollow_JacksonSigler cam = FindObjectOfType<CameraFollow_JacksonSigler>();
        cam.target = gameObject.transform;
        cam.velocityTrackFactor = 0;
        for (float t = 0; t < 1; t += Time.unscaledDeltaTime / time)
        {
            transform.localScale = Vector2.Lerp(startScale, endScale, t);
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}