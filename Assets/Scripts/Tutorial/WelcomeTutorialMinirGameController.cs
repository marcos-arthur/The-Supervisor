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
        playButton.onClick.AddListener(play);

        GamesScore.openedGameScene = "Welcome Tutorial Game";
        GamesScore.gameName = "Tutorial game";
        GamesScore.hasStolenAsset = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void play()
    {
        SceneManager.LoadScene("Tutorial Game", LoadSceneMode.Additive);
    }
}
