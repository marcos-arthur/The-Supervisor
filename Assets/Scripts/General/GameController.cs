using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<string> FinishedGameApps = new List<string>();
    public static GameController instance { get; private set; }

    [field: Header("Values")]
    [SerializeField] public bool readIntroText = false;

    [field: Header("Mouse Icons")]
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    [field: Header("Windows references")]
    [SerializeField] private GameObject explorerWindow;
    [SerializeField] private GameObject checkWindow;
    [SerializeField] private GameObject checkWindowInstance;
    [SerializeField] public bool explorerOpen;

    [field: Header("Check window buttons references")]
    [SerializeField] public Button noButton = null;
    [SerializeField] public Button yesButton = null;

    [field: Header("Game Apps")]
    [SerializeField] public GameObject GameIconReference;

    [field: SerializeField] public GameObject minigameControllerReference { get; set; }

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
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
        AudioController.instance.PlayOneShot(FMODEventsController.instance.startupSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.mouseClickSound, transform.position);
        }
    }
    public void OpenGame(string sceneName)
    {
        explorerOpen = false;

        SceneManager.LoadScene(sceneName);
        AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
        SceneManager.LoadScene(sceneName);   
    }

    public void CloseGame()
    {
        explorerOpen = false;

        AudioController.instance.PlayOneShot(FMODEventsController.instance.closeWindowSound, transform.position);
        SceneManager.LoadScene("onDesktop");

        GlobalPointsController.instance.currentGameHasStolenAssets = false;

        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();
        Destroy(checkWindowInstance);

        if (minigameControllerReference != null) {
            Destroy(minigameControllerReference);
            minigameControllerReference = null;
        }
    }

    public void OpenWindow(string window)
    {
 
        Debug.Log("VATATATASWTSDGFSDF");
        if (window == "ExplorerWindow" && GameObject.FindGameObjectWithTag(window) == null && explorerOpen == false)
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
            Instantiate(explorerWindow);
        } 
        else if(window == "CheckWindow" && GameObject.FindGameObjectWithTag(window) == null)
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
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
    }
}
