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

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPlaySceneAudios()
    {
        AudioController.instance.PlayOneShot(RunnerFMODEventsController.Instance.ambienceSound, transform.position);
    }

    public void PlayPointSound()
    {
        // AudioController.instance.PlayOneShot(RunnerFMODEventsController.Instance.pointSound, transform.position);
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
