using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAudioController : MonoBehaviour
{
    public static RunnerAudioController Instance { get; private set; }

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

    // Start is called before the first frame update
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
        // AudioController.instance.PlayOneShot(RunnerFMODEventsController.Instance.ambienceSound, transform.position);
        AudioController.instance.InitializeAmbience(RunnerFMODEventsController.Instance.ambienceSound);
    }

    public void StopPlaySceneAudios()
    {
        AudioController.instance.CleanUp();
    }

    public void PlayDashSound()
    {
        AudioController.instance.PlayOneShot(RunnerFMODEventsController.Instance.dashSound, transform.position);
    }

    public void PlayFailSound()
    {
        AudioController.instance.PlayOneShot(RunnerFMODEventsController.Instance.failSound, transform.position);
    }

    public void PlayWinSound()
    {
        AudioController.instance.PlayOneShot(RunnerFMODEventsController.Instance.winSound, transform.position);
    }
}
