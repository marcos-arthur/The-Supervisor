using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenController : MonoBehaviour
{
    private bool playerResponse;
    private bool hasStolenAsset;

    // Start is called before the first frame update
    void Start()
    {
        hasStolenAsset = GamesScore.hasStolenAsset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
