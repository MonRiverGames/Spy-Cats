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
        if(Player != null && transform.position.y < Player.position.y)
        {
            Vector3 newPos = new Vector3 (transform.position.x, Player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, CameraSmoothSpeed * Time.deltaTime);
        }
    }
}
