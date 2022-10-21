using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed;
    public GameObject player;
    public Vector3 startingPointPos;
    public bool chase;
    public float chaseDistance;
    
    public void Start()
    {
        player = GameObject.Find("Player");
        startingPointPos = transform.position;

    }

    public void Update()
    {
        if(player == null)
        {
            return;
        }

        if (!chase)
        {
            ReturnToStart();
        }

        if (chase)
        {
            Flip();
        }

        Chase();
        

        Debug.Log(transform.position.x - player.transform.position.x);
    }

    public void Chase()
    {
        float distance = Mathf.Abs(transform.position.x - player.transform.position.x);
        
        if (distance < chaseDistance)
        {
            
            chase = true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            chase = false;
        }


    }

    public void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }   
    }
    
    public void ReturnToStart()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPointPos, speed * Time.deltaTime);
        if (!chase)
        {
            if (transform.position.x > startingPointPos.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
       
    }
}
