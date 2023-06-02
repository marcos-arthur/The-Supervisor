using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloesRuins10 : MonoBehaviour
{
    //[SerializeField] public GameObject gameControllerObject;
   // private GameController gameController;
    

    public int valor;
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
      //  gameControllerObject = GameObject.Find("GameControler");
      //  gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
