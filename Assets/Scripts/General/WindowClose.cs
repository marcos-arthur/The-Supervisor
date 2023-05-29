using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowClose : MonoBehaviour
{
    public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
       closeButton.onClick.AddListener(clickedX);
    }

    void clickedX()
    {
        GameController.instance.wasClickedinX = true;
        GameController.instance.CloseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
