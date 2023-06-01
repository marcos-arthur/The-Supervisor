using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameController : MonoBehaviour
{
    public List<string> FinishedGameApps = new List<string>();
    public static GameController instance { get; private set; }

    [field: Header("Values")]
    [SerializeField] public bool readIntroText = false;
    [SerializeField] public bool explorerOpen;
    [SerializeField] public bool wasClickedinX;
    [SerializeField] public bool isTutorial = false;

    [field: Header("Mouse Icons")]
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    [field: Header("Windows references")]
    [SerializeField] private GameObject explorerWindow;
    [SerializeField] private GameObject checkWindow;
    [SerializeField] private GameObject checkWindowInstance;

    [field: Header("Window Prefab references")]
    [SerializeField] private GameObject ScoreWindowPrefab;
    [SerializeField] private GameObject SelectionWindowPrefab;

    [field: Header("Minigame references")]
    [field: SerializeField] public GameObject minigameControllerReference { get; set; }

    [field: Header("Check window buttons references")]
    [SerializeField] public Button noButton = null;
    [SerializeField] public Button yesButton = null;

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
        Transform[] objects = GameObject.Find("Taskbar").GetComponentsInChildren<Transform>();

        bool isFolderOpen = false;
        oppenedApps.Clear();

        List<GameObject> toDelete = new List<GameObject>();

        for(int i = 1; i < objects.Length; i += 2)
        {
            if (objects[i].name != "Folder")
            {
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
        Transform[] objects = GameObject.Find("Taskbar").GetComponentsInChildren<Transform>();

        List<GameObject> toDelete = new List<GameObject>();

        for (int i = 0; i < objects.Length; i++)
        {
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
            if (checkWindowInstance)
            {
                noButton.onClick.RemoveAllListeners();
                yesButton.onClick.RemoveAllListeners();
                Destroy(checkWindowInstance);
            }
            if (ScoreWindow.instance)
            {
                /*Destroy(ScoreWindow.instance);
                Destroy(SelectionWindow.Instance);*/
            }
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

    public void OpenSelectionWindow(List<GameObject> m_stolenItems)
    {
        if(SelectionWindowPrefab !=  null)
        {
            CloseGame();

            Instantiate(SelectionWindowPrefab);
            SelectionWindow.Instance.SetValues(m_stolenItems);
        }
        else
        {
            print("SELECTION WINDOW MUST BE SETTED");
        }
    }

    public void OpenScoreWindow()
    {
        if (SelectionWindow.Instance.selectedItems.Count == SelectionWindow.Instance.SelectLimit)
        {
            if (isTutorial && SelectionWindow.Instance.selectedItems[0].name != "Tutorial")
            {
                SelectionWindow.Instance.ShowAngryText();
                return;
            }

            if (isTutorial) isTutorial = false;

            AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
            Instantiate(ScoreWindowPrefab);
            ScoreWindow.instance.CheckItems(SelectionWindow.Instance.selectedItems, SelectionWindow.Instance.StolenItems);

            Destroy(SelectionWindow.Instance.gameObject);
        }
    }

    public void CloseScoreWindow()
    {
        Destroy(ScoreWindow.instance.gameObject);

        if (FinishedGameApps.Count == 6)
        {
            if (GlobalPointsController.instance.globalPoints > 1800)
            {
                SceneManager.LoadScene("GameFinalEndBom");
            }
            else
            {
                SceneManager.LoadScene("GameFinalEndRuim");
            }
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
