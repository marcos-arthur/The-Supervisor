using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloesFMODEventsController : MonoBehaviour
{
    public static BaloesFMODEventsController Instance { get; private set; }
    private List<EventInstance> eventInstances;

    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambienceSound { get; private set; }

    [field: Header("Point")]
    [field: SerializeField] public EventReference pointSound { get; private set; }

    [field: Header("Win")]
    [field: SerializeField] public EventReference winSound { get; private set; }

    [field: Header("Fail")]
    [field: SerializeField] public EventReference failSound { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


}
