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
    private Collider2D myCollider;

    // Status Variables
    private bool isJumping = false;
    public bool isInvisible = false;
    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
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
        Vector2 origin = myCollider.bounds.center;
        Vector2 size = myCollider.bounds.size;
        RaycastHit2D groundCheck = Physics2D.BoxCast(origin, size - Vector2.right * .05f, 0, Vector2.down, .4f, jumpMask);

        return groundCheck;
    }


    void Jump()
    {
        isJumping = true;
        myAnimator.SetBool("isJumping", true);
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpVelocity);
        GlobalSounds.PlayJumpSound();
    }

    public void ActivatePowerup()
    {
        mySpriteRenderer.color = new Color(1, 1, 1, .5f);
        isInvisible = true;
    }

    public void Respawn()
    {
        myRigidbody.velocity = Vector2.zero;
        transform.position = respawnPoint;
        isJumping = false;
        myAnimator.SetBool("isJumping", false);
    }

    public void SetRespawnPoint(Vector3 newPos)
    {
        respawnPoint = newPos;
    }
    
}
