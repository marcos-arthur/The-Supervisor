using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreExibition : MonoBehaviour
   

{
    public int score;
    public GameObject SimonSaysScript;
    public SimonSayScript pontuation;

    public TextMeshProUGUI myText;
   
    // Start is called before the first frame update
    void Start()
    {
        GameObject SimonSaysScript = GameObject.Find("Colours"); 

        SimonSayScript pontuation = SimonSaysScript.GetComponent<SimonSayScript>();

        int score = pontuation.points;
    }

    // Update is called once per frame
    void Update()
    {
        score = pontuation.points;
        myText.text = "Score: " + score.ToString();
    }
}
