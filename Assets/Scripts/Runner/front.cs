using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class front : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("parallaxColider1"))
        {
            gameObject.transform.position = new Vector3(16, 3, 0);
            
        }
    }



    // Start is called before the first frame update

    void Start()
    {
        
    }
    private void Update()
    {

        gameObject.transform.Translate(new Vector3(-0.1f, 0, 0));


    }
    // Update is called once per frame
    
   
   
}

