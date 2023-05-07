using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaoMorte : MonoBehaviour
{

    public int valor = 0;

    private void OnMouseDown()
    {
        if (gameObject)
        {
            BaloesGameController.pontuacao = valor;
            //gameController.AtualizarPontuacao(valor);
            //instance_Baloes_Fail.start();
            Debug.Log(BaloesGameController.pontuacao);
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
