using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra3 : MonoBehaviour
{
    public int points;

    public FMOD.Studio.EventInstance instance_Compras_Miss = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/Miss");
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Carrinho")
        {
            GameController_Compras.pontuacao += points;
            instance_Compras_Miss.start();
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
