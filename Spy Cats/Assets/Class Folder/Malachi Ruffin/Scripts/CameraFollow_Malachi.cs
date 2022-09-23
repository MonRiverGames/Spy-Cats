using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_Malachi : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = .3f;


    void Update()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }




    }
}