using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodiOS : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Master");

        FMOD.Studio.EventInstance instance_OS_StartingOS = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Starting OS");

        FMOD.Studio.EventInstance instance_OS_Mouse_Click = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Mouse Click");

        FMOD.Studio.EventInstance instance_OS_Acesso_Negado = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Acesso Negado");

        FMOD.Studio.EventInstance instance_OS_Open_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Open Window");

        FMOD.Studio.EventInstance instance_OS_Close_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Close Window");


        FMODUnity.RuntimeManager.LoadBank("bank:/PI  APP");

        FMOD.Studio.EventInstance instance_PI_APP_Confirm = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Confirm");

        FMOD.Studio.EventInstance instance_PI_APP_Correct = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Correct");

        FMOD.Studio.EventInstance instance_PI_APP_Counter = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Counter");

        FMOD.Studio.EventInstance instance_PI_APP_Wrong = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Wrong");

        FMOD.Studio.EventInstance instance_PI_APP_WIN = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/WIN");

        //instance.start(); inicia o som
        //instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); para o som
        //FMODUnity.RuntimeManager.UnloadBank("bank:/Master"); para de carregar o banco de sons
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
