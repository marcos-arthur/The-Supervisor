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
        playButton.onClick.AddListener(FreeFishController.Instance.StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
