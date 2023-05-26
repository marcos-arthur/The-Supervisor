using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
//using FMODUnity;
using TMPro;

public class FreeFishController : MonoBehaviour
{
    public static FreeFishController Instance = null; //{ get; private set; }

    static int totalPoints = 0;
    FishBehaviour fishBehaviour;
    public FishController fishController;    
    public float catchDuration = 0.5f, timeLeft = 60f;    
    public AudioSource fishCatchSource, stopFishing;    
    public GameObject Aim, LineRenderer;
    public bool setLine { get; private set; }

    //private StudioEventEmitter eventEmitter;
    private AudioClip shortFishCatch;
    private GlobalPointsController pointsController;
    private bool copyright = false, isButtonDown = false,gameOn = false,setPoints = false;
    private float bTimer;
    private Text points, timer;
    private GameObject aux;
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
        //invokeSounds();        
        //shortFishCatch = AudioClip.Create("ShortClip", (int)(fishCatchSource.clip.samples * (catchDuration / fishCatchSource.clip.length)), fishCatchSource.clip.channels, fishCatchSource.clip.frequency, false);
        //float[] data = new float[(int)(fishCatchSource.clip.samples * (catchDuration / fishCatchSource.clip.length))];
        //fishCatchSource.clip.GetData(data, (int)(fishCatchSource.clip.samples * (catchDuration / fishCatchSource.clip.length)));
        //shortFishCatch.SetData(data, 0);
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

        if (isButtonDown) // 0 para o botão esquerdo do mouse, 1 para o botão direito, 2 para o botão do meio
        {
            fishBehaviour = fish.GetComponent<FishBehaviour>();
            totalPoints += fishBehaviour.getPoints();
            if (fishBehaviour.copyright) copyright = true;
            Destroy(fish);
            FishController temp = FindObjectOfType<FishController>();
            temp.DestroyFish();
            //eventEmitter.EventReference


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
    }

    void EndGame()
    {        
        Destroy(LineRenderer);
        // stopFishing.Play();
        Destroy(Aim);        
        pointsController.addPoints(totalPoints);
        pointsController.currentGameHasStolenAssets = copyright;
        gameOn = false;
        setLine = false;
        SceneManager.LoadScene("Game Over Free Fish");
    }


    public void StartGame()
    {
        gameOn = true;
        setPoints = true;
        SceneManager.LoadScene("Free Fish");
        
    }

    /*void invokeSounds()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Pesca");
        FMOD.Studio.EventInstance instance_Pesca_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/BGM");
        FMOD.Studio.EventInstance instance_Pesca_Water_Enter = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Water Enter");
        FMOD.Studio.EventInstance instance_Pesca_Water_Out = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Water Out");
        FMOD.Studio.EventInstance instance_Pesca_Point = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Point");
        FMOD.Studio.EventInstance instance_Pesca_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Pesca/Win");
    }*/
}


