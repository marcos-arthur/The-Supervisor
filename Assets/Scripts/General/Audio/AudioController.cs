using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioController : MonoBehaviour
{
    public static AudioController instance { get; private set; }

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
    }

    public void PlayOneShot(EventReference sound, Vector3 worldpos)
    {
        RuntimeManager.PlayOneShot(sound, worldpos);
    }
}
