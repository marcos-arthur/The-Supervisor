using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeTutorialGameController : MonoBehaviour
{
    [SerializeField] private Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        GlobalPointsController.instance.currentGameHasStolenAssets = true;
        playButton.onClick.AddListener(play);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void play()
    {
        SceneManager.LoadScene("Tutorial Game");
    }
}
