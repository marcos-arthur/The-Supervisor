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
        endMenssage.text = "Congratulations!   Your score: " + BaloesGameController.pontuacao;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
