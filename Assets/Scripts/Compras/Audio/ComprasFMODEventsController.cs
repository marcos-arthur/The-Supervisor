using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprasFMODEventsController : MonoBehaviour
{
    public static ComprasFMODEventsController instance { get; private set; }
    private List<EventInstance> eventInstances;

    [field: Header("Background")]
    [field: SerializeField] public EventReference backgroundSong { get; private set; }

    [field: Header("Miss")]
    [field: SerializeField] public EventReference missSound { get; private set; }

    [field: Header("Point")]
    [field: SerializeField] public EventReference pointSound { get; private set; }

    [field: Header("Win")]
    [field: SerializeField] public EventReference winSound { get; private set; }

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

        eventInstances = new List<EventInstance>();
    }

    private void Start()
    {
        eventInstances.Add(AudioController.instance.InitializeAmbience(backgroundSong));
    }

    private void OnDestroy()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

}
