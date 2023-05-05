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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
