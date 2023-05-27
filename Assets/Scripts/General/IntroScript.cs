using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{

    public GameObject panel;
    public Button startIntro;
    
    // Start is called before the first frame update
    void Start()
    {
        startIntro.onClick.AddListener(closeScreen);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.readIntroText == true)
        {
            startIntro.interactable = false;
            panel.SetActive(false); 
        }
    }


    void closeScreen()
    {
        GameController.instance.readIntroText = true;
        startIntro.interactable = false;
        panel.SetActive(false);
    }
}
