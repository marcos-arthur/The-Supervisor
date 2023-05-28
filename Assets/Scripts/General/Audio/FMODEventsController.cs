using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEventsController : MonoBehaviour
{
    public static FMODEventsController instance { get; private set; }


    [field: Header("Mouse click")]
    [field: SerializeField] public EventReference mouseClickSound { get; private set; }

    [field: Header("Open window")]
    [field: SerializeField] public EventReference openWindowSound { get; private set; }

    [field: Header("Close window")]
    [field: SerializeField] public EventReference closeWindowSound { get; private set; }
    
    [field: Header("Correct Answer")]
    [field: SerializeField] public EventReference correctAnswerSound { get; private set; }

    [field: Header("Correct Answer")]
    [field: SerializeField] public EventReference wrongAnswerSound { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
