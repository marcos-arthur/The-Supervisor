using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{    
    public float velocity; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible) {
            transform.Rotate(0, 180, 0);
        }
        transform.Translate(velocity, 0,0);
    }
}
