using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaoMorte : MonoBehaviour
{

    public int valor = -100;

    private void OnMouseDown()
    {
        if (gameObject)
        {
            BaloesAudioController.Instance.PlayFailSound();
            BaloesGameController.pontuacao += valor;

            Destroy(gameObject);
        }
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
