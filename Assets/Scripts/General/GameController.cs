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

    [field: Header("Mouse Icons")]
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickCursor;

    [field: Header("Windows references")]
    [SerializeField] private GameObject explorerWindow;
    [SerializeField] private GameObject checkWindow;
    [SerializeField] private GameObject checkWindowInstance;

    [field: Header("Check window buttons references")]
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
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
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
        AudioController.instance.PlayOneShot(FMODEventsController.instance.openWindowSound, transform.position);
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame()
    {

        AudioController.instance.PlayOneShot(FMODEventsController.instance.closeWindowSound, transform.position);
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
