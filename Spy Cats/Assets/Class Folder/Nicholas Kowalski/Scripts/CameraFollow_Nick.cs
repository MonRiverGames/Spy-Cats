using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_Nick : MonoBehaviour
{
    public Transform target;
    public float velocityTrackFactor = 1;
    public float smoothTime = 100;
    public Vector2 offset;

    private Rigidbody2D targetRB;
    private Vector2 velocity = Vector2.zero;

    private void Start()
    {
        targetRB = target.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        Vector2 targetPos = (Vector2)target.position + offset;
        targetPos.x += targetRB.velocity.x * velocityTrackFactor;
        targetPos.y += targetRB.velocity.y * velocityTrackFactor / 4;
        Vector2 newPos = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime * Time.deltaTime);
        transform.position = new Vector3(newPos.x, newPos.y, -10);
    }
}
