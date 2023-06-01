using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTutorialController : MonoBehaviour
{
    [field: Header("Stolen Assets Lists")]
    [SerializeField] public List<GameObject> tutorialStolenAssetsList;

    // Start is called before the first frame update
    void Start()
    {
        TutorialAudioController.Instance.StopPlaySceneAudios();

        GameController.instance.isTutorial = true;
        // GameController.instance.OpenCheckWindow();
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void CloseGame()
    {
        GameController.instance.OpenSelectionWindow(tutorialStolenAssetsList);
        // GameController.instance.CloseGame();
    }
}
