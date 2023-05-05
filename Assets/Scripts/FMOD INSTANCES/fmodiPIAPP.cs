using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodiPIAPP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/PI APP");

        FMOD.Studio.EventInstance instance_PI_APP_Confirm = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Confirm");

        FMOD.Studio.EventInstance instance_PI_APP_Correct = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Correct");

        FMOD.Studio.EventInstance instance_PI_APP_Counter = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Counter");

        FMOD.Studio.EventInstance instance_PI_APP_Wrong = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Wrong");

        FMOD.Studio.EventInstance instance_PI_APP_WIN = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/WIN");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
