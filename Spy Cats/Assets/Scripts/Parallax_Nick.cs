using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Nick : MonoBehaviour
{
    Transform cam;
    private float startX;
    public float xLimit = 2;
    public float xPlayerBound = 5;
    bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        cam = FindObjectOfType<CameraFollow_Nick>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowing)
            return;
        float t = (Mathf.Clamp((startX - cam.position.x) / xPlayerBound, -1f, 1f) + 1) / 2;
        float xPos = Mathf.Lerp(startX - xLimit, startX + xLimit, t);
        transform.position = new Vector2(xPos, transform.position.y);

    }

    private void OnBecameVisible()
    {
        isShowing = true;
    }

    private void OnBecameInvisible()
    {
        isShowing = false;
    }
}
