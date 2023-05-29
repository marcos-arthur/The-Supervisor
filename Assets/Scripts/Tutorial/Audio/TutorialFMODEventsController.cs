using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorialFMODEventsController : MonoBehaviour
{
    public static TutorialFMODEventsController Instance { get; private set; }

    [field: Header("Background song")]
    [field: SerializeField] public EventReference backgroundSong { get; private set; }

    [field: Header("Win sound")]
    [field: SerializeField] public EventReference winSound { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}