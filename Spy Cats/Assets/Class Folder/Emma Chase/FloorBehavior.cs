using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{
  public GameObject ball1;

  public GameObject ball2;

  public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
      floor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckFloor();
    }

    private void CheckFloor()
    {
      if(ball1.activeInHierarchy == false && ball2.activeInHierarchy == false){
        floor.SetActive(false);
      }
    }
}
