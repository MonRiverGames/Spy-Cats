using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_Tessla : MonoBehaviour
{
    public GameObject thingToFollow;

    private float playerHeight;
    private float maxHeight = 14.5f;

    void Update()
    {
        playerHeight = thingToFollow.transform.position.y;

        if (thingToFollow.transform.position.x < 170.0f) {
            if (playerHeight + 7 > maxHeight) {
                transform.position = thingToFollow.transform.position + new Vector3(5, (maxHeight-playerHeight), -10);
            } else {
                transform.position = thingToFollow.transform.position + new Vector3(5, 7, -10);
            }
        } else {
            transform.position = thingToFollow.transform.position + new Vector3(5, 5, -10);
        }
    }
}
