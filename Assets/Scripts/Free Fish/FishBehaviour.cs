using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FishBehaviour : MonoBehaviour
{    
    public float velocity;
    public int points;
    public bool copyright;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(velocity * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            transform.Rotate(0, 180, 0);
            velocity *= -1;            
        }
    }

    public int getPoints() { return points; }
}
