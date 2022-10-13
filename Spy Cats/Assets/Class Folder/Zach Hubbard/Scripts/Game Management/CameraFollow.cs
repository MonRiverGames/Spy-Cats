using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float followSpeed = 2f;
    public float yOffset = -1f;
    private Vector3 newPos;

    void Update()
    {
      
        newPos = new Vector3(Player.position.x,Player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed * Time.deltaTime);


    }
}
