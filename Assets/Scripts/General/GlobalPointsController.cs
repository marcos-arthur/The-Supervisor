using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPointsController : MonoBehaviour
{
    public int globalPoints = 500;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
