using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button[] colours;

    public Image chosenColour;

    private int colourSelect;

    [SerializeField] private Button playButton;
    
    public float upTime;

    public float upTimeCounter;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);


    }

    // Update is called once per frame
    void Update()
    {
        if(upTimeCounter > 0)
        {
            upTimeCounter -= Time.deltaTime;
        }
        else
        {
            chosenColour.color = new Color(chosenColour.color.r, chosenColour.color.g, chosenColour.color.b, 80);
        }
    }

    public void StartGame()
    {
        colourSelect = Random.Range(0, 4);

        chosenColour = colours[colourSelect].GetComponent<Image>();
        chosenColour.color = new Color(chosenColour.color.r, chosenColour.color.g, chosenColour.color.b, 1f);

        upTimeCounter = upTime;
    }
}
