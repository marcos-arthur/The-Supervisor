using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FreeFishController : MonoBehaviour
{
    public static FreeFishController Instance = null;
    private GlobalPointsController pointsController;

    [field: Header("Referências")]
    public FishController fishController;
    public GameObject Aim, LineRenderer;

    [field: Header("Valores")]
    public float catchDuration = 0.5f;
    public float timeLeft = 60f;

    FishBehaviour fishBehaviour;
    public bool setLine { get; private set; }

    static int totalPoints = 0;
    private bool copyright = false, isButtonDown = false, gameOn = false, setPoints = false;
    private float bTimer;
    private Text points, timer;
    private GameObject aux;

    [field: Header("Stolen Assets Lists")]
    [SerializeField] public List<GameObject> freeFishStolenAssetsList;

    public Button closeGameButton;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
           Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += LoadGame;
    }

    void Start()
    {
        setLine = true;

        pointsController = GlobalPointsController.instance;
        GameController.instance.minigameControllerReference = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn) 
        { 
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                if(timer != null)
                timer.text = "Time: " + string.Format("{0:N0}", timeLeft) + "s";
                isButtonDown = Input.GetMouseButton(0);
                if (Input.GetMouseButton(0))
                {
                    bTimer += Time.deltaTime;
                    if (bTimer > 0.3)
                    {
                        isButtonDown = false;
                    }
                }
                else
                {
                    bTimer = 0;
                }
            }
            else
            {
                EndGame();
            }
        }
    }

    void FixedUpdate()
    {
        if(setPoints)points.text = "Score: " + totalPoints.ToString();
    }

    public void CatchFish(GameObject fish)
    {
        // 0 para o botão esquerdo do mouse, 1 para o botão direito, 2 para o botão do meio
        if (isButtonDown) 
        {
            fishBehaviour = fish.GetComponent<FishBehaviour>();
            totalPoints += fishBehaviour.getPoints();
            if (fishBehaviour.copyright) copyright = true;
            
            Destroy(fish);
            FishController temp = FindObjectOfType<FishController>();
            temp.DestroyFish();

            AudioController.instance.PlayOneShot(FreeFishFMODEventsController.instance.catchFishSound, transform.position);
        }
    }

    void LoadGame(Scene scene,LoadSceneMode mode)
    {
        if(scene.name.Equals("Free Fish") || scene.name.Equals("Game Over Free Fish"))
        {
            aux = GameObject.FindGameObjectWithTag("Points");
            points = aux.GetComponent<Text>();
            aux = GameObject.FindGameObjectWithTag("Timer");
            timer = aux.GetComponent<Text>();
        }
        if (scene.name.Equals("Game Over Free Fish"))
        {
            // GameController.instance.OpenCheckWindow();

            closeGameButton = GameObject.FindGameObjectWithTag("closeGameButton").GetComponent<Button>();
            closeGameButton.onClick.AddListener(CloseGame);
        }
    }

    public void CloseGame()
    {
        GameController.instance.OpenSelectionWindow(freeFishStolenAssetsList);
        // GameController.instance.CloseGame();
    }

    void EndGame()
    {
        Destroy(LineRenderer);
        Destroy(Aim);

        pointsController.addPoints(totalPoints);
        pointsController.currentGameHasStolenAssets = copyright;
        
        gameOn = false;
        setLine = false;

        AudioController.instance.PlayOneShot(FreeFishFMODEventsController.instance.winFreeFishSound, transform.position);
        SceneManager.LoadScene("Game Over Free Fish");
    }

    public void StartGame()
    {
        gameOn = true;
        setPoints = true;
        SceneManager.LoadScene("Free Fish");
    }
}