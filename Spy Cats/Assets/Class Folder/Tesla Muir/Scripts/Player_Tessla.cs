using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tessla : MonoBehaviour
{
    public float movementSpeed = 10f;
    private float movement;

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
        rb.velocity = velocity;
    }
}
