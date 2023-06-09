using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Text results;

    [field: SerializeField] public List<GameObject> forestDodgeStolenAssetsList { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        RunnerAudioController.Instance.StopPlaySceneAudios();

        int finalScore = RunnerGameController.pontos;
        if (finalScore <= 0)
        {
            results.text = "OOHHH, Nice try!            Your score: " + finalScore;
        }
        else
        {
            results.text = "Congratulations!            Your score: " + finalScore;
        }
    }

    private void OnDestroy()
    {
        // GameController.instance.OpenSelectionWindow(forestDodgeStolenAssetsList);
    }

    public void CloseGame()
    {
        GameController.instance.OpenSelectionWindow(forestDodgeStolenAssetsList);
        // GameController.instance.CloseGame();
    }
}
