using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodiBaloes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Baloes");

        FMOD.Studio.EventInstance instance_Baloes_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Baloes/BGM");

        FMOD.Studio.EventInstance instance_Baloes_Fail = FMODUnity.RuntimeManager.CreateInstance("event:/Baloes/Fail");

        FMOD.Studio.EventInstance instance_Baloes_Points_1 = FMODUnity.RuntimeManager.CreateInstance("event:/Baloes/Points 1");

        FMOD.Studio.EventInstance instance_Baloes_Points_2 = FMODUnity.RuntimeManager.CreateInstance("event:/Baloes/Points 2");

        FMOD.Studio.EventInstance instance_Baloes_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Baloes/Win");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
