using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class fmodiRunner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Runner");

        FMOD.Studio.EventInstance instance_Runner_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Runner/BGM");

        FMOD.Studio.EventInstance instance_Runner_Fail = FMODUnity.RuntimeManager.CreateInstance("event:/Runner/Fail");

        FMOD.Studio.EventInstance instance_Runner_Jump = FMODUnity.RuntimeManager.CreateInstance("event:/Runner/Jump");

        FMOD.Studio.EventInstance instance_Runner_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Runner/Win");

        //instance.start(); inicia o som
        //instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); para o som
        //FMODUnity.RuntimeManager.UnloadBank("bank:/Runner"); para de carregar o banco de sons
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
