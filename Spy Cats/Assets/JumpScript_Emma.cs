using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript_Emma : MonoBehaviour
{
    GameObject Player_Emma;

    void Start()
    {
        Player_Emma = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Player_Emma.GetComponent<BasicMovement_Emma>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Player_Emma.GetComponent<BasicMovement_Emma>().isGrounded = false;
        }
    }


}
