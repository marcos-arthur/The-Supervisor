using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{    
    public float velocity;
    public int points;
    public Camera cam;
    public bool copyright;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {       
        float aux = cam.WorldToViewportPoint(transform.position).x;
        if (aux >= 1.5 || aux <= -0.5) {
            transform.Rotate(0, 180, 0);
            velocity*=-1;
        }
        transform.position -= new Vector3(velocity * Time.deltaTime, 0, 0);
    }

    public int getPoints() { return points; }
}
