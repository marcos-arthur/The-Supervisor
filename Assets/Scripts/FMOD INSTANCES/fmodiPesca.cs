using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodiPesca : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Pesca");

        FMOD.Studio.EventInstance instance_Pesca_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/BGM");

        FMOD.Studio.EventInstance instance_Pesca_Water_Enter = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Water Enter");

        FMOD.Studio.EventInstance instance_Pesca_Water_Out = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Water Out");

        FMOD.Studio.EventInstance instance_Pesca_Point = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Point");

        FMOD.Studio.EventInstance instance_Pesca_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
