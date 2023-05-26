using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTester : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] public LineController line;
    FreeFishController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FreeFishController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.setLine) line.SetUpLine(points);
    }
}
