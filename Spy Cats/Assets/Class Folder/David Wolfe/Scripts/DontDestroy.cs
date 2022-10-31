using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string objectID;

    public void Awake()
    {
        //Creates a unique ID for each object so it doesn't delete things of the same name. 
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Deletes the object if it already exists in the scene.
        for (int i = 0; i < FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
            {
                if (FindObjectsOfType<DontDestroy>()[i] != this)
                {
                    Destroy(gameObject);
                }
            }
        }

        //Brings the game object to the next scene.
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
