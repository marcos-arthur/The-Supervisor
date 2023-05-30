using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSounds : MonoBehaviour
{
    public StudioEventEmitter eventEmitter;
    public string vcaName = "vca:/Sfx";

    private VCA vca;
    private float volume;

    private void Awake()
    {
        // Obtém o objeto VCA pelo nome
        vca = RuntimeManager.GetVCA(vcaName);
        // Obtém o volume inicial do VCA
        vca.getVolume(out volume);
    }

    public void SetVolume(float sliderValue)
    {
        // Atualiza o volume do VCA
        volume = Mathf.Lerp(-80f, 0f, sliderValue); // Mapeia o valor do slider para o intervalo de -80dB a 0dB
        vca.setVolume(volume);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
