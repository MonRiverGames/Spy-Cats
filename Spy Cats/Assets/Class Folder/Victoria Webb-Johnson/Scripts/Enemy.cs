using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float rayLength = 2f;
    private bool movingLeft = false;
    public float deathTime;
    private bool isDead = false;
    public float deathJumpForce;

    public Transform groundDetection;
    public Transform wallDetection;


    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.transform.position, Vector2.down, rayLength);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.transform.position, transform.forward, rayLength);

        if (groundInfo.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
                
            }
            else
            {
                
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
                
            }
        }
        
        if(groundInfo.collider == true && wallInfo.collider == true)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;

            }
            else
            {

                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;

            }
        }
        



        //Draw groundInfo ray
        Debug.DrawRay(groundDetection.position, Vector2.down * rayLength, Color.red);
        //Draw wallInfo ray
        Debug.DrawRay(wallDetection.position, Vector2.left * rayLength, Color.blue);
        Debug.DrawRay(wallDetection.position, Vector2.right * rayLength, Color.blue);


    }

    // For enemies
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
            return;
        if (collision.gameObject.name == "Player")
        {
            // If the player is over the rat, kill the rat
            if (Mathf.Abs(collision.gameObject.transform.position.y - transform.position.y) >
                Mathf.Abs(collision.gameObject.transform.position.x - transform.position.x))
            {
                StartCoroutine(FallOutOfLevel(deathTime));
            } else { // Otherwise kill the player
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator FallOutOfLevel(float duration)
    {
        isDead = true;
        Vector2 startScale = transform.localScale;
        Vector2 endScale = transform.localScale;
        endScale.y = startScale.y / 2;
        endScale.x = startScale.x * 1.1f;

        for (float t = 0; t < 1; t += Time.unscaledDeltaTime / (duration))
        {
            transform.localScale = Vector2.Lerp(startScale, endScale, t);
            yield return null;
        }
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce((Random.insideUnitCircle + Vector2.up * 2) * deathJumpForce);
        rb.freezeRotation = false;
        rb.AddTorque(300);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);

    }

}
