using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPointsController : MonoBehaviour
{
    public static GlobalPointsController instance = null;

    public int globalPoints = 0, tempPoints;

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
        if (hasStolenAssetsReponse == currentGameHasStolenAssets)
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.correctAnswerSound, transform.position);
            globalPoints += 500;
        }
        else
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.wrongAnswerSound, transform.position);
            globalPoints -= 500;
        }
    }
    public void addPoints(int points) { 
        globalPoints += points;
        tempPoints = points;
    }
    
}
