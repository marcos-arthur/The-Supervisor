using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloes30 : MonoBehaviour
{
    public int valor = 50;
    private void OnMouseDown()
    {
        if (gameObject)
        {
            BaloesAudioController.Instance.PlayPointSound();
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
