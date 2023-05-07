using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coliderE : MonoBehaviour
{
    public GameObject parentObject = null;
    private Transform parentTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        if (parentObject != null)
        {
            parentTransform = parentObject.transform;
        }
        //GameObject theFront = GameObject.Find("front");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        
        if (col.gameObject.tag == ("parallaxColider1"))
        {

            Debug.Log("xxxxxxxxxxxxxxx");
        }
    }
}
