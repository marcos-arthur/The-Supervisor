using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private string openedGame;

    private bool isGameWindowOpen = false;
    private bool isExplorerWindowOpen = false;
    private bool isCheckWindowOpen = false;
    // private bool isExplorerWindowOpen = false;

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    [SerializeField] private GameObject explorerWindow;
    [SerializeField] private GameObject checkWindow;
    [SerializeField] private GameObject checkWindowInstance;

    [SerializeField] private Button noButton;
    [SerializeField] private Button yesButton;

    // Start is called before the first frame update
    void Start()
    {
        GamesScore.globalPoints = 500;
        GamesScore.openedGameScene = "";

        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if(GamesScore.openedGameScene != "" && !isGameWindowOpen)
        {
            isGameWindowOpen = true;
            SceneManager.LoadScene(GamesScore.openedGameScene, LoadSceneMode.Additive);
        }

        if(GamesScore.canOpenCheckWindow && !isCheckWindowOpen)
        {
            checkWindowInstance = Instantiate(checkWindow);
            // checkWindowInstance = GameObject.Find("Check window(Clone)");

            isCheckWindowOpen = true;

            noButton = GameObject.Find("NoButton").GetComponent<Button>();
            yesButton = GameObject.Find("YesButton").GetComponent<Button>();

            noButton.onClick.AddListener(yesResponse);
            yesButton.onClick.AddListener(noResponse);
        }
    }

    public void setopenedApp(string opened)
    {
        GamesScore.openedGameScene = opened;
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

    public void yesResponse()
    {
        if (GamesScore.hasStolenAsset)
        {
            GamesScore.globalPoints += 500;
        }
        else
        {
            GamesScore.globalPoints -= 500;
        }

        closeGame();
    }

    public void noResponse()
    {
        if (!GamesScore.hasStolenAsset)
        {
            GamesScore.globalPoints += 500;
        }
        else
        {
            GamesScore.globalPoints -= 500;
        }

        closeGame();
    }

    public void closeGame()
    {
        SceneManager.UnloadSceneAsync(GamesScore.openedGameScene);
        
        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();

        Destroy(checkWindowInstance);
        
        GamesScore.openedGameScene = "";
        GamesScore.canOpenCheckWindow = false;
        isCheckWindowOpen = false;
    }
}
