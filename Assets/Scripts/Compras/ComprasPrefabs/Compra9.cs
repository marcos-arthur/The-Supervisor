using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra9 : MonoBehaviour
{
    public int points;

    public FMOD.Studio.EventInstance instance_Compras_Point = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/Point");
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Carrinho")
        {
            GameController_Compras.pontuacao += points;
            instance_Compras_Point.start();
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
