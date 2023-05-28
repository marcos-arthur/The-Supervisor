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
            BaloesGameController.pontuacao += valor;
            //gameController.AtualizarPontuacao(valor);
            Debug.Log(BaloesGameController.pontuacao);
            //instance_Baloes_Points2.start();
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
