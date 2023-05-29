using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFMODEventsController : MonoBehaviour
{
    public static DragonFMODEventsController Instance { get; private set; }
    private List<EventInstance> eventInstances;

    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambienceSound { get; private set; }

    [field: Header("Correct")]
    [field: SerializeField] public EventReference correctSound { get; private set; }

    [field: Header("Miss")]
    [field: SerializeField] public EventReference missSound { get; private set; }

    [field: Header("Fire dragon")]
    [field: SerializeField] public EventReference fireDragonSound { get; private set; }

    [field: Header("Ground dragon")]
    [field: SerializeField] public EventReference groundDragonSound { get; private set; }

    [field: Header("Ice dragon")]
    [field: SerializeField] public EventReference iceDragonSound { get; private set; }

    [field: Header("Thunder dragon")]
    [field: SerializeField] public EventReference thunderDragonSound { get; private set; }

    [field: Header("Win")]
    [field: SerializeField] public EventReference winSound { get; private set; }

    [field: Header("Total Win")]
    [field: SerializeField] public EventReference totalWinSound { get; private set; }

    [field: Header("Fail")]
    [field: SerializeField] public EventReference failSound { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
