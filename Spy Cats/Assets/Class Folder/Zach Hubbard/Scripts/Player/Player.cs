using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    float movement = 0f;
    public float speed = 8f;
    Rigidbody2D rb;
    public GameObject GameOverScreen;
    public float currentHighestHeight = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (collision.transform.position.y > currentHighestHeight)
            {
                currentHighestHeight = collision.transform.position.y;
                string score = scoreText.text;
                score = score.Substring(7);
                int scoreNum = int.Parse(score);
                scoreNum = (int)(transform.position.y + 2.45) * 100;
                scoreText.text = "Score: " + scoreNum.ToString();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            print("GAME OVER");
            GameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}