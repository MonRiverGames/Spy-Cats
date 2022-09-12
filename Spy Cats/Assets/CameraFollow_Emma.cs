using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

  public Transform target;
  public float smoothSpeed = .3f;

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > transform.position.y) {
          Vector3  newPos = new Vector3 (0f, target.position.y, -10f);
transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }
    }
}
