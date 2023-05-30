using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplorerClose : MonoBehaviour
{
    public static ExplorerClose Instance {  get; private set; }

    public Button closeButton;
    public bool authorize = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(windowCloser);
    }

    public void windowCloser()
    {
        GameController.instance.explorerOpen = false;


        GameController.instance.CloseWindow(gameObject);
    }
}
