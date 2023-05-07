using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodiTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Tutorial");

        FMOD.Studio.EventInstance instance_Tutorial_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Tutorial/BGM");

        FMOD.Studio.EventInstance instance_Tutorial_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Tutorial/Win");

        //instance.start(); inicia o som
        //instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); para o som
        //FMODUnity.RuntimeManager.UnloadBank("bank:/Tutorial"); para de carregar o banco de sons
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
