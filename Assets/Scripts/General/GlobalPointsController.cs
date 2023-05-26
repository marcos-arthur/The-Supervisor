using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPointsController : MonoBehaviour
{
    public static GlobalPointsController instance = null;

    public int globalPoints = 500, tempPoints;

    public bool currentGameHasStolenAssets { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void handleReponse(bool hasStolenAssetsReponse)
    {
        Debug.Log("hasStolenAssetsReponse " + hasStolenAssetsReponse);
        Debug.Log("currentGameHasStolenAssets " + currentGameHasStolenAssets);

        if (hasStolenAssetsReponse == currentGameHasStolenAssets)
        {
            FMOD.Studio.EventInstance instance_PI_APP_Correct = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Correct");
            instance_PI_APP_Correct.start();

            globalPoints += 500;
        }
        else
        {
            FMOD.Studio.EventInstance instance_PI_APP_Wrong = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Wrong");
            instance_PI_APP_Wrong.start();

            globalPoints -= 500;
        }
    }
    public void addPoints(int points) { 
        globalPoints += points;
        tempPoints = points;    
    }
    
}
