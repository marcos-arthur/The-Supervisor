using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compra5 : MonoBehaviour
{
    public int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Carrinho")
        {
            Destroy(gameObject);
            GameController_Compras.pontuacao += points;
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
