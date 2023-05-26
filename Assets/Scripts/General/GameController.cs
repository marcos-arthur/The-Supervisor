using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    [SerializeField] private GameObject explorerWindow;
    [SerializeField] private GameObject checkWindow;
    [SerializeField] private GameObject checkWindowInstance;

    [SerializeField] public Button noButton = null;
    [SerializeField] public Button yesButton = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        FMOD.Studio.EventInstance instance_OS_StartingOS = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Starting OS");
        instance_OS_StartingOS.start();

        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FMOD.Studio.EventInstance instance_OS_Mouse_Click = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Mouse Click");
            instance_OS_Mouse_Click.start();
        }
    }

    public void OpenGame(string sceneName)
    {
        FMOD.Studio.EventInstance instance_OS_Open_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Open Window");
        instance_OS_Open_Window.start();

        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame()
    {

        FMOD.Studio.EventInstance instance_OS_Close_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Close Window");
        instance_OS_Close_Window.start();

        SceneManager.LoadScene("onDesktop");
        GlobalPointsController.instance.currentGameHasStolenAssets = false;

        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();
        Destroy(checkWindowInstance);
    }

    public void OpenWindow(string window)
    {
        if (window == "ExplorerWindow" && GameObject.FindGameObjectWithTag(window) == null)
        {
            FMOD.Studio.EventInstance instance_OS_Open_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Open Window");
            instance_OS_Open_Window.start();

            Instantiate(explorerWindow);
        } 
        else if(window == "CheckWindow" && GameObject.FindGameObjectWithTag(window) == null)
        {
            FMOD.Studio.EventInstance instance_OS_Open_Window = FMODUnity.RuntimeManager.CreateInstance("event:/OS/Open Window");
            instance_OS_Open_Window.start();

            checkWindowInstance = Instantiate(checkWindow);
        }
    }

    public void CloseWindow(GameObject window)
    {
        Destroy(window);
    }

    public Texture2D getDefaultCursor()
    {
        return defaultCursor;
    }

    public Texture2D getClickCursor()
    {
        return clickCursor;
    }

    public void ButtonReponse(bool hasStolenAsset)
    {
        GlobalPointsController.instance.handleReponse(hasStolenAsset);
        CloseGame();
        Destroy(GameObject.FindWithTag("MinigameController"));
    }

}
