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
        FMOD.Studio.EventInstance instance_OS_StartingOS = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Starting OS");
        instance_OS_StartingOS.start();

        GamesScore.globalPoints = 500;
        GamesScore.openedGameScene = "";

        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FMOD.Studio.EventInstance instance_OS_Mouse_Click = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Mouse Click");
            instance_OS_Mouse_Click.start();
        }

        if(GamesScore.openedGameScene != "" && !isGameWindowOpen)
        {
            isGameWindowOpen = true;
            SceneManager.LoadScene(GamesScore.openedGameScene);
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
            FMOD.Studio.EventInstance instance_OS_Open_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Open Window");
            instance_OS_Open_Window.start();

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
            FMOD.Studio.EventInstance instance_PI_APP_Correct = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Correct");
            instance_PI_APP_Correct.start();

            GamesScore.globalPoints += 500;
        }
        else
        {
            FMOD.Studio.EventInstance instance_PI_APP_Wrong = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Wrong");
            instance_PI_APP_Wrong.start();

            GamesScore.globalPoints -= 500;
        }

        closeGame();
    }

    public void noResponse()
    {
        if (!GamesScore.hasStolenAsset)
        {
            FMOD.Studio.EventInstance instance_PI_APP_Correct = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Correct");
            instance_PI_APP_Correct.start();

            GamesScore.globalPoints += 500;
        }
        else
        {
            FMOD.Studio.EventInstance instance_PI_APP_Wrong = FMODUnity.RuntimeManager.CreateInstance("event:/PI  APP/Wrong");
            instance_PI_APP_Wrong.start();

            GamesScore.globalPoints -= 500;
        }

        closeGame();
    }

    public void closeGame()
    {
        FMOD.Studio.EventInstance instance_OS_Close_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Close Window");
        instance_OS_Close_Window.start();

        SceneManager.UnloadSceneAsync(GamesScore.openedGameScene);
        
        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();

        Destroy(checkWindowInstance);
        
        GamesScore.openedGameScene = "";
        GamesScore.canOpenCheckWindow = false;
        isCheckWindowOpen = false;
    }
}
