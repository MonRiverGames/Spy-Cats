using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_David : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpForce = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
        Jump();

        if (horizontal > 0.1f || horizontal < -0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    
    private void Flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0f)
        {
            
            isFacingRight = !isFacingRight;

            if (isFacingRight)
            {
                sr.flipX = false;
            }

            if (!isFacingRight)
            {
                sr.flipX = true;
            }
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;
        }
        
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
    public void Jump()
    {
        if((Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.Play("CatJump");
            GlobalSounds.PlayJumpSound();
        }
        
        //if ((Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0) && rb.velocity.y > 0f)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //    anim.Play("CatJump");
        //}
    }
}
