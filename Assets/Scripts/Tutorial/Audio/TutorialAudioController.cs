using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAudioController : MonoBehaviour
{
    public static TutorialAudioController Instance { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void setAudiosToPlayScene()
    {
        TutorialFMODEventsController.Instance.AllowFadeInBackground = true;
    }

    public void setAudiosToGameOverScene()
    {
        TutorialFMODEventsController.Instance.AllowMuteBackgroundWithFadeOut = true;
    }
}
