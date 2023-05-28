using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplorerClose : MonoBehaviour
{
    public Button closeButton;

    public bool authorize = false;

    private GameObject window, taskbarFolder, taskbar;
    // Start is called before the first frame update
    void Start()
    {

        taskbar = GameObject.Find("Taskbar");
        closeButton.onClick.AddListener(windowCloser);
        window = GameObject.FindWithTag("ExplorerWindow");
       
        
    }


    public void windowCloser()
    {
        GameController.instance.explorerOpen = false;
        authorize = true;
    }


    
    // Update is called once per frame
    void Update()
    {
        Transform parentTransform = taskbar.transform;
        Transform childTransform = parentTransform.Find("Folder");
        if (authorize)
        {
            authorize = false;
            closeButton.onClick.RemoveAllListeners();
            
            Destroy(childTransform.gameObject);
            Destroy(window);
        }

       
        
    }
}
