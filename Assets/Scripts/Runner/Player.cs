using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag != "Obstacle")
        {
            return;
        }
        else if (col.gameObject.tag == "Obstacle") 
        {
            RunnerGameController.pontos -= 10;
            //instance_Runner_Fail.start();
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
      if(Input.GetMouseButtonDown(0) && GetComponent<Transform>().position.y <= -2.12 && GetComponent<Transform>().position.y >= -2.14)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
            //instance_Runner_Jum.start();
        }
    }
    //
}
