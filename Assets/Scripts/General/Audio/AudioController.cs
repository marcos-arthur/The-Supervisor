using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Volume")]
    [Range(0, 1)]

    public float allVolume = 1;
    [Range(0, 1)]

    public float musicVolume = 1;
    [Range(0, 1)]

    public float sfxVolume = 1;
    [Range(0, 1)]

    private Bus allBus;

    private Bus musicBus;

    private Bus sfxBus;

    public Slider sfxSlider;

    public Slider musicSlider;

    //public Slider allVolumeSlider;

    public static AudioController instance { get; private set; }

    private List<EventInstance> eventInstances;
    private EventInstance ambienceEventInstance;

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

        allBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX"); 
    }

    public void Update()
    {
        
        sfxBus.setVolume(sfxSlider.value);
        musicBus.setVolume(musicSlider.value);
        //allBus.setVolume(allVolumeSlider.value);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldpos)
    {
        RuntimeManager.PlayOneShot(sound, worldpos);
    }

    public EventInstance InitializeAmbience(EventReference ambienceSound)
    {
        ambienceEventInstance = CreateEventInstance(ambienceSound);
        ambienceEventInstance.start();

        return ambienceEventInstance;
    }

    public EventInstance CreateEventInstance(EventReference sound)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(sound);
        eventInstances.Add(eventInstance);

        return eventInstance;
    }

    public void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
