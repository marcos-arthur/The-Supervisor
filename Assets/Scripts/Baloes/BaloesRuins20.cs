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
            BaloesGameController.pontuacao += valor;
            //gameController.AtualizarPontuacao(valor);
            Debug.Log(BaloesGameController.pontuacao);
            //instance_Baloes_Fail.start();
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
