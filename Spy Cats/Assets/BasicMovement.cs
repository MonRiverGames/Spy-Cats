using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public Animator animator;
    public float speed5f;
    public float jumpSpeed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            
        }

    }
}
