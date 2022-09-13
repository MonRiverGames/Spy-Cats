using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_Tessla : MonoBehaviour
{
    public GameObject thingToFollow;

    void Update()
    {
        transform.position = thingToFollow.transform.position + new Vector3(5, 5, -10);
    }
}
