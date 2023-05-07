using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midle : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(-0.05f, 0, 0));
    }
}
