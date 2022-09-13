using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float CameraSmoothSpeed = .3f;
    private Vector3 currentVelocity;

    void Update()
    {
        if(Player != null && (transform.position.x < Player.position.x || transform.position.x > Player.position.x))
        {
            Vector3 newPos = new Vector3 (Player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, CameraSmoothSpeed * Time.deltaTime);
        }
    }
}
