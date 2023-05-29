using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class AudioAssetPlayerUnusedCoin : MonoBehaviour
{
    public Button playbutton;
    // Start is called before the first frame update
    void Start()
    {
        playbutton.onClick.AddListener(Playaudio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Playaudio()
    {
        AudioController.instance.PlayOneShot(FMODEventsController.instance.UnusedCoin, transform.position);
    }

}
