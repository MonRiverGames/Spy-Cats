using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Jackson : MonoBehaviour
{
   // Unity Variables
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float jumpVelocity = 5.0f;
    [SerializeField] private LayerMask jumpMask;

    public Vector2 colliderBounds = new Vector2(.8f, .1f);
    public float rayCastLength = .01f;

    // Components
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    // Status Variables
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SideMovement();

        if (isJumping && IsGrounded())
        {
            isJumping = false;
            myAnimator.SetBool("isJumping", false);
        }

        if (IsGrounded() && !isJumping && (Input.GetAxisRaw("Vertical") > 0 || Input.GetButton("Jump")))
        {
            Jump();
        }
    }

    void SideMovement()
    {
        float targetVelocity = Input.GetAxisRaw("Horizontal") * playerSpeed;
        float xVelocity = Mathf.Lerp(myRigidbody.velocity.x, targetVelocity, acceleration * Time.deltaTime);

        myRigidbody.velocity = new Vector2(xVelocity, myRigidbody.velocity.y);
        if (IsGrounded())
        {
            myAnimator.SetFloat("xSpeed", Mathf.Abs(xVelocity));
        }
        else
        {
            myAnimator.SetFloat("xSpeed", 0);
        }
        if (xVelocity < -.1f)
        {
            mySpriteRenderer.flipX = true;
        } else if (xVelocity > .1f)
        {
            mySpriteRenderer.flipX = false;
        }
    }

    private bool IsGrounded()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D groundCheck = Physics2D.BoxCast(origin, colliderBounds, 0, Vector2.down, rayCastLength);

        return groundCheck;
    }

    //private void OnDrawGizmos()
    //{
    //    Vector2 origin = new Vector2(transform.position.x, transform.position.y);
    //    Gizmos.DrawCube(origin, colliderBounds);
    //}
    void Jump()
    {
        isJumping = true;
        myAnimator.SetBool("isJumping", true);
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpVelocity);
        GlobalSounds.PlayJumpSound();
    }
    
    private void OnTrigger2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Diamonds")) {
            Destroy(other.gameObject);
        }
    }
    
}

