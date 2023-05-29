using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BaloesRuins20 : MonoBehaviour
{
    public int valor = -20;
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
