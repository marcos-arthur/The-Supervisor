using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTester : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] public LineController line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line.SetUpLine(points);
    }
}
