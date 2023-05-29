using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTutorialController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TutorialAudioController.Instance.StopPlaySceneAudios();
        GameController.instance.OpenWindow("CheckWindow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
