using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Nick : MonoBehaviour
{
    // Tweakable constants
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float jumpVelocity = 5.0f;
    [SerializeField] private LayerMask jumpMask;


    // Components
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    // Status Variables
    private bool isJumping = false;
    public bool isInvisible = false;

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

        if (isJumping && IsGrounded() && myRigidbody.velocity.y < 0)
        {
            isJumping = false;
            myAnimator.SetBool("isJumping", false);
        }

        if (IsGrounded() && !isJumping && Input.GetAxisRaw("Vertical") > 0)
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
        Vector2 ray1Pos = new Vector2(mySpriteRenderer.bounds.center.x, mySpriteRenderer.bounds.min.y);
        Vector2 ray2Pos = new Vector2(mySpriteRenderer.bounds.min.x + (mySpriteRenderer.bounds.size.x / 4), mySpriteRenderer.bounds.min.y);
        Vector2 ray3Pos = new Vector2(mySpriteRenderer.bounds.max.x - (mySpriteRenderer.bounds.size.x / 4), mySpriteRenderer.bounds.min.y);

        RaycastHit2D groundCheck1 = Physics2D.Raycast(ray1Pos, Vector2.down, .5f);
        RaycastHit2D groundCheck2 = Physics2D.Raycast(ray2Pos, Vector2.down, .5f);
        RaycastHit2D groundCheck3 = Physics2D.Raycast(ray3Pos, Vector2.down, .5f);

        return groundCheck1.collider != null || groundCheck2.collider != null || groundCheck3.collider != null;
    }

    void Jump()
    {
        isJumping = true;
        myAnimator.SetBool("isJumping", true);
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpVelocity);
    }

    public void ActivatePowerup()
    {
        mySpriteRenderer.color = new Color(1, 1, 1, .5f);
        isInvisible = true;
    }
    
}
