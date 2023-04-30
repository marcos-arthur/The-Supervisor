using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private string openedApp;

    private bool isGameWindowOpen = false;

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    // Start is called before the first frame update
    void Start()
    {
        openedApp = "";

        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if(openedApp != "" && !isGameWindowOpen)
        {
            isGameWindowOpen = true;
            SceneManager.LoadScene(openedApp, LoadSceneMode.Additive);
        }
    }

    public void setopenedApp(string opened)
    {
        openedApp = opened;
    }

    public Texture2D getDefaultCursor()
    {
        return defaultCursor;
    }

    public Texture2D getClickCursor()
    {
        return clickCursor;
    }
}
