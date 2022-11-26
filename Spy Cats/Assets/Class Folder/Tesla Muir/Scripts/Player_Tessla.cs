using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tessla : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 10f;
    public AudioSource jumpSound;

    private float movement;
    private bool isGrounded = true;
    private float relativeTime;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    public Animator animator;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        // Movement and Animation
        movement = Input.GetAxis("Horizontal") * movementSpeed;   
        animator.SetFloat("Movement", Mathf.Abs(movement));

        // Flip sprite on movement
        if (Input.GetAxis("Horizontal") < 0) 
        {
            sprite.flipX = false;
        } 

        if (Input.GetAxis("Horizontal") > 0) 
        {
            sprite.flipX = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;

        // Jump
        if (Input.GetAxis("Vertical") > 0 && isGrounded || Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            jumpSound.Play();
            relativeTime = Time.fixedTime + 1.0f;
            GlobalSounds.PlayJumpSound();
        }

        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
