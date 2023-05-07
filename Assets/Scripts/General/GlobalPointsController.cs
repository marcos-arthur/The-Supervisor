using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPointsController : MonoBehaviour
{
    public static GlobalPointsController instance = null;
    
    public int globalPoints = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
