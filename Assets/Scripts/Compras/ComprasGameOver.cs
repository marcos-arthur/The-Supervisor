using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ComprasGameOver : MonoBehaviour
{
    public Text results;
    // Start is called before the first frame update
    void Start()
    {
        if(GameController_Compras.pontuacao > 0) AudioController.instance.PlayOneShot(ComprasFMODEventsController.instance.winSound, transform.position);
        else AudioController.instance.PlayOneShot(ComprasFMODEventsController.instance.missSound, transform.position);

        results.text = "Your Score: " + GameController_Compras.pontuacao;

        GameController.instance.OpenCheckWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
