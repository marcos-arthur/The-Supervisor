using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAudioController : MonoBehaviour
{
    public static TutorialAudioController Instance { get; private set; }

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

    void Start()
    {
        GameController.instance.minigameControllerReference = gameObject;
    }

    private void OnDestroy()
    {
        AudioController.instance.CleanUp();
    }

    public void StartPlaySceneAudios()
    {
        AudioController.instance.InitializeAmbience(TutorialFMODEventsController.Instance.backgroundSong);
    }

    public void StopPlaySceneAudios()
    {
        AudioController.instance.CleanUp();
    }

    public void PlaySound(EventReference sound)
    {
        AudioController.instance.PlayOneShot(sound, transform.position);
    }
}
