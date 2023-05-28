using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra1 : MonoBehaviour
{
    public int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Carrinho")
        {
            GameController_Compras.pontuacao += points;
            AudioController.instance.PlayOneShot(ComprasFMODEventsController.instance.pointSound, transform.position);
            Destroy(gameObject);
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
