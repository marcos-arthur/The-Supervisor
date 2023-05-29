using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class FinalRuim : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI mensagemFinal;
    [SerializeField] public Text ScoreFinal;
    public Button exitbutton;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.PlayOneShot(FMODEventsController.instance.GameEndLose, transform.position);
        
        exitbutton.onClick.AddListener(ExitGame);
        
        mensagemFinal.text = "Sorry! ..(mensagem)";
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
