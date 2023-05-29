using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PLayTutorialGameController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        TutorialAudioController.Instance.StartPlaySceneAudios();
    }

    // Update is called once per frame
    void Update()
    {

    }
}