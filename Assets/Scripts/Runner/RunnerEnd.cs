using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Text results;    
    // Start is called before the first frame update
    void Start()
    {
        RunnerAudioController.Instance.StopPlaySceneAudios();

        int finalScore = RunnerGameController.pontos;
        if (finalScore <= 0)
        {
            results.text = "OOHHH, Nice try!            Your score: " + finalScore;
        }
        else
        {
            results.text = "Congratulations!            Your score: " + finalScore;
        }

        GameController.instance.OpenCheckWindow();
    }
}
