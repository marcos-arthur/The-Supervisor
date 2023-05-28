using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBankDragonSays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Dragon Says");
        FMODUnity.RuntimeManager.LoadBank("bank:/Master");

        FMOD.Studio.EventInstance instance_Dragon_Says_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/BGM");
        FMOD.Studio.EventInstance instance_Dragon_Says_Fire = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Fire");
        FMOD.Studio.EventInstance instance_Dragon_Says_Ground = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Ground");
        FMOD.Studio.EventInstance instance_Dragon_Says_Ice = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Ice");
        FMOD.Studio.EventInstance instance_Dragon_Says_Thunder = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Thunder");
        FMOD.Studio.EventInstance instance_Dragon_Says_Correct = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Correct");
        FMOD.Studio.EventInstance instance_Dragon_Says_Miss = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Miss");
        FMOD.Studio.EventInstance instance_Dragon_Says_Fail = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Fail");
        FMOD.Studio.EventInstance instance_Dragon_Says_Marromeno = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Marromeno");
        FMOD.Studio.EventInstance instance_Dragon_Says_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Dragon Says/Win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
