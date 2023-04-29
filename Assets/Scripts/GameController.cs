using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private string openedApp;

    private bool isGameWindowOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        openedApp = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(openedApp == "Explorer" && !isGameWindowOpen)
        {
            isGameWindowOpen = true;
            SceneManager.LoadScene("Explorer", LoadSceneMode.Additive);
        }
    }

    public void setopenedApp(string opened)
    {
        openedApp = opened;
    }
}
