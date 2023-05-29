using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioAssetPlayerDragonFire : MonoBehaviour
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
        AudioController.instance.PlayOneShot(FMODEventsController.instance.DragonFire, transform.position);
    }
}
