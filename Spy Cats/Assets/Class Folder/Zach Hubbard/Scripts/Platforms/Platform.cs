using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    public float jumpForce = 150f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        transform.position += Vector3.up * 5;
        transform.position = new Vector3(Random.Range(-5f,5f),transform.position.y,0);
       
    }
}