using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond_Nick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController_Nick>())
        {
            StartCoroutine(Win(3));
        }
    }

    IEnumerator Win(float time)
    {
        Vector2 startScale = transform.localScale;
        Vector2 endScale = startScale * 3;
        CameraFollow_Nick cam = FindObjectOfType<CameraFollow_Nick>();
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
