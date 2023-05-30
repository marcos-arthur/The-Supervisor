using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BaloesEnd : MonoBehaviour
{
    public Text endMenssage;
    // Start is called before the first frame update
    void Start()
    {
        int finalScore = BaloesGameController.pontuacao;
        if (finalScore <= 0)
        {
            endMenssage.text = "OOHH! What a shame :(   Your score: " + BaloesGameController.pontuacao;
            BaloesAudioController.Instance.PlayFailSound();
        }
        else
        {
            endMenssage.text = "Congratulations!   Your score: " + BaloesGameController.pontuacao;
            BaloesAudioController.Instance.PlayWinSound();
        }
        
        GameController.instance.OpenCheckWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
