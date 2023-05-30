using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameController : MonoBehaviour
{
    public List<string> FinishedGameApps = new List<string>();
    public static GameController instance { get; private set; }

    [SerializeField] public Transform teste;

    [field: Header("Values")]
    [SerializeField] public bool readIntroText = false;
    [SerializeField] public bool explorerOpen;
    [SerializeField] public bool wasClickedinX;

    [field: Header("Mouse Icons")]
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    [field: Header("Windows references")]
    [SerializeField] private GameObject explorerWindow;
    [SerializeField] private GameObject checkWindow;
    [SerializeField] private GameObject checkWindowInstance;
    [field: SerializeField] public GameObject minigameControllerReference { get; set; }


    [field: Header("Check window buttons references")]
    [SerializeField] public Button noButton = null;
    [SerializeField] public Button yesButton = null;

    [field: Header("Game Apps")]
    [SerializeField] public GameObject GameIconReference;

    [field: Header("Taskbar Items List")]
    [SerializeField] public List<GameObject> taskbarItemList;
    public List<string> oppenedApps {  get; private set; }

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

        oppenedApps = new List<string>();
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
        // explorerOpen = false;

        SceneManager.LoadScene(sceneName);
        AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator CleanGamesFromTaskbar()
    {
        // teste = GameObject.Find("Taskbar");
        Transform[] objects = GameObject.Find("Taskbar").GetComponentsInChildren<Transform>();
        // objects = objects.Skip(1).ToArray();

        bool isFolderOpen = false;
        oppenedApps.Clear();

        List<GameObject> toDelete = new List<GameObject>();

        // GameObject[] objects = GameObject.Find("Taskbar").GetComponentsInChildren<GameObject>();
        for(int i = 1; i < objects.Length; i += 2)
        {
            if (objects[i].name != "Folder")
            {
                //Destroy(objects[i].gameObject);

                toDelete.Add(objects[i].gameObject);
            }
            else
            {
                isFolderOpen = true;
            }
        }

        foreach(GameObject obj in toDelete) 
        {
            Destroy(obj);
        }

        if(isFolderOpen) { oppenedApps.Add("Folder"); }

        yield return null;
    }

    private IEnumerator CleanExplorerFromTaskbar()
    {
        // teste = GameObject.Find("Taskbar");
        Transform[] objects = GameObject.Find("Taskbar").GetComponentsInChildren<Transform>();
        // objects = objects.Skip(1).ToArray();

        // bool isFolderOpen = false;
        // oppenedApps.Clear(); CLEAR FOLDER FROM HERE

        List<GameObject> toDelete = new List<GameObject>();

        // GameObject[] objects = GameObject.Find("Taskbar").GetComponentsInChildren<GameObject>();
        for (int i = 0; i < objects.Length; i++)
        {
            print("A1");
            if (objects[i].name == "Folder")
            {
                Destroy(objects[i].gameObject);
                break;
            }
        }

        for(int i = 0; i < oppenedApps.Count; i++)
        {
            if (oppenedApps[i] == "Folder") oppenedApps.RemoveAt(i);
        }

        yield return null;
    }

    public void CloseGame()
    {
        // explorerOpen = false;

        AudioController.instance.PlayOneShot(FMODEventsController.instance.closeWindowSound, transform.position);
        SceneManager.LoadScene("onDesktop");

        GlobalPointsController.instance.currentGameHasStolenAssets = false;

        StartCoroutine(CleanGamesFromTaskbar());

        if (wasClickedinX == true)
        {
            FinishedGameApps.RemoveAt(FinishedGameApps.Count - 1);
        }
        else
        {
            noButton.onClick.RemoveAllListeners();
            yesButton.onClick.RemoveAllListeners();
            Destroy(checkWindowInstance);
            wasClickedinX = false;
        }

        if (minigameControllerReference != null) {
            Destroy(minigameControllerReference);
            minigameControllerReference = null;
        }
    }

    public void OpenCheckWindow()
    {
        if(GameObject.FindGameObjectWithTag("CheckWindow") == null)
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
            checkWindowInstance = Instantiate(checkWindow);
        }
    }

    public void OpenExplorerWindow()
    {
        //if (GameObject.FindGameObjectWithTag("ExplorerWindow") == null && explorerOpen == false)
        if (GameObject.FindGameObjectWithTag("ExplorerWindow") == null)
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
            Instantiate(explorerWindow);
        }
    }

    public void CloseWindow(GameObject window)
    {
        if (window.name == "Explorer Window(Clone)")
        {
            StartCoroutine(CleanExplorerFromTaskbar());
        }
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
        wasClickedinX = false;
        CloseGame();
        if (FinishedGameApps.Count == 6)
        {
            if(GlobalPointsController.instance.globalPoints > 0)
            {
                SceneManager.LoadScene("GameFinalEndBom");
            }
            else
            {
                SceneManager.LoadScene("GameFinalEndRuim");
            }
        }
    }
}
