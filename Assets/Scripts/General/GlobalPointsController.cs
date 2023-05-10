using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPointsController : MonoBehaviour
{
    public static GlobalPointsController instance = null;
    
    public int globalPoints = 500;

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
            globalPoints += 500;
        }
        else
        {
            globalPoints -= 500;
        }
    }
}
