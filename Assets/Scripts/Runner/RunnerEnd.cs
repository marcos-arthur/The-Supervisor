using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Text results;    
    // Start is called before the first frame update
    void Start()
    {
        results.text = "Congratulations!            Your score: " + RunnerGameController.pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
