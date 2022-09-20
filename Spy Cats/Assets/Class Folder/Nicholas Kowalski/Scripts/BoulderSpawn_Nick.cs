using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawn_Nick : MonoBehaviour
{
    public float timeForBoulder;
    public GameObject boulder;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBoulder", 0, timeForBoulder);
    }

    void SpawnBoulder()
    {
        Instantiate(boulder, transform.position, transform.rotation);
    }
}
