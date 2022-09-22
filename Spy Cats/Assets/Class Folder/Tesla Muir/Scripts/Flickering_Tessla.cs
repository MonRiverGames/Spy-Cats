using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering_Tessla : MonoBehaviour
{
    SpriteRenderer sprite;
    private float relativeTime;
    WaitForSeconds waiter = new WaitForSeconds(1);

    IEnumerator Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
        while (true)
        {
            sprite.color = new Color(1f, 0f, 0f, 0.5f);
            yield return waiter;
            sprite.color = new Color(1f, 0f, 0f, 0f);
            yield return waiter;
        }
    }

    // void Update() 
    // {
    //     relativeTime += Time.deltaTime;

    //     if (relativeTime < 2f)
    //     {
    //         sprite.color = new Color(0.255f, 0f, 0f, 0f);
    //     }
    //     else
    //     {
    //         sprite.color = new Color(0.255f, 0f, 0f, 1f);
    //         if (relativeTime >= 2f)
    //         {
    //             relativeTime = 0f;
    //         }
    //     }
    // }
}
