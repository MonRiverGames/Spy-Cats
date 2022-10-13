using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Emma : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            sr.flipX = moveHorizontal < 0;
        }

        if(!isJumping && (moveVertical > 0.1f || Input.GetButton("Jump")))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
        if (collision.gameObject.tag == "Ouch")
        {

            Destroy(gameObject);
        }
    }
}
