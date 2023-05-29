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
    [SerializeField] public TextMeshProUGUI ScoreFinal;
    public Button exitbutton;

    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.PlayOneShot(FMODEventsController.instance.GameEndWin,transform.position);
        
        exitbutton.onClick.AddListener(ExitGame);
       
        mensagemFinal.text = "Congratulations! \r\n\r\nYour performance was amazing and you have been promoted!\r\nDont let the IP infrators be unpunished!";
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
