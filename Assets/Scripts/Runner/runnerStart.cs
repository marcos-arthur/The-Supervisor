using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunnerGameStart : MonoBehaviour
{
    public Button start;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(ChangeScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Runner");
    }
}