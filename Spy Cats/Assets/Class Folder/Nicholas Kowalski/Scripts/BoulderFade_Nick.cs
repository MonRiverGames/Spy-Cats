using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderFade_Nick : MonoBehaviour
{
    public float time;
    public Collider2D triggerCollider;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartFade", time);
    }

    void StartFade ()
    {
        triggerCollider.enabled = false;
        StartCoroutine(Fade(1));
    }

    IEnumerator Fade(float time)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color startColor = Color.white;
        Color endColor = Color.clear;
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            sr.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
        Destroy(gameObject);
    }
}
