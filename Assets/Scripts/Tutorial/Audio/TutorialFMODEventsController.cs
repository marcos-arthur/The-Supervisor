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

    [field: Header("Volumes")]
    [SerializeField] private float lowerVolume = 0.5f;
    [SerializeField] private float currentVolume = 0.5f;

    [field: Header("Background song")]
    [field: SerializeField] public EventReference backgroundSong { get; private set; }
    private EventInstance backgroundSongReference;

    [field: Header("Win sound")]
    [field: SerializeField] public EventReference winSound { get; private set; }

    public bool AllowFadeInBackground { get; set; }
    public bool AllowMuteBackgroundWithFadeOut { get; set; }

    private float totalTime = 1;
    private float currentTime = 0;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        backgroundSongReference = AudioController.instance.InitializeAmbience(backgroundSong);
        backgroundSongReference.setParameterByName("volume", lowerVolume);

        AllowFadeInBackground = false;
        AllowMuteBackgroundWithFadeOut = false;
    }

    private void Update()
    {
        if(AllowFadeInBackground)
        {
            if(currentTime < totalTime)
            {
                currentVolume = Mathf.Lerp(lowerVolume, 1f, currentTime / totalTime);
                backgroundSongReference.setParameterByName("volume", currentVolume);
                currentTime += Time.deltaTime;
            }
            else
            {
                AllowFadeInBackground = false;
                currentTime = 0;
            }
        }

        if (AllowMuteBackgroundWithFadeOut)
        {
            if (currentTime < totalTime)
            {
                currentVolume = Mathf.Lerp(1f, 0, currentTime / totalTime);
                backgroundSongReference.setParameterByName("volume", currentVolume);
                currentTime += Time.deltaTime;
            }
            else
            {
                AllowMuteBackgroundWithFadeOut = false;
                currentTime = 0;
            }
        }
    }

    private void OnDestroy()
    {
        backgroundSongReference.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        backgroundSongReference.release();
    }

    public void setBackGroundVolume(float volume)
    {
        backgroundSongReference.setParameterByName("volume", volume);
    }

}
