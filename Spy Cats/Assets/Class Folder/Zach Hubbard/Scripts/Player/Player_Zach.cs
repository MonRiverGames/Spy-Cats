using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Zach : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpPower = 8f;
    private bool isFacingRight = true;
    bool isGrounded;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public GameObject GameOverScreen;
    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
        horizontal = Input.GetAxis("Horizontal");

        Flip();

        if (Input.GetButtonDown("Jump") & isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("DEATH");
            GameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}