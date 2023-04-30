using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private string openedGame;

    private bool isGameWindowOpen = false;
    private bool isExplorerWindowOpen = false;
    // private bool isExplorerWindowOpen = false;

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    [SerializeField] private GameObject explorerWindow;

    // Start is called before the first frame update
    void Start()
    {
        openedGame = "";

        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if(openedGame != "" && !isGameWindowOpen)
        {
            isGameWindowOpen = true;
            SceneManager.LoadScene(openedGame, LoadSceneMode.Additive);
        }
    }

    public void setopenedApp(string opened)
    {
        openedGame = opened;
    }

    public Texture2D getDefaultCursor()
    {
        return defaultCursor;
    }

    public Texture2D getClickCursor()
    {
        return clickCursor;
    }

    public void openWindow(string window)
    {
        if (window == "Explorer Window" && !isExplorerWindowOpen)
        {
            Instantiate(explorerWindow);
            isExplorerWindowOpen = true;
        }

        /*if (openedGame == "Explorer Window" && !isExplorerWindowOpen)
        {
            Instantiate(explorerWindow);
            isExplorerWindowOpen = true;
        }*/
    }
}
