using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOff : MonoBehaviour
{
    // Start is called before the first frame update

    public Button turnOff;
    void Start()
    {
        turnOff.onClick.AddListener(turnOffGame);
    }

    // Update is called once per frame

    void turnOffGame()
    {
       /// UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
    void Update()
    {
        
    }
}
