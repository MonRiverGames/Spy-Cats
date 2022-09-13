using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Zach : MonoBehaviour
{

    private float length, startpos;
    public GameObject Camera;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (Camera.transform.position.x * (1 - parallaxEffect));
        float dist = (Camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
