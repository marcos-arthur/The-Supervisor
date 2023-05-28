using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("groundCollider"))
        {
            gameObject.transform.position = new Vector3(14.3f, -0.24f, 0);
            Debug.Log("foi");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   gameObject.transform.Translate(new Vector3(-0.15f, 0, 0));
    }
}
