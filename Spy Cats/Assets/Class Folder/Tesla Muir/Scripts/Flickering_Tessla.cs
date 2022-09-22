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
}
