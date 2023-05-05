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

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
