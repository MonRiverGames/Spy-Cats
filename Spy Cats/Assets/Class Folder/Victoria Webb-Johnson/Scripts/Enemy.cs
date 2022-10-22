using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float rayLength = 2f;
    private bool movingLeft = false;
    public Transform groundDetection;
    public Transform wallDetection;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        Debug.Log(wallInfo.collider);


    }

    public void FixedUpdate()
    {
        
    }


    
}
