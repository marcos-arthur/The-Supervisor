using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFishFMODEventsController : MonoBehaviour
{
    public static FreeFishFMODEventsController instance { get; private set; }
    private List<EventInstance> eventInstances;

    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambienceSound { get; private set; }

    [field: Header("Background")]
    [field: SerializeField] public EventReference backgroundSong { get; private set; }

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
        DontDestroyOnLoad(gameObject);

        eventInstances = new List<EventInstance>();
    }

    private void Start()
    {
        eventInstances.Add(AudioController.instance.InitializeAmbience(ambienceSound));
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
