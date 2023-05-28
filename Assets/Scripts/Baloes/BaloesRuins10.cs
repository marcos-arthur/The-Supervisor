using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloesRuins10 : MonoBehaviour
{
    //[SerializeField] public GameObject gameControllerObject;
   // private GameController gameController;
    

    public int valor = -10;
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
      //  gameControllerObject = GameObject.Find("GameControler");
      //  gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
