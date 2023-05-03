using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialFishingGameController : MonoBehaviour
{
    [SerializeField] private Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void play()
    {
        SceneManager.LoadScene("Free Fish");
    }
}
