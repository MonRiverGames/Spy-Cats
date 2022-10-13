using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;
    public Animator animator;
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public Vector2 colliderBounds = new Vector2(.8f, .1f);
    public float rayCastLength = .2f;
    [SerializeField] private LayerMask jumpMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime * speed;
        if (IsGrounded() && (Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }


    private bool IsGrounded()
    {
        Vector2 origin = new Vector2(mySpriteRenderer.bounds.center.x, mySpriteRenderer.bounds.min.y);
        RaycastHit2D groundCheck = Physics2D.BoxCast(origin, colliderBounds, 0, Vector2.down, rayCastLength);

        return groundCheck;
    }
}
