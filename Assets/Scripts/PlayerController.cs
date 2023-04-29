using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public GameObject lineTop, lineBottom;
    public LayerMask fish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Linecast(lineTop.transform.position, lineBottom.transform.position,fish))
        {
            Debug.Log("a fish crossed");
        }
    }
}
