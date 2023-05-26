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
       // FMOD.Studio.EventInstance instance_Compras_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/BGM");
        FMOD.Studio.EventInstance instance_Compras_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/Win");
        //instance_Compras_BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        instance_Compras_Win.start();
        FMODUnity.RuntimeManager.UnloadBank("bank:/Compras");
        results.text = "Your Score: " + GameController_Compras.pontuacao;

        GameController.instance.OpenWindow("CheckWindow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
