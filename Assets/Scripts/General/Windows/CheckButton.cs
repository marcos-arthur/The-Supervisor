using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private bool yesResponse;

    // Start is called before the first frame update
    void Start()
    {
        if (yesResponse)
        {
            GameController.instance.yesButton = GetComponent<Button>();
            GameController.instance.yesButton.onClick.AddListener(delegate { GameController.instance.ButtonReponse(true); });
        }
        else
        {
            Debug.Log(gameObject.name);
            GameController.instance.noButton = GetComponent<Button>();
            GameController.instance.noButton.onClick.AddListener(delegate { GameController.instance.ButtonReponse(false); });
        }
    }

}
