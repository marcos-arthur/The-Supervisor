using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaloesAudioController : MonoBehaviour
{
    public static BaloesAudioController Instance { get; private set; }

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
        AudioController.instance.PlayOneShot(BaloesFMODEventsController.Instance.ambienceSound, transform.position);
    }

    public void PlayPointSound()
    {
        AudioController.instance.PlayOneShot(BaloesFMODEventsController.Instance.pointSound, transform.position);
    }

    public void PlayFailSound()
    {
        AudioController.instance.PlayOneShot(BaloesFMODEventsController.Instance.failSound, transform.position);
    }

    public void PlayWinSound()
    {
        AudioController.instance.PlayOneShot(BaloesFMODEventsController.Instance.winSound, transform.position);
    }
}
