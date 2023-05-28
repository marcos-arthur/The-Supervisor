using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplorerClose : MonoBehaviour
{
    public Button closeButton;

    public bool authorize = false;

    private GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(windowCloser);
        window = GameObject.FindWithTag("ExplorerWindow");
       
        
    }


    public void windowCloser()
    {
        authorize = true;
    }


    
    // Update is called once per frame
    void Update()
    {
        if (authorize)
        {
            authorize = false;
            closeButton.onClick.RemoveAllListeners();
            Destroy(window);
            
        }
    }
}
