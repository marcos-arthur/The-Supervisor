using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class SimonSayScript : MonoBehaviour
{
    public Button[] colours;

    public GameObject panel, endScore;

    public TextMeshProUGUI myText, endText;


    public UnityEvent SIGNAL_EMISSION, INTERVAL_START;

    public Image chosenColour = null, mistaken;

    public int Aux, level = 0, levelRoll = 0, points = 0;

    public bool wrong = false, playerIsPlaying = false, firstPlay = false, currently = false, fadeIn = false, fadeOut = false;


    public int Count = 0;

    public List<int> buttonSelection;

    public List<int> playerSelection;
    private int colourSelect;

    [SerializeField] private Button playButton, yellowButton, greenButton, redButton, blueButton, playButtonAlready;

    public float upTime, interval = 2.0f, timer = 60.0f;

    public float upTimeCounter;

    private bool isGameFinished = false;
    
    // Start is called before the first frame update
    void Start()
    {

        playButton.onClick.AddListener(StartGame);

        yellowButton.onClick.AddListener(YellowButton);

        blueButton.onClick.AddListener(BlueButton);

        redButton.onClick.AddListener(RedButton);

        greenButton.onClick.AddListener(GreenButton);

        SIGNAL_EMISSION.AddListener(StartGame);

        playButtonAlready.onClick.AddListener(StartGame);

        playButtonAlready.interactable = false;

        playButtonAlready.gameObject.SetActive(false);
        
        buttonSelection = new List<int>{};

        playerSelection = new List<int>{};

        endScore.SetActive(false);

        GlobalPointsController.instance.currentGameHasStolenAssets = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSelection.Count == buttonSelection.Count)
        {
            if(firstPlay == false)
            {
                return;           
            }
            else{
                playerIsPlaying = false;
                level++;
                levelRoll = level;
                interval = 2.0f;
                StartGame();
            }
        }

        if(playerIsPlaying == false || firstPlay == false)
        {
            redButton.interactable = false;
            blueButton.interactable = false;
            yellowButton.interactable = false;
            greenButton.interactable = false;
        }
        else if(playerIsPlaying == true && firstPlay == true && wrong != true)
        {
            redButton.interactable = true;
            blueButton.interactable = true;
            yellowButton.interactable = true;
            greenButton.interactable = true;
        }
        
        if (upTimeCounter > 0)
        {
            upTimeCounter -= Time.deltaTime;
        }
        else if (chosenColour != null && wrong == false)
        {
            chosenColour.color = new Color(chosenColour.color.r, chosenColour.color.g, chosenColour.color.b, 0.50f);
            currently = false;

            if(levelRoll > 0)
            {
                if(interval < 0 && currently == false)
                {
                    levelRoll--;
                    SIGNAL_EMISSION.Invoke();
                    currently = true;
                    interval = 2.0f;
                }
            }
            else
            {
                playerIsPlaying = true;
            }
        }

        myText.text = timer.ToString("F0");

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (!isGameFinished)
            {
                isGameFinished = true;
                DragonAudioController.Instance.StopPlaySceneAudios();

                playerIsPlaying = false;
                panel.SetActive(true);
                playButtonAlready.gameObject.SetActive(false);
                playButtonAlready.interactable = false;
                endScore.SetActive(true);

                if (points < 150)
                {
                    endText.text = "You are responsible for the extinction of our race, congratulations!";
                    DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.failSound);
                }
                if(points >= 150)
                {
                    endText.text = "You did an average job, but The Dragons are now calm, but you can do better! ";
                    DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.winSound);
                }
                if(points >= 250)
                {
                    endText.text = "Congratulations! You have saved us and done an astonishing job. The superiors will be pleased with your mighty resilience. You can now rest safely, knowing that you did your best!";
                    DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.totalWinSound);
                }

                GameController.instance.OpenCheckWindow();
            }
        }

        if(interval > 0)
        {
            interval -= Time.deltaTime;
        }

        if(upTimeCounter < 0 && wrong == true)
        {
            wrong = false;
        }
    }

    public void StartGame()
    {
        DragonAudioController.Instance.StartPlaySceneAudios();

        if(firstPlay == false){

            panel.SetActive(false);
            playButton.gameObject.SetActive(false);
            playButton.interactable = false;

            playButtonAlready.gameObject.SetActive(false);
            playButtonAlready.interactable = false;

            colours[0].GetComponent<Image>().color = new Color(colours[0].GetComponent<Image>().color.r, colours[0].GetComponent<Image>().color.g, colours[0].GetComponent<Image>().color.b, 0.50f);
            colours[1].GetComponent<Image>().color = new Color(colours[1].GetComponent<Image>().color.r, colours[1].GetComponent<Image>().color.g, colours[1].GetComponent<Image>().color.b, 0.50f);
            colours[2].GetComponent<Image>().color = new Color(colours[2].GetComponent<Image>().color.r, colours[2].GetComponent<Image>().color.g, colours[2].GetComponent<Image>().color.b, 0.50f);
            colours[3].GetComponent<Image>().color = new Color(colours[3].GetComponent<Image>().color.r, colours[3].GetComponent<Image>().color.g, colours[3].GetComponent<Image>().color.b, 0.50f);
        }

        redButton.interactable = false;
        blueButton.interactable = false;
        yellowButton.interactable = false;
        greenButton.interactable = false;

        firstPlay = true;
            
        colourSelect = Random.Range(0, 4);
        buttonSelection.Add(colourSelect);
        chosenColour = colours[colourSelect].GetComponent<Image>();
        chosenColour.color = new Color(chosenColour.color.r, chosenColour.color.g, chosenColour.color.b, 1f);
        upTimeCounter = upTime;
    }

    public void RedButton()
    {
        DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.fireDragonSound);

        playerSelection.Add(0);
        Count = Count + 1;

        if (playerSelection[Count - 1] == buttonSelection[Count - 1])
        {
            points = points + (10 + 1 * level);
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.correctSound);

            return;
        }
        else
        {
            Aux = buttonSelection[Count - 1];
            mistaken = colours[Aux].GetComponent<Image>();
            wrong = true;
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.missSound);

            mistaken.color = new Color(mistaken.color.r, mistaken.color.g, mistaken.color.b, 0f);
            upTimeCounter = upTime;
            level = 0;
            firstPlay = false;
            playButtonAlready.gameObject.SetActive(true);
            playButtonAlready.interactable = true;
            buttonSelection.Clear();
            playerSelection.Clear();
            Count = 0;
            chosenColour = null;
            redButton.interactable = false;
            blueButton.interactable = false;
            yellowButton.interactable = false;
            greenButton.interactable = false;

        }
    }
    public void BlueButton()
    {
        DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.iceDragonSound);

        playerSelection.Add(1);
        Count = Count + 1;

        if (playerSelection[Count - 1] == buttonSelection[Count - 1])
        {
            points = points + (10 + 1 * level);
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.correctSound);

            return;
        }
        else
        {
            Aux = buttonSelection[Count - 1];
            mistaken = colours[Aux].GetComponent<Image>();
            wrong = true;
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.fireDragonSound);

            mistaken.color = new Color(mistaken.color.r, mistaken.color.g, mistaken.color.b, 0f);
            upTimeCounter = upTime;
            level = 0;
            firstPlay = false;
            playButtonAlready.gameObject.SetActive(true);
            playButtonAlready.interactable = true;
            buttonSelection.Clear();
            playerSelection.Clear();
            Count = 0;
            chosenColour = null;
            redButton.interactable = false;
            blueButton.interactable = false;
            yellowButton.interactable = false;
            greenButton.interactable = false;
        }
    }
    public void GreenButton()
    {
        DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.groundDragonSound);

        playerSelection.Add(3);
        Count = Count + 1;

        if (playerSelection[Count - 1] == buttonSelection[Count - 1])
        {
            points = points + (10+1*level);
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.correctSound);

            return;
        }
        else
        {
            Aux = buttonSelection[Count - 1];
            mistaken = colours[Aux].GetComponent<Image>();
            wrong = true;
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.failSound);

            mistaken.color = new Color(mistaken.color.r, mistaken.color.g, mistaken.color.b, 0f);
            upTimeCounter = upTime;
            level = 0;
            firstPlay = false;
            playButtonAlready.gameObject.SetActive(true);
            playButtonAlready.interactable = true;
            buttonSelection.Clear();
            playerSelection.Clear();
            Count = 0;
            chosenColour = null;
            redButton.interactable = false;
            blueButton.interactable = false;
            yellowButton.interactable = false;
            greenButton.interactable = false;
        }

    }
    public void YellowButton()
    {
        DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.thunderDragonSound);

        playerSelection.Add(2);
        Count = Count + 1;

        if (playerSelection[Count-1] == buttonSelection[Count-1])
        {
            points = points + (10 + 1 * level);
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.correctSound);

            return;
        }
        else
        {
            Aux = buttonSelection[Count - 1];
            mistaken = colours[Aux].GetComponent<Image>();
            wrong = true;
            DragonAudioController.Instance.PlaySound(DragonFMODEventsController.Instance.missSound);

            mistaken.color = new Color(mistaken.color.r, mistaken.color.g, mistaken.color.b, 0f);
            upTimeCounter = upTime;

            playButtonAlready.gameObject.SetActive(true);
            playButtonAlready.interactable = true;
            level = 0;
            firstPlay = false;
            buttonSelection.Clear();
            playerSelection.Clear();
            Count = 0;

            chosenColour = null;

            redButton.interactable = false;
            blueButton.interactable = false;
            yellowButton.interactable = false;
            greenButton.interactable = false;
        }
    }
}
