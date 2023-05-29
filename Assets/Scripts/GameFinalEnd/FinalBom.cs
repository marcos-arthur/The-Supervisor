using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class FinalBom : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI mensagemFinal;
    [SerializeField] public Text ScoreFinal;
    public Button exitbutton;

    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.PlayOneShot(FMODEventsController.instance.GameEndWin,transform.position);
        
        exitbutton.onClick.AddListener(ExitGame);
       
        mensagemFinal.text = "As the game neared its conclusion, you meticulously combed through its digital landscape, meticulously identifying stolen assets. Your expertise and dedication were unparalleled as you uncovered instances of intellectual property infringement and built a compelling case against the perpetrators.\r\n\r\nIn a climactic confrontation, you presented your irrefutable evidence, exposing the thieves and reclaiming the stolen creations. The gaming community erupted in applause, recognizing your remarkable achievements.\r\n\r\nYour success led to a well-deserved promotion within the virtual company, where you were entrusted with implementing robust intellectual property protection measures. Your name became synonymous with integrity and your influence spread, inspiring a new era of respect for creators' rights.\r\n\r\nIn the end, you stood as a champion of justice, leaving a lasting impact on the gaming community and beyond.";
        ScoreFinal.text = "Your score: " + GlobalPointsController.instance.globalPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
