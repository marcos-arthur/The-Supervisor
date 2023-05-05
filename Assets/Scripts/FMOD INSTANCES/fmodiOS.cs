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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
